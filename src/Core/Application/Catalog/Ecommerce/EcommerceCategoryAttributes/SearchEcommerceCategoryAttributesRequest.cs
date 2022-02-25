namespace TD.CitizenAPI.Application.Catalog.EcommerceCategoryAttributes;

public class SearchEcommerceCategoryAttributesRequest : PaginationFilter, IRequest<PaginationResponse<EcommerceCategoryAttributeDto>>
{
    public Guid? EcommerceCategoryId { get; set; }
}

public class EcommerceCategoryAttributesBySearchRequestSpec : EntitiesByPaginationFilterSpec<EcommerceCategoryAttribute, EcommerceCategoryAttributeDto>
{
    public EcommerceCategoryAttributesBySearchRequestSpec(SearchEcommerceCategoryAttributesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Position, !request.HasOrderBy())
        .Where(p => p.EcommerceCategoryId == request.EcommerceCategoryId, request.EcommerceCategoryId.HasValue)
        ;
}

public class SearchHotlineCategoriesRequestHandler : IRequestHandler<SearchEcommerceCategoryAttributesRequest, PaginationResponse<EcommerceCategoryAttributeDto>>
{
    private readonly IReadRepository<EcommerceCategoryAttribute> _repository;

    public SearchHotlineCategoriesRequestHandler(IReadRepository<EcommerceCategoryAttribute> repository) => _repository = repository;

    public async Task<PaginationResponse<EcommerceCategoryAttributeDto>> Handle(SearchEcommerceCategoryAttributesRequest request, CancellationToken cancellationToken)
    {
        var spec = new EcommerceCategoryAttributesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<EcommerceCategoryAttributeDto>(list, count, request.PageNumber, request.PageSize);
    }
}