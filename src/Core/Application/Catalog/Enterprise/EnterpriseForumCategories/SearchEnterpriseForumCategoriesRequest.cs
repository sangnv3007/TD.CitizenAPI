namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumCategories;

public class SearchEnterpriseForumCategoriesRequest : PaginationFilter, IRequest<PaginationResponse<EnterpriseForumCategoryDto>>
{
}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<EnterpriseForumCategory, EnterpriseForumCategoryDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchEnterpriseForumCategoriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchEnterpriseForumCategoriesRequest, PaginationResponse<EnterpriseForumCategoryDto>>
{
    private readonly IReadRepository<EnterpriseForumCategory> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<EnterpriseForumCategory> repository) => _repository = repository;

    public async Task<PaginationResponse<EnterpriseForumCategoryDto>> Handle(SearchEnterpriseForumCategoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<EnterpriseForumCategoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}