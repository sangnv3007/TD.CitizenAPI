namespace TD.CitizenAPI.Application.Catalog.Products;

public class GenerateProductsRequest : IRequest<string>
{
    public string Category { get; set; } = default!;
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 100;
    public string SortOption { get; set; } = "top_seller";
}

public class GenerateProductsRequestHandler : IRequestHandler<GenerateProductsRequest, string>
{
    private readonly IJobService _jobService;

    public GenerateProductsRequestHandler(IJobService jobService) => _jobService = jobService;

    public Task<string> Handle(GenerateProductsRequest request, CancellationToken cancellationToken)
    {
        string jobId = _jobService.Enqueue<IProductsGeneratorJob>(x => x.GenerateAsync(request.Category, request.Page, request.Limit, request.SortOption, default));
        return Task.FromResult(jobId);
    }
}