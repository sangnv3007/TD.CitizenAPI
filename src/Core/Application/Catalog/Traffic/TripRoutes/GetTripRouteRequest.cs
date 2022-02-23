namespace TD.CitizenAPI.Application.Catalog.TripRoutes;

public class GetTripRouteRequest : IRequest<Result<TripRouteDetailsDto>>
{
    public Guid Id { get; set; }

    public GetTripRouteRequest(Guid id) => Id = id;
}

public class TripRouteByIdSpec : Specification<TripRoute, TripRouteDetailsDto>, ISingleResultSpecification
{
    public TripRouteByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.Province)
        .Include(p => p.District)
        .Include(p => p.Commune)
        .Include(p => p.Trip)
        ;
}

public class GetTripRouteRequestHandler : IRequestHandler<GetTripRouteRequest, Result<TripRouteDetailsDto>>
{
    private readonly IRepository<TripRoute> _repository;
    private readonly IStringLocalizer<GetTripRouteRequestHandler> _localizer;

    public GetTripRouteRequestHandler(IRepository<TripRoute> repository, IStringLocalizer<GetTripRouteRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<TripRouteDetailsDto>> Handle(GetTripRouteRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<TripRoute, TripRouteDetailsDto>)new TripRouteByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["TripRoute.notfound"], request.Id));
        return Result<TripRouteDetailsDto>.Success(item);

    }
}