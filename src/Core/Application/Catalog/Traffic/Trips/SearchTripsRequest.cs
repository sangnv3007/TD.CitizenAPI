namespace TD.CitizenAPI.Application.Catalog.Trips;

public class SearchTripsRequest : PaginationFilter, IRequest<PaginationResponse<TripDto>>
{
    public Guid? AreaId { get; set; }
    public Guid? AreaDepartureId { get; set; }
    public Guid? AreaArrivalId { get; set; }
    public Guid? VehicleTypeId { get; set; }
    public Guid? VehicleId { get; set; }

    public string? TimeStartFrom { get; set; }
    public string? TimeStartTo { get; set; }
}

public class SearchTripsRequestHandler : IRequestHandler<SearchTripsRequest, PaginationResponse<TripDto>>
{
    private readonly IReadRepository<Trip> _repository;

    public SearchTripsRequestHandler(IReadRepository<Trip> repository) => _repository = repository;

    public async Task<PaginationResponse<TripDto>> Handle(SearchTripsRequest request, CancellationToken cancellationToken)
    {
        var spec = new TripsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<TripDto>(list, count, request.PageNumber, request.PageSize);
    }
}