namespace TD.CitizenAPI.Application.Catalog.Drugs;

public class FetchDrugRequest : IRequest<string>
{
}

public class FetchMarketProductHandler : IRequestHandler<FetchDrugRequest, string>
{
    private readonly IJobService _jobService;

    public FetchMarketProductHandler(IJobService jobService) => _jobService = jobService;

    public Task<string> Handle(FetchDrugRequest request, CancellationToken cancellationToken)
    {
        string jobId = _jobService.Enqueue<IFetchDrugJob>(x => x.FetchDrugAsync(default));
        return Task.FromResult(jobId);
    }
}