namespace TD.CitizenAPI.Application.Catalog.Trips;

public class UpdateTripRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; };
    public string? Description { get; set; }
    public Guid? VehicleId { get; set; }

    public string? DeparturePlaceName { get; set; }
    public double? DepartureLatitude { get; set; }
    public double? DepartureLongitude { get; set; }
    public Guid? DepartureProvinceId { get; set; }
    public Guid? DepartureDistrictId { get; set; }
    public Guid? DepartureCommuneId { get; set; }

    //Diem den
    public string? ArrivalPlaceName { get; set; }
    public double? ArrivalLatitude { get; set; }
    public double? ArrivalLongitude { get; set; }
    public Guid? ArrivalProvinceId { get; set; }
    public Guid? ArrivalDistrictId { get; set; }
    public Guid? ArrivalCommuneId { get; set; }

    //Gia ve
    public int? Price { get; set; }
    //Thoi gian xuat phat
    public string? TimeStart { get; set; }
    public string? Frequency { get; set; }
    //Thoi gian du kien cua chuyen di
    public int? Duration { get; set; }
    public bool? Status { get; set; }
}

public class UpdateTripRequestValidator : CustomValidator<UpdateTripRequest>
{
    public UpdateTripRequestValidator(IRepository<Trip> repository, IStringLocalizer<UpdateTripRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateTripRequestHandler : IRequestHandler<UpdateTripRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Trip> _repository;
    private readonly IStringLocalizer<UpdateTripRequestHandler> _localizer;

    public UpdateTripRequestHandler(IRepositoryWithEvents<Trip> repository, IStringLocalizer<UpdateTripRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateTripRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["Trip.notfound"], request.Id));

        item.Update(request.Name, request.Description, request.VehicleId, request.DeparturePlaceName, request.DepartureLatitude, request.DepartureLongitude, request.DepartureProvinceId, request.DepartureDistrictId, request.DepartureCommuneId, request.ArrivalPlaceName, request.ArrivalLatitude, request.ArrivalLongitude, request.ArrivalProvinceId, request.ArrivalDistrictId, request.ArrivalCommuneId, request.Price, request.TimeStart, request.Frequency, request.Duration, request.Status);

        await _repository.UpdateAsync(item, cancellationToken);


        return Result<Guid>.Success(request.Id);
    }
}