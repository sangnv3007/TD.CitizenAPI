namespace TD.CitizenAPI.Application.Catalog.VehicleTypes;

public class SearchVehicleTypesRequest : PaginationFilter, IRequest<PaginationResponse<VehicleTypeDto>>
{
}

public class VehicleTypesBySearchRequestSpec : EntitiesByPaginationFilterSpec<VehicleType, VehicleTypeDto>
{
    public VehicleTypesBySearchRequestSpec(SearchVehicleTypesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchVehicleTypesRequestHandler : IRequestHandler<SearchVehicleTypesRequest, PaginationResponse<VehicleTypeDto>>
{
    private readonly IReadRepository<VehicleType> _repository;

    public SearchVehicleTypesRequestHandler(IReadRepository<VehicleType> repository) => _repository = repository;

    public async Task<PaginationResponse<VehicleTypeDto>> Handle(SearchVehicleTypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new VehicleTypesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<VehicleTypeDto>(list, count, request.PageNumber, request.PageSize);
    }
}