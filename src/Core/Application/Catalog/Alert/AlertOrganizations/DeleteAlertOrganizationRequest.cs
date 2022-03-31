
namespace TD.CitizenAPI.Application.Catalog.AlertOrganizations;

public class DeleteAlertOrganizationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteAlertOrganizationRequest(Guid id) => Id = id;
}

public class DeleteAlertOrganizationRequestHandler : IRequestHandler<DeleteAlertOrganizationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AlertOrganization> _AlertOrganizationRepo;
    private readonly IStringLocalizer<DeleteAlertOrganizationRequestHandler> _localizer;

    public DeleteAlertOrganizationRequestHandler(IRepositoryWithEvents<AlertOrganization> AlertOrganizationRepo, IStringLocalizer<DeleteAlertOrganizationRequestHandler> localizer) =>
        (_AlertOrganizationRepo, _localizer) = (AlertOrganizationRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteAlertOrganizationRequest request, CancellationToken cancellationToken)
    {


        var item = await _AlertOrganizationRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["AlertOrganization.notfound"]);

        await _AlertOrganizationRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}