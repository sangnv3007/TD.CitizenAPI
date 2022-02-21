using Ardalis.Specification;
using TD.CitizenAPI.Application.Catalog.Brands;
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

namespace TD.CitizenAPI.Infrastructure.Catalog;

public class FetchMarketProductJob : IFetchMarketProductJob
{
    private readonly ILogger<FetchMarketProductJob> _logger;
    private readonly ISender _mediator;
    private readonly IReadRepository<MarketProduct> _repository;
    private readonly IReadRepository<MarketCategory> _repositoryMarketCategory;

    private readonly IProgressBarFactory _progressBar;
    private readonly PerformingContext _performingContext;
    private readonly INotificationSender _notifications;
    private readonly ICurrentUser _currentUser;
    private readonly IProgressBar _progress;

    public FetchMarketProductJob(
        ILogger<FetchMarketProductJob> logger,
        ISender mediator,
        IReadRepository<MarketProduct> repository,
        IReadRepository<MarketCategory> repositoryMarketCategory,
        IProgressBarFactory progressBar,
        PerformingContext performingContext,
        INotificationSender notifications,
        ICurrentUser currentUser)
    {
        _logger = logger;
        _mediator = mediator;
        _repository = repository;
        _repositoryMarketCategory = repositoryMarketCategory;
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
    public async Task FetchProductAsync(CancellationToken cancellationToken)
    {
        await NotifyAsync("FetchProductAsync processing has started", 0, cancellationToken);

        var client = new RestClient();
        var cancellationTokenSource = new CancellationTokenSource();

        var lstMarketCategory = await _repositoryMarketCategory.ListAsync(cancellationToken);
        foreach (MarketCategory marketCategory in lstMarketCategory)
        {
            int pageTMP = 1;
            bool check = true;
            while (check)
            {
                var request_ = new RestRequest("https://chopp.vn/api/products?populate=true&locale=vi&page=" + pageTMP + "&limit=100&where={\"category\":\"" + marketCategory.Code + "\"}");
                var restResponse =
                    await client.ExecuteAsync(request_, cancellationTokenSource.Token);

                string? content = restResponse.Content;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                content = content.Replace("photo@3x", "photo");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                dynamic blogPosts = JObject.Parse(content);
                dynamic result = blogPosts.result;

                var tmp = result.Count;
                if (tmp < 100)
                {
                    check = false;
                }

                foreach (dynamic album in result)
                {
                    try
                    {

                        await _mediator.Send(
                            new CreateMarketProductRequest
                               {
                                   Code = album.id,
                                   Name = album.fields.name,
                                   Brand = album.fields.brand,
                                   Packaging = album.fields.packaging,
                                   Price = album.fields.price,
                                   Image = album.fields.photo[0].url,
                                   Unit = album.fields.unit,
                                   Origin = album.fields.origin,
                                   Description = album.fields.description,
                                   DisplayUnit = album.fields.displayUnit,
                                   DisplayFactor = album.fields.displayFactor,
                                   MarketCategoryId = marketCategory.Id
                               },
                            cancellationToken);
                    }
                    catch (Exception)
                    {

                    }
                }

                pageTMP++;
            }
        }


        /*foreach (int index in Enumerable.Range(1, nSeed))
        {
            await _mediator.Send(
                new CreateBrandRequest
                {
                    Name = $"Brand Random - {Guid.NewGuid()}",
                    Description = "Funny description"
                },
                cancellationToken);

            await NotifyAsync("Progress: ", nSeed > 0 ? (index * 100 / nSeed) : 0, cancellationToken);
        }*/

        await NotifyAsync("FetchProductAsync successfully completed", 0, cancellationToken);
    }
}

