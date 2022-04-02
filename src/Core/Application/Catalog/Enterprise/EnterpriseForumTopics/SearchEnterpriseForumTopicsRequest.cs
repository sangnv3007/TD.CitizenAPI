using TD.CitizenAPI.Application.Identity.Users;

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
    private readonly IUserService _userService;

    public SearchAlertCategoriesRequestHandler(IReadRepository<EnterpriseForumTopic> repository, IUserService userService) => (_repository, _userService) = (repository, userService);

    public async Task<PaginationResponse<EnterpriseForumTopicDto>> Handle(SearchEnterpriseForumTopicsRequest request, CancellationToken cancellationToken)
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

        return new PaginationResponse<EnterpriseForumTopicDto>(list, count, request.PageNumber, request.PageSize);
    }
}