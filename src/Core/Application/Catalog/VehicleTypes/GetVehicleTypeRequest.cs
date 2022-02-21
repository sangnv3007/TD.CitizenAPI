namespace TD.CitizenAPI.Application.Catalog.VehicleTypes;

public class GetVehicleTypeRequest : IRequest<Result<VehicleTypeDetailsDto>>
{
    public Guid Id { get; set; }

    public GetVehicleTypeRequest(Guid id) => Id = id;
}

public class VehicleTypeByIdSpec : Specification<VehicleType, VehicleTypeDetailsDto>, ISingleResultSpecification
{
    public VehicleTypeByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetMarketCategoryRequestHandler : IRequestHandler<GetVehicleTypeRequest, Result<VehicleTypeDetailsDto>>
{
    private readonly IRepository<VehicleType> _repository;
    private readonly IStringLocalizer<GetMarketCategoryRequestHandler> _localizer;

    public GetMarketCategoryRequestHandler(IRepository<VehicleType> repository, IStringLocalizer<GetMarketCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<VehicleTypeDetailsDto>> Handle(GetVehicleTypeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<VehicleType, VehicleTypeDetailsDto>)new VehicleTypeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["marketcategory.notfound"], request.Id));
        return Result<VehicleTypeDetailsDto>.Success(item);

    }
}