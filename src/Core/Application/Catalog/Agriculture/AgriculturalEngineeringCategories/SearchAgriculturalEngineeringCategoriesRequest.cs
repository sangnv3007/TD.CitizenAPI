namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineeringCategories;

public class SearchAgriculturalEngineeringCategoriesRequest : PaginationFilter, IRequest<PaginationResponse<AgriculturalEngineeringCategoryDto>>
{
}

public class AgriculturalEngineeringCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<AgriculturalEngineeringCategory, AgriculturalEngineeringCategoryDto>
{
    public AgriculturalEngineeringCategoriesBySearchRequestSpec(SearchAgriculturalEngineeringCategoriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchAgriculturalEngineeringCategoriesRequestHandler : IRequestHandler<SearchAgriculturalEngineeringCategoriesRequest, PaginationResponse<AgriculturalEngineeringCategoryDto>>
{
    private readonly IReadRepository<AgriculturalEngineeringCategory> _repository;

    public SearchAgriculturalEngineeringCategoriesRequestHandler(IReadRepository<AgriculturalEngineeringCategory> repository) => _repository = repository;

    public async Task<PaginationResponse<AgriculturalEngineeringCategoryDto>> Handle(SearchAgriculturalEngineeringCategoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new AgriculturalEngineeringCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AgriculturalEngineeringCategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}