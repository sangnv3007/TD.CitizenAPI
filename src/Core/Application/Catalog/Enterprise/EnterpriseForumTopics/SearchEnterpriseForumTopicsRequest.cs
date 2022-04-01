namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumTopics;

public class SearchEnterpriseForumTopicsRequest : PaginationFilter, IRequest<PaginationResponse<EnterpriseForumTopicDto>>
{
    public Guid? EnterpriseForumCategoryId { get; set; }

}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<EnterpriseForumTopic, EnterpriseForumTopicDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchEnterpriseForumTopicsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy())
        .Include(p => p.EnterpriseForumCategory)
        .Where(p => p.EnterpriseForumCategoryId.Equals(request.EnterpriseForumCategoryId!.Value), request.EnterpriseForumCategoryId.HasValue)
        ;
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchEnterpriseForumTopicsRequest, PaginationResponse<EnterpriseForumTopicDto>>
{
    private readonly IReadRepository<EnterpriseForumTopic> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<EnterpriseForumTopic> repository) => _repository = repository;

    public async Task<PaginationResponse<EnterpriseForumTopicDto>> Handle(SearchEnterpriseForumTopicsRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<EnterpriseForumTopicDto>(list, count, request.PageNumber, request.PageSize);
    }
}