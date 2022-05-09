namespace TD.CitizenAPI.Application.Catalog.ThoiGianThueNhas;

public class SearchThoiGianThueNhasRequest : PaginationFilter, IRequest<PaginationResponse<ThoiGianThueNhaDto>>
{
}

public class MucGiaThueNhasBySearchRequestSpec : EntitiesByPaginationFilterSpec<MucGiaThueNha, ThoiGianThueNhaDto>
{
    public MucGiaThueNhasBySearchRequestSpec(SearchThoiGianThueNhasRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchMucGiaThueNhasRequestHandler : IRequestHandler<SearchThoiGianThueNhasRequest, PaginationResponse<ThoiGianThueNhaDto>>
{
    private readonly IReadRepository<MucGiaThueNha> _repository;

    public SearchMucGiaThueNhasRequestHandler(IReadRepository<MucGiaThueNha> repository) => _repository = repository;

    public async Task<PaginationResponse<ThoiGianThueNhaDto>> Handle(SearchThoiGianThueNhasRequest request, CancellationToken cancellationToken)
    {
        var spec = new MucGiaThueNhasBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ThoiGianThueNhaDto>(list, count, request.PageNumber, request.PageSize);
    }
}