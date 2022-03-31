namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class GenerateEcommerceCategoriesRequest : IRequest<string>
{
    public int ParentId { get; set; }
    public string Token { get; set; } = default!;
}

public class GenerateEcommerceCategoriesRequestHandler : IRequestHandler<GenerateEcommerceCategoriesRequest, string>
{
    private readonly IJobService _jobService;

    public GenerateEcommerceCategoriesRequestHandler(IJobService jobService) => _jobService = jobService;

    public Task<string> Handle(GenerateEcommerceCategoriesRequest request, CancellationToken cancellationToken)
    {
        string jobId = _jobService.Enqueue<IEcommerceCategoriesGeneratorJob>(x => x.GenerateAsync(request.ParentId, request.Token, default));
        return Task.FromResult(jobId);
    }
}