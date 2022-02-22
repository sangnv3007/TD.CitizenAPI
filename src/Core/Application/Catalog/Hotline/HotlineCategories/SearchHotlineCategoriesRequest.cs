namespace TD.CitizenAPI.Application.Catalog.HotlineCategories;

public class SearchHotlineCategoriesRequest : PaginationFilter, IRequest<PaginationResponse<HotlineCategoryDto>>
{
}

public class HotlineCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<HotlineCategory, HotlineCategoryDto>
{
    public HotlineCategoriesBySearchRequestSpec(SearchHotlineCategoriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchHotlineCategoriesRequestHandler : IRequestHandler<SearchHotlineCategoriesRequest, PaginationResponse<HotlineCategoryDto>>
{
    private readonly IReadRepository<HotlineCategory> _repository;

    public SearchHotlineCategoriesRequestHandler(IReadRepository<HotlineCategory> repository) => _repository = repository;

    public async Task<PaginationResponse<HotlineCategoryDto>> Handle(SearchHotlineCategoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new HotlineCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<HotlineCategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}