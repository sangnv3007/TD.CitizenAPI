namespace TD.CitizenAPI.Application.Catalog.Drugs;

public class SearchDrugsRequest : PaginationFilter, IRequest<PaginationResponse<DrugDto>>
{
}

public class DrugsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Drug, DrugDto>
{
    public DrugsBySearchRequestSpec(SearchDrugsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.TenThuoc, !request.HasOrderBy());
}

public class SearchDrugsRequestHandler : IRequestHandler<SearchDrugsRequest, PaginationResponse<DrugDto>>
{
    private readonly IReadRepository<Drug> _repository;

    public SearchDrugsRequestHandler(IReadRepository<Drug> repository) => _repository = repository;

    public async Task<PaginationResponse<DrugDto>> Handle(SearchDrugsRequest request, CancellationToken cancellationToken)
    {
        var spec = new DrugsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<DrugDto>(list, count, request.PageNumber, request.PageSize);
    }
}