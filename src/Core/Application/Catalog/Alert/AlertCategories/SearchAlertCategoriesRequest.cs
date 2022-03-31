namespace TD.CitizenAPI.Application.Catalog.AlertCategories;

public class SearchAlertCategoriesRequest : PaginationFilter, IRequest<PaginationResponse<AlertCategoryDto>>
{
}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<AlertCategory, AlertCategoryDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchAlertCategoriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchAlertCategoriesRequest, PaginationResponse<AlertCategoryDto>>
{
    private readonly IReadRepository<AlertCategory> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<AlertCategory> repository) => _repository = repository;

    public async Task<PaginationResponse<AlertCategoryDto>> Handle(SearchAlertCategoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AlertCategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}