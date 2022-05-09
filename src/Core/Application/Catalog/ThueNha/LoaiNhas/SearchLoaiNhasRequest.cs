namespace TD.CitizenAPI.Application.Catalog.LoaiNhas;

public class SearchLoaiNhasRequest : PaginationFilter, IRequest<PaginationResponse<LoaiNhaDto>>
{
}

public class LoaiNhasBySearchRequestSpec : EntitiesByPaginationFilterSpec<LoaiNha, LoaiNhaDto>
{
    public LoaiNhasBySearchRequestSpec(SearchLoaiNhasRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchLoaiNhasRequestHandler : IRequestHandler<SearchLoaiNhasRequest, PaginationResponse<LoaiNhaDto>>
{
    private readonly IReadRepository<LoaiNha> _repository;

    public SearchLoaiNhasRequestHandler(IReadRepository<LoaiNha> repository) => _repository = repository;

    public async Task<PaginationResponse<LoaiNhaDto>> Handle(SearchLoaiNhasRequest request, CancellationToken cancellationToken)
    {
        var spec = new LoaiNhasBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<LoaiNhaDto>(list, count, request.PageNumber, request.PageSize);
    }
}