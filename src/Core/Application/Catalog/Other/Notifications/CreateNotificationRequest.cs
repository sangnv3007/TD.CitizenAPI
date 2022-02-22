using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.Notifications;

public class CreateNotificationRequest : IRequest<Result<Guid>>
{
    public string? UserName { get; set; }
    public string? Body { get; set; }
    public bool? IsRead { get; set; }
    public string? Title { get; set; }
    public string? Data { get; set; }
    public string? AppType { get; set; }
    public string? Code { get; set; }
    public string? AreaCode { get; set; }
}

public class CreateNotificationRequestValidator : CustomValidator<CreateNotificationRequest>
{
    public CreateNotificationRequestValidator(IReadRepository<Notification> repository, IStringLocalizer<CreateNotificationRequestValidator> localizer) =>
        RuleFor(p => p.Title).NotEmpty();
}

public class CreateCategoryRequestHandler : IRequestHandler<CreateNotificationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Notification> _repository;

    public CreateCategoryRequestHandler(IRepositoryWithEvents<Notification> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateNotificationRequest request, CancellationToken cancellationToken)
    {
        var item = new Notification(request.UserName, request.Body, false, request.Title, request.Data, request.AppType, request.Code, request.AreaCode);
        item.DomainEvents.Add(EntityCreatedEvent.WithEntity(item));

        await _repository.AddAsync(item, cancellationToken);

        return Result<Guid>.Success(item.Id);
    }
}