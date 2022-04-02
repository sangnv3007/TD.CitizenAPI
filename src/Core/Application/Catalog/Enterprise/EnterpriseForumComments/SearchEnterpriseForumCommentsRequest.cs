using TD.CitizenAPI.Application.Identity.Users;

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
    private readonly IUserService _userService;

    public SearchAlertCategoriesRequestHandler(IReadRepository<EnterpriseForumComment> repository, IUserService userService) => (_repository, _userService) = (repository, userService);

    public async Task<PaginationResponse<EnterpriseForumCommentDto>> Handle(SearchEnterpriseForumCommentsRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        foreach (var item in list)
        {
            if (item != null && !string.IsNullOrWhiteSpace(item.UserName))
            {
                var tmp = await _userService.GetAsyncByUserName(item.UserName, cancellationToken);
                item.FullName = tmp.FullName;
                item.ImageUrl = tmp.ImageUrl;
                item.PhoneNumber = tmp.PhoneNumber;
            }
        }

        return new PaginationResponse<EnterpriseForumCommentDto>(list, count, request.PageNumber, request.PageSize);
    }
}