namespace TD.CitizenAPI.Application.Catalog.Degrees;

public class SearchDegreesRequest : PaginationFilter, IRequest<PaginationResponse<DegreeDto>>
{
}

public class DegreesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Degree, DegreeDto>
{
    public DegreesBySearchRequestSpec(SearchDegreesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchDegreesRequestHandler : IRequestHandler<SearchDegreesRequest, PaginationResponse<DegreeDto>>
{
    private readonly IReadRepository<Degree> _repository;

    public SearchDegreesRequestHandler(IReadRepository<Degree> repository) => _repository = repository;

    public async Task<PaginationResponse<DegreeDto>> Handle(SearchDegreesRequest request, CancellationToken cancellationToken)
    {
        var spec = new DegreesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<DegreeDto>(list, count, request.PageNumber, request.PageSize);
    }
}