namespace TD.CitizenAPI.Application.Catalog.TripRoutes;

public class CreateTripRouteRequest : IRequest<Result<Guid>>
{
    public string? Type { get; set; }
    public string? Description { get; set; }
    public Guid? TripId { get; set; }
    public string? PlaceName { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
    public int? Duration { get; set; }
    public bool? Status { get; set; }


}

public class CreateTripRouteRequestValidator : CustomValidator<CreateTripRouteRequest>
{
    public CreateTripRouteRequestValidator(IReadRepository<TripRoute> repository, IStringLocalizer<CreateTripRouteRequestValidator> localizer) =>
        RuleFor(p => p.Type).NotEmpty();
}

public class CreateTripRouteRequestHandler : IRequestHandler<CreateTripRouteRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<TripRoute> _repository;

    public CreateTripRouteRequestHandler(IRepositoryWithEvents<TripRoute> repository) => (_repository) = (repository);

    public async Task<Result<Guid>> Handle(CreateTripRouteRequest request, CancellationToken cancellationToken)
    {
        var item = new TripRoute(request.Type, request.Description, request.TripId, request.PlaceName, request.Latitude, request.Longitude, request.ProvinceId, request.DistrictId, request.CommuneId, request.Duration, request.Status);
        await _repository.AddAsync(item, cancellationToken);

        return Result<Guid>.Success(item.Id);
    }
}