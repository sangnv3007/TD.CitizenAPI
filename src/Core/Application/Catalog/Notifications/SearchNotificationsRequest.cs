namespace TD.CitizenAPI.Application.Catalog.Notifications;

public class SearchNotificationsRequest : PaginationFilter, IRequest<PaginationResponse<NotificationDto>>
{
    public string? UserName { get; set; }
    public bool? IsRead { get; set; }
    public string? AreaCode { get; set; }
    public string? AppType { get; set; }

}

public class HomePageInforsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Notification, NotificationDto>
{
    public HomePageInforsBySearchRequestSpec(SearchNotificationsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Title, !request.HasOrderBy())
        .Where(p => p.UserName == request.UserName, request.UserName is not null)
        .Where(p => p.IsRead == request.IsRead, request.IsRead is not null)
        .Where(p => p.AreaCode == request.AreaCode, request.AreaCode is not null)
        .Where(p => p.AppType == request.AppType, request.AppType is not null)
        ;
}

public class SearchCategoriesRequestHandler : IRequestHandler<SearchNotificationsRequest, PaginationResponse<NotificationDto>>
{
    private readonly IReadRepository<Notification> _repository;

    public SearchCategoriesRequestHandler(IReadRepository<Notification> repository) => _repository = repository;

    public async Task<PaginationResponse<NotificationDto>> Handle(SearchNotificationsRequest request, CancellationToken cancellationToken)
    {
        var spec = new HomePageInforsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<NotificationDto>(list, count, request.PageNumber, request.PageSize);
    }
}