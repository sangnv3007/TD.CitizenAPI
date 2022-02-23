namespace TD.CitizenAPI.Application.Catalog.Vehicles;

public class DeleteVehicleRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteVehicleRequest(Guid id) => Id = id;
}

public class DeleteVehicleRequestHandler : IRequestHandler<DeleteVehicleRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Vehicle> _repository;
    private readonly IStringLocalizer<DeleteVehicleRequestHandler> _localizer;

    public DeleteVehicleRequestHandler(IRepositoryWithEvents<Vehicle> repository,  IStringLocalizer<DeleteVehicleRequestHandler> localizer) =>
        (_repository,  _localizer) = (repository,  localizer);

    public async Task<Result<Guid>> Handle(DeleteVehicleRequest request, CancellationToken cancellationToken)
    {
 

        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Vehicle.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}