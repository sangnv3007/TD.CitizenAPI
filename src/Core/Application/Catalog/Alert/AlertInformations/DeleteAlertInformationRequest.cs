
namespace TD.CitizenAPI.Application.Catalog.AlertInformations;

public class DeleteAlertInformationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteAlertInformationRequest(Guid id) => Id = id;
}

public class DeleteAlertInformationRequestHandler : IRequestHandler<DeleteAlertInformationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AlertInformation> _AlertInformationRepo;
    private readonly IStringLocalizer<DeleteAlertInformationRequestHandler> _localizer;

    public DeleteAlertInformationRequestHandler(IRepositoryWithEvents<AlertInformation> AlertInformationRepo, IStringLocalizer<DeleteAlertInformationRequestHandler> localizer) =>
        (_AlertInformationRepo, _localizer) = (AlertInformationRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteAlertInformationRequest request, CancellationToken cancellationToken)
    {


        var item = await _AlertInformationRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["AlertInformation.notfound"]);

        await _AlertInformationRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}