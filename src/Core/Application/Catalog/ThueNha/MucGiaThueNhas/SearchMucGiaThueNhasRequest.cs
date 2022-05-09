namespace TD.CitizenAPI.Application.Catalog.MucGiaThueNhas;

public class SearchMucGiaThueNhasRequest : PaginationFilter, IRequest<PaginationResponse<MucGiaThueNhaDto>>
{
}

public class MucGiaThueNhasBySearchRequestSpec : EntitiesByPaginationFilterSpec<MucGiaThueNha, MucGiaThueNhaDto>
{
    public MucGiaThueNhasBySearchRequestSpec(SearchMucGiaThueNhasRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchMucGiaThueNhasRequestHandler : IRequestHandler<SearchMucGiaThueNhasRequest, PaginationResponse<MucGiaThueNhaDto>>
{
    private readonly IReadRepository<MucGiaThueNha> _repository;

    public SearchMucGiaThueNhasRequestHandler(IReadRepository<MucGiaThueNha> repository) => _repository = repository;

    public async Task<PaginationResponse<MucGiaThueNhaDto>> Handle(SearchMucGiaThueNhasRequest request, CancellationToken cancellationToken)
    {
        var spec = new MucGiaThueNhasBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<MucGiaThueNhaDto>(list, count, request.PageNumber, request.PageSize);
    }
}