namespace TD.CitizenAPI.Application.Catalog.Trips;

public class CreateTripRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public Guid? VehicleId { get; set; }

    public string? DeparturePlaceName { get; set; }
    public double? DepartureLatitude { get; set; }
    public double? DepartureLongitude { get; set; }
    public Guid? DepartureProvinceId { get; set; }
    public Guid? DepartureDistrictId { get; set; }
    public Guid? DepartureCommuneId { get; set; }

    /// <summary>
    /// Diem den
    /// </summary>
    public string? ArrivalPlaceName { get; set; }
    public double? ArrivalLatitude { get; set; }
    public double? ArrivalLongitude { get; set; }
    public Guid? ArrivalProvinceId { get; set; }
    public Guid? ArrivalDistrictId { get; set; }
    public Guid? ArrivalCommuneId { get; set; }

    /// <summary>
    /// Gia ve
    /// </summary>
    public int? Price { get; set; }

    /// <summary>
    /// Thoi gian xuat phat
    /// </summary>
    public string? TimeStart { get; set; }
    public string? Frequency { get; set; }

    /// <summary>
    /// Thoi gian du kien cua chuyen di
    /// </summary>
    public int? Duration { get; set; }
    public bool? Status { get; set; }

}

public class CreateTripRequestValidator : CustomValidator<CreateTripRequest>
{
    public CreateTripRequestValidator(IReadRepository<Trip> repository, IStringLocalizer<CreateTripRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateTripRequestHandler : IRequestHandler<CreateTripRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Trip> _repository;

    public CreateTripRequestHandler(IRepositoryWithEvents<Trip> repository) => (_repository) = (repository);

    public async Task<Result<Guid>> Handle(CreateTripRequest request, CancellationToken cancellationToken)
    {
        var item = new Trip(request.Name, request.Description, request.VehicleId, request.DeparturePlaceName, request.DepartureLatitude, request.DepartureLongitude, request.DepartureProvinceId, request.DepartureDistrictId, request.DepartureCommuneId, request.ArrivalPlaceName, request.ArrivalLatitude, request.ArrivalLongitude, request.ArrivalProvinceId, request.ArrivalDistrictId, request.ArrivalCommuneId, request.Price, request.TimeStart, request.Frequency, request.Duration, request.Status);

        return Result<Guid>.Success(item.Id);
    }
}