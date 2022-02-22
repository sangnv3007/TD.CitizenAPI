namespace TD.CitizenAPI.Application.Catalog.JobAges;

public class SearchJobAgesRequest : PaginationFilter, IRequest<PaginationResponse<JobAgeDto>>
{
}

public class JobAgesBySearchRequestSpec : EntitiesByPaginationFilterSpec<JobAge, JobAgeDto>
{
    public JobAgesBySearchRequestSpec(SearchJobAgesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchJobAgesRequestHandler : IRequestHandler<SearchJobAgesRequest, PaginationResponse<JobAgeDto>>
{
    private readonly IReadRepository<JobAge> _repository;

    public SearchJobAgesRequestHandler(IReadRepository<JobAge> repository) => _repository = repository;

    public async Task<PaginationResponse<JobAgeDto>> Handle(SearchJobAgesRequest request, CancellationToken cancellationToken)
    {
        var spec = new JobAgesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<JobAgeDto>(list, count, request.PageNumber, request.PageSize);
    }
}