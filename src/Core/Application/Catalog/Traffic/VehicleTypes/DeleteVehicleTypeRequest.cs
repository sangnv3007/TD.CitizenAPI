using TD.CitizenAPI.Application.Catalog.Carpools;

namespace TD.CitizenAPI.Application.Catalog.VehicleTypes;

public class DeleteVehicleTypeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteVehicleTypeRequest(Guid id) => Id = id;
}

public class DeleteVehicleTypeRequestHandler : IRequestHandler<DeleteVehicleTypeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<VehicleType> _repository;
    private readonly IReadRepository<Carpool> _carpoolRepo;
    private readonly IStringLocalizer<DeleteVehicleTypeRequestHandler> _localizer;

    public DeleteVehicleTypeRequestHandler(IRepositoryWithEvents<VehicleType> repository, IReadRepository<Carpool> carpoolRepo, IStringLocalizer<DeleteVehicleTypeRequestHandler> localizer) =>
        (_repository, _carpoolRepo, _localizer) = (repository, carpoolRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteVehicleTypeRequest request, CancellationToken cancellationToken)
    {
        if (await _carpoolRepo.AnyAsync(new CarpoolByVehicleTypeSpec(request.Id), cancellationToken))
        {
            throw new ConflictException(_localizer["vehicletype.cannotbedeleted"]);
        }

        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["vehicletype.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}