namespace TD.CitizenAPI.Application.Catalog.Schools;

public class SearchSchoolsRequest : PaginationFilter, IRequest<PaginationResponse<SchoolDto>>
{
}

public class SchoolsBySearchRequestSpec : EntitiesByPaginationFilterSpec<School, SchoolDto>
{
    public SchoolsBySearchRequestSpec(SearchSchoolsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchSchoolsRequestHandler : IRequestHandler<SearchSchoolsRequest, PaginationResponse<SchoolDto>>
{
    private readonly IReadRepository<School> _repository;

    public SearchSchoolsRequestHandler(IReadRepository<School> repository) => _repository = repository;

    public async Task<PaginationResponse<SchoolDto>> Handle(SearchSchoolsRequest request, CancellationToken cancellationToken)
    {
        var spec = new SchoolsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<SchoolDto>(list, count, request.PageNumber, request.PageSize);
    }
}