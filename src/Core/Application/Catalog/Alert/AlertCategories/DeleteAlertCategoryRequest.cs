
namespace TD.CitizenAPI.Application.Catalog.AlertCategories;

public class DeleteAlertCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteAlertCategoryRequest(Guid id) => Id = id;
}

public class DeleteAlertCategoryRequestHandler : IRequestHandler<DeleteAlertCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AlertCategory> _alertCategoryRepo;
    private readonly IStringLocalizer<DeleteAlertCategoryRequestHandler> _localizer;

    public DeleteAlertCategoryRequestHandler(IRepositoryWithEvents<AlertCategory> alertCategoryRepo, IStringLocalizer<DeleteAlertCategoryRequestHandler> localizer) =>
        (_alertCategoryRepo, _localizer) = (alertCategoryRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteAlertCategoryRequest request, CancellationToken cancellationToken)
    {


        var item = await _alertCategoryRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["AlertCategory.notfound"]);

        await _alertCategoryRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}