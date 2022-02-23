namespace TD.CitizenAPI.Application.Catalog.TripRoutes;

public class UpdateTripRouteRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
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

public class UpdateTripRouteRequestValidator : CustomValidator<UpdateTripRouteRequest>
{
    public UpdateTripRouteRequestValidator(IRepository<TripRoute> repository, IStringLocalizer<UpdateTripRouteRequestValidator> localizer) =>
        RuleFor(p => p.Type)
            .NotEmpty();
}

public class UpdateTripRouteRequestHandler : IRequestHandler<UpdateTripRouteRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<TripRoute> _repository;
    private readonly IStringLocalizer<UpdateTripRouteRequestHandler> _localizer;

    public UpdateTripRouteRequestHandler(IRepositoryWithEvents<TripRoute> repository, IStringLocalizer<UpdateTripRouteRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateTripRouteRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["Trip.notfound"], request.Id));

        item.Update(request.Type, request.Description, request.TripId, request.PlaceName, request.Latitude, request.Longitude, request.ProvinceId, request.DistrictId, request.CommuneId, request.Duration, request.Status);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}