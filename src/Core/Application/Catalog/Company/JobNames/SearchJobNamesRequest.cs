namespace TD.CitizenAPI.Application.Catalog.JobNames;

public class SearchJobNamesRequest : PaginationFilter, IRequest<PaginationResponse<JobNameDto>>
{
}

public class JobNamesBySearchRequestSpec : EntitiesByPaginationFilterSpec<JobName, JobNameDto>
{
    public JobNamesBySearchRequestSpec(SearchJobNamesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchJobNamesRequestHandler : IRequestHandler<SearchJobNamesRequest, PaginationResponse<JobNameDto>>
{
    private readonly IReadRepository<JobName> _repository;

    public SearchJobNamesRequestHandler(IReadRepository<JobName> repository) => _repository = repository;

    public async Task<PaginationResponse<JobNameDto>> Handle(SearchJobNamesRequest request, CancellationToken cancellationToken)
    {
        var spec = new JobNamesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<JobNameDto>(list, count, request.PageNumber, request.PageSize);
    }
}