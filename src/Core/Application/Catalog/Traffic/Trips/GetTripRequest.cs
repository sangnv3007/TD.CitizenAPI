namespace TD.CitizenAPI.Application.Catalog.Trips;

public class GetTripRequest : IRequest<Result<TripDetailsDto>>
{
    public Guid Id { get; set; }

    public GetTripRequest(Guid id) => Id = id;
}

public class TripByIdSpec : Specification<Trip, TripDetailsDto>, ISingleResultSpecification
{
    public TripByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.Vehicle)
        .ThenInclude(p => p.VehicleType)
        .Include(p => p.ArrivalProvince)
        .Include(p => p.ArrivalDistrict)
        .Include(p => p.ArrivalCommune)
        .Include(p => p.DepartureProvince)
        .Include(p => p.DepartureDistrict)
        .Include(p => p.DepartureCommune)
        ;
}

public class GetTripRequestHandler : IRequestHandler<GetTripRequest, Result<TripDetailsDto>>
{
    private readonly IRepository<Trip> _repository;
    private readonly IStringLocalizer<GetTripRequestHandler> _localizer;

    public GetTripRequestHandler(IRepository<Trip> repository, IStringLocalizer<GetTripRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<TripDetailsDto>> Handle(GetTripRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Trip, TripDetailsDto>)new TripByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Trip.notfound"], request.Id));
        return Result<TripDetailsDto>.Success(item);

    }
}