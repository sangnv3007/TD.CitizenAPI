namespace TD.CitizenAPI.Application.Catalog.Vehicles;

public class SearchVehiclesRequest : PaginationFilter, IRequest<PaginationResponse<VehicleDto>>
{
    public Guid? CompanyId { get; set; }
    public Guid? VehicleTypeId { get; set; }
}

public class VehiclesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Vehicle, VehicleDto>
{
    public VehiclesBySearchRequestSpec(SearchVehiclesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy())
        .Where(p => p.CompanyId.Equals(request.CompanyId!.Value), request.CompanyId.HasValue)
        .Where(p => p.VehicleTypeId.Equals(request.VehicleTypeId!.Value), request.VehicleTypeId.HasValue)
        .Include(p => p.Company).Include(p => p.VehicleType);
}

public class SearchVehiclesRequestHandler : IRequestHandler<SearchVehiclesRequest, PaginationResponse<VehicleDto>>
{
    private readonly IReadRepository<Vehicle> _repository;

    public SearchVehiclesRequestHandler(IReadRepository<Vehicle> repository) => _repository = repository;

    public async Task<PaginationResponse<VehicleDto>> Handle(SearchVehiclesRequest request, CancellationToken cancellationToken)
    {
        var spec = new VehiclesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<VehicleDto>(list, count, request.PageNumber, request.PageSize);
    }
}