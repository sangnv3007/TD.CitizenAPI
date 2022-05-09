namespace TD.CitizenAPI.Application.Catalog.DienTichNhas;

public class SearchDienTichNhasRequest : PaginationFilter, IRequest<PaginationResponse<DienTichNhaDto>>
{
}

public class DienTichNhasBySearchRequestSpec : EntitiesByPaginationFilterSpec<DienTichNha, DienTichNhaDto>
{
    public DienTichNhasBySearchRequestSpec(SearchDienTichNhasRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchDienTichNhasRequestHandler : IRequestHandler<SearchDienTichNhasRequest, PaginationResponse<DienTichNhaDto>>
{
    private readonly IReadRepository<DienTichNha> _repository;

    public SearchDienTichNhasRequestHandler(IReadRepository<DienTichNha> repository) => _repository = repository;

    public async Task<PaginationResponse<DienTichNhaDto>> Handle(SearchDienTichNhasRequest request, CancellationToken cancellationToken)
    {
        var spec = new DienTichNhasBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<DienTichNhaDto>(list, count, request.PageNumber, request.PageSize);
    }
}