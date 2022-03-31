using TD.CitizenAPI.Application.Common.Interfaces;
using TD.CitizenAPI.Application.Common.Persistence;
using TD.CitizenAPI.Domain.Catalog;
using TD.CitizenAPI.Shared.Notifications;
using Hangfire;
using Hangfire.Console.Extensions;
using Hangfire.Console.Progress;
using Hangfire.Server;
using MediatR;
using Microsoft.Extensions.Logging;
using TD.CitizenAPI.Application.Catalog.MarketProducts;
using RestSharp;
using Newtonsoft.Json.Linq;
using TD.CitizenAPI.Application.Catalog.Notifications;
using FirebaseAdmin.Messaging;
using TD.CitizenAPI.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GeoCoordinatePortable;

namespace TD.CitizenAPI.Infrastructure.Catalog;

public class SendNotificationJob : ISendNotificationJob
{
    private readonly ILogger<SendNotificationJob> _logger;
    private readonly ISender _mediator;
    private readonly IReadRepository<Domain.Catalog.Notification> _repository;
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly IProgressBarFactory _progressBar;
    private readonly PerformingContext _performingContext;
    private readonly INotificationSender _notifications;
    private readonly ICurrentUser _currentUser;
    private readonly IProgressBar _progress;

    public SendNotificationJob(
        ILogger<SendNotificationJob> logger,
        ISender mediator,
        IReadRepository<Domain.Catalog.Notification> repository,
        IProgressBarFactory progressBar,
        PerformingContext performingContext,
        INotificationSender notifications,
         UserManager<ApplicationUser> userManager,
        ICurrentUser currentUser)
    {
        _userManager = userManager;
        _logger = logger;
        _mediator = mediator;
        _repository = repository;
        _progressBar = progressBar;
        _performingContext = performingContext;
        _notifications = notifications;
        _currentUser = currentUser;
        _progress = _progressBar.Create();
    }

    private async Task NotifyAsync(string message, int progress, CancellationToken cancellationToken)
    {
        _progress.SetValue(progress);
        await _notifications.SendToUserAsync(
            new JobNotification()
            {
                JobId = _performingContext.BackgroundJob.Id,
                Message = message,
                Progress = progress
            },
            _currentUser.GetUserId().ToString(),
            cancellationToken);
    }

    [Queue("notdefault")]
    public async Task SendNotificationAsync(SendNotificationRequest request, CancellationToken cancellationToken)
    {
        await NotifyAsync("FetchProductAsync processing has started", 0, cancellationToken);

        if (request.Latitude.HasValue && request.Latitude != 0 && request.Longitude.HasValue && request.Longitude != 0 && request.Distance.HasValue && request.Distance > 0)
        {
            var listUser = await _userManager.Users.ToListAsync(cancellationToken);
            foreach (var user in listUser)
            {
                if (user.Latitude.HasValue && user.Latitude != 0 && user.Longitude.HasValue && user.Longitude != 0)
                {
                    try
                    {

                        GeoCoordinate pin1 = new GeoCoordinate((double)user.Latitude, (double)user.Longitude);
                        GeoCoordinate pin2 = new GeoCoordinate((double)request.Latitude, (double)request.Longitude);

                        double distanceBetween = pin1.GetDistanceTo(pin2);
                        if (distanceBetween <= (request.Distance * 1000))
                        {
                            await Handle(user.UserName, request, cancellationToken);
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
        else
        {
            foreach (string topic in request.Topics)
            {
                await Handle(topic, request, cancellationToken);
            }
        }
        await NotifyAsync("FetchProductAsync successfully completed", 0, cancellationToken);
    }

    public async Task Handle(string topic, SendNotificationRequest request,  CancellationToken cancellationToken)
    {
        try
        {
            int badgeCount = await _repository.CountAsync(new NotificationByUserNameSpec(topic, false), cancellationToken);

            var message = new Message()
            {
                Topic = topic,
                Data = new Dictionary<string, string>()
                {
                    ["AppType"] = request.AppType,
                    ["Data"] = request.Data,
                    ["ImageUrl"] = request.ImageUrl,
                },
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Title = request.Title,
                    Body = request.Body,
                    ImageUrl = request.ImageUrl
                },
                Android = new FirebaseAdmin.Messaging.AndroidConfig
                {
                    //CollapseKey = request.CollapseKey,
                    Notification = new FirebaseAdmin.Messaging.AndroidNotification
                    {
                        ChannelId = request.AppType
                    },
                    Priority = Priority.High

                },
                Apns = new FirebaseAdmin.Messaging.ApnsConfig
                {
                    Headers = new Dictionary<string, string>()
                    {
                        //["apns-collapse-id"] = request.CollapseKey,
                        //["apns-push-type"] = "background",   //Thong bao im lang cua IOS
                        ["apns-priority"] = "5",
                    },
                    Aps = new FirebaseAdmin.Messaging.Aps
                    {
                        //ContentAvailable=true, //Tạo thông báo nền
                        Badge = badgeCount + 1,
                        Sound = "default",
                        ThreadId = request.AppType,
                        ContentAvailable = true
                    }
                }
            };
            var messaging = FirebaseMessaging.DefaultInstance;
            string? result = await messaging.SendAsync(message, false, cancellationToken);

            await _mediator.Send(
                           new CreateNotificationRequest
                           {
                               UserName = topic,
                               Title = request.Title,
                               Body = request.Body,
                               Code = result,
                               AreaCode = request.AreaCode,
                               AppType = request.AppType,
                               Data = request.Data,
                               IsRead = false,
                           },
                           cancellationToken);

        }
        catch
        {

        }
       
    }
}