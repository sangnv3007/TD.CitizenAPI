namespace TD.CitizenAPI.Application.Catalog.Areas;

public class SearchAreasRequest : PaginationFilter, IRequest<PaginationResponse<AreaDto>>
{
    public string? ParentCode { get; set; }
    public string? Type { get; set; }
    public int? Level { get; set; }
}

public class AreasBySearchRequestSpec : EntitiesByPaginationFilterSpec<Area, AreaDto>
{
    public AreasBySearchRequestSpec(SearchAreasRequest request)
        : base(request) =>
        Query
            .OrderBy(c => c.Name, !request.HasOrderBy())
            .Where(p => p.ParentCode == request.ParentCode, !string.IsNullOrWhiteSpace(request.ParentCode))
            .Where(p => p.Type == request.Type, !string.IsNullOrWhiteSpace(request.Type))
            .Where(p => p.Level == request.Level, request.Level.HasValue && request.Level.Value > 0);
}

public class SearchCategoriesRequestHandler : IRequestHandler<SearchAreasRequest, PaginationResponse<AreaDto>>
{
    private readonly IReadRepository<Area> _repository;

    public SearchCategoriesRequestHandler(IReadRepository<Area> repository) => _repository = repository;

    public async Task<PaginationResponse<AreaDto>> Handle(SearchAreasRequest request, CancellationToken cancellationToken)
    {
        var spec = new AreasBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AreaDto>(list, count, request.PageNumber, request.PageSize);
    }
}