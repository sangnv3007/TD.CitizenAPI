namespace TD.CitizenAPI.Application.Catalog.Notifications;

public class GetNotificationRequest : IRequest<Result<NotificationDetailsDto>>
{
    public Guid Id { get; set; }

    public GetNotificationRequest(Guid id) => Id = id;
}

public class NotificationByIdSpec : Specification<Notification, NotificationDetailsDto>, ISingleResultSpecification
{
    public NotificationByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetNotificationRequestHandler : IRequestHandler<GetNotificationRequest, Result<NotificationDetailsDto>>
{
    private readonly IRepository<Notification> _repository;
    private readonly IStringLocalizer<GetNotificationRequestHandler> _localizer;

    public GetNotificationRequestHandler(IRepository<Notification> repository, IStringLocalizer<GetNotificationRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<NotificationDetailsDto>> Handle(GetNotificationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Notification, NotificationDetailsDto>)new NotificationByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["notification.notfound"], request.Id));
        return Result<NotificationDetailsDto>.Success(item);

    }
}