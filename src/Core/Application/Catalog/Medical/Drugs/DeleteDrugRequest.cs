
namespace TD.CitizenAPI.Application.Catalog.Drugs;

public class DeleteDrugRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteDrugRequest(Guid id) => Id = id;
}

public class DeleteDrugRequestHandler : IRequestHandler<DeleteDrugRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Drug> _DrugRepo;
    private readonly IStringLocalizer<DeleteDrugRequestHandler> _localizer;

    public DeleteDrugRequestHandler(IRepositoryWithEvents<Drug> DrugRepo, IStringLocalizer<DeleteDrugRequestHandler> localizer) =>
        (_DrugRepo,  _localizer) = (DrugRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteDrugRequest request, CancellationToken cancellationToken)
    {
        

        var item = await _DrugRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Drug.notfound"]);

        await _DrugRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}