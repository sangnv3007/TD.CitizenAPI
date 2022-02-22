namespace TD.CitizenAPI.Application.Catalog.JobPositions;

public class SearchJobPositionsRequest : PaginationFilter, IRequest<PaginationResponse<JobPositionDto>>
{
}

public class JobPositionsBySearchRequestSpec : EntitiesByPaginationFilterSpec<JobPosition, JobPositionDto>
{
    public JobPositionsBySearchRequestSpec(SearchJobPositionsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchJobPositionsRequestHandler : IRequestHandler<SearchJobPositionsRequest, PaginationResponse<JobPositionDto>>
{
    private readonly IReadRepository<JobPosition> _repository;

    public SearchJobPositionsRequestHandler(IReadRepository<JobPosition> repository) => _repository = repository;

    public async Task<PaginationResponse<JobPositionDto>> Handle(SearchJobPositionsRequest request, CancellationToken cancellationToken)
    {
        var spec = new JobPositionsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<JobPositionDto>(list, count, request.PageNumber, request.PageSize);
    }
}