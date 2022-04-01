namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumComments;

public class SearchEnterpriseForumCommentsRequest : PaginationFilter, IRequest<PaginationResponse<EnterpriseForumCommentDto>>
{
    public Guid? EnterpriseForumTopicId { get; set; }

}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<EnterpriseForumComment, EnterpriseForumCommentDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchEnterpriseForumCommentsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy())
        .Include(p => p.EnterpriseForumTopic)
                .Where(p => p.EnterpriseForumTopicId.Equals(request.EnterpriseForumTopicId!.Value), request.EnterpriseForumTopicId.HasValue)

        ;
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchEnterpriseForumCommentsRequest, PaginationResponse<EnterpriseForumCommentDto>>
{
    private readonly IReadRepository<EnterpriseForumComment> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<EnterpriseForumComment> repository) => _repository = repository;

    public async Task<PaginationResponse<EnterpriseForumCommentDto>> Handle(SearchEnterpriseForumCommentsRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<EnterpriseForumCommentDto>(list, count, request.PageNumber, request.PageSize);
    }
}