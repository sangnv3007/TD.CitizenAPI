namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class FetchMarketProductRequest : IRequest<string>
{
}

public class FetchMarketProductHandler : IRequestHandler<FetchMarketProductRequest, string>
{
    private readonly IJobService _jobService;

    public FetchMarketProductHandler(IJobService jobService) => _jobService = jobService;

    public Task<string> Handle(FetchMarketProductRequest request, CancellationToken cancellationToken)
    {
        string jobId = _jobService.Enqueue<IFetchMarketProductJob>(x => x.FetchProductAsync(default));
        return Task.FromResult(jobId);
    }
}