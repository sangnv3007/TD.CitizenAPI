using Ardalis.Specification;
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
using RestSharp;
using Newtonsoft.Json.Linq;
using TD.CitizenAPI.Application.Catalog.EcommerceCategories;

namespace TD.CitizenAPI.Infrastructure.Catalog;

public class FetchEcommerceCategoriesJob : IEcommerceCategoriesGeneratorJob
{
    private readonly ILogger<FetchEcommerceCategoriesJob> _logger;
    private readonly ISender _mediator;
    private readonly IReadRepository<EcommerceCategory> _repository;

    private readonly IProgressBarFactory _progressBar;
    private readonly PerformingContext _performingContext;
    private readonly INotificationSender _notifications;
    private readonly ICurrentUser _currentUser;
    private readonly IProgressBar _progress;

    public FetchEcommerceCategoriesJob(
        ILogger<FetchEcommerceCategoriesJob> logger,
        ISender mediator,
        IReadRepository<EcommerceCategory> repository,
        IProgressBarFactory progressBar,
        PerformingContext performingContext,
        INotificationSender notifications,
        ICurrentUser currentUser)
    {
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
    public async Task GenerateAsync(int nSeed, string token,  CancellationToken cancellationToken)
    {
        await NotifyAsync("FetchProductAsync processing has started", 0, cancellationToken);
        await Handle(nSeed, token, null, cancellationToken);
        await NotifyAsync("FetchProductAsync successfully completed", 0, cancellationToken);
    }


    public async Task Handle(int parentId, string token, Guid? parentCategoryId, CancellationToken cancellationToken)
    {
        var client = new RestClient();
        var request_ = new RestRequest("https://sellercenter.tiki.vn/api/tiki_api?path=catalog/categories&lang=vi&limit=999&is_active=1&include_promotion=1&parent_id=" + parentId + "&include_in_menu=1");
        request_.AddHeader("Authorization", "Bearer " + token);
        var cancellationTokenSource = new CancellationTokenSource();

        var restResponse = await client.ExecuteAsync(request_, cancellationTokenSource.Token);

        var content = restResponse.Content;
        dynamic blogPosts = JObject.Parse(content);
        dynamic result = blogPosts.data;

        foreach (dynamic album in result)
        {
            try
            {

               var category =  await _mediator.Send(
                    new CreateEcommerceCategoryRequest
                    {
                        ParentId = parentCategoryId,
                        Slug = album.url_key,
                        Name = album.name,
                        Description = album.description,
                        MetaTitle = album.meta_title,
                        MetaDescription = album.meta_description,
                        Image = album.file_path,
                        Icon = album.id,
                        IncludeInMenu = true,

                    },
                    cancellationToken);

                string? tmp2 = album.id;
                var tmp = Int32.Parse(tmp2);
           
               //var tmp = typeof(category.Data);

                await Handle(tmp, token, category.Data, cancellationToken);

            }
            catch (Exception)
            {

            }

        }
    }


}

