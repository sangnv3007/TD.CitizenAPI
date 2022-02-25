namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class SearchEcommerceCategoriesRequest : PaginationFilter, IRequest<PaginationResponse<EcommerceCategoryDto>>
{
    public Guid? ParentId { get; set; }
    public bool? IncludeInMenu { get; set; }
    public int? Level { get; set; }
    public int? Status { get; set; }
    public bool? IsActive { get; set; }

}

public class EcommerceCategorysBySearchRequestSpec : EntitiesByPaginationFilterSpec<EcommerceCategory, EcommerceCategoryDto>
{
    public EcommerceCategorysBySearchRequestSpec(SearchEcommerceCategoriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy())
        .Where(p => p.ParentId == request.ParentId, request.ParentId.HasValue)
    .Where(p => p.ParentId == request.ParentId, request.ParentId.HasValue)
    .Where(p => p.IncludeInMenu == request.IncludeInMenu, request.IncludeInMenu.HasValue)
    .Where(p => p.Level == request.Level, request.Level.HasValue)
    .Where(p => p.Status == request.Status, request.Status.HasValue)
        .Where(p => p.IsActive == request.IsActive, request.IsActive.HasValue)
        ;
}

public class SearchHotlineCategoriesRequestHandler : IRequestHandler<SearchEcommerceCategoriesRequest, PaginationResponse<EcommerceCategoryDto>>
{
    private readonly IReadRepository<EcommerceCategory> _repository;

    public SearchHotlineCategoriesRequestHandler(IReadRepository<EcommerceCategory> repository) => _repository = repository;

    public async Task<PaginationResponse<EcommerceCategoryDto>> Handle(SearchEcommerceCategoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new EcommerceCategorysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<EcommerceCategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}