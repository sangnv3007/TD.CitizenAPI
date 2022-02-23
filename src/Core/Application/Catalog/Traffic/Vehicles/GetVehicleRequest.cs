namespace TD.CitizenAPI.Application.Catalog.Vehicles;

public class GetVehicleRequest : IRequest<Result<VehicleDetailsDto>>
{
    public Guid Id { get; set; }

    public GetVehicleRequest(Guid id) => Id = id;
}

public class VehicleByIdSpec : Specification<Vehicle, VehicleDetailsDto>, ISingleResultSpecification
{
    public VehicleByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.Company)
        .Include(p => p.VehicleType)
        .Include(p => p.VehicleCarUtilities).ThenInclude(p => p.CarUtility);
}

public class GetVehicleRequestHandler : IRequestHandler<GetVehicleRequest, Result<VehicleDetailsDto>>
{
    private readonly IRepository<Vehicle> _repository;
    private readonly IStringLocalizer<GetVehicleRequestHandler> _localizer;

    public GetVehicleRequestHandler(IRepository<Vehicle> repository, IStringLocalizer<GetVehicleRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<VehicleDetailsDto>> Handle(GetVehicleRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Vehicle, VehicleDetailsDto>)new VehicleByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Vehicle.notfound"], request.Id));
        return Result<VehicleDetailsDto>.Success(item);

    }
}