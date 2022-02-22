namespace TD.CitizenAPI.Application.Catalog.JobTypes;

public class SearchJobTypesRequest : PaginationFilter, IRequest<PaginationResponse<JobTypeDto>>
{
}

public class JobTypesBySearchRequestSpec : EntitiesByPaginationFilterSpec<JobType, JobTypeDto>
{
    public JobTypesBySearchRequestSpec(SearchJobTypesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchJobTypesRequestHandler : IRequestHandler<SearchJobTypesRequest, PaginationResponse<JobTypeDto>>
{
    private readonly IReadRepository<JobType> _repository;

    public SearchJobTypesRequestHandler(IReadRepository<JobType> repository) => _repository = repository;

    public async Task<PaginationResponse<JobTypeDto>> Handle(SearchJobTypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new JobTypesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<JobTypeDto>(list, count, request.PageNumber, request.PageSize);
    }
}