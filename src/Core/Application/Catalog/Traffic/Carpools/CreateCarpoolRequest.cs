using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.Carpools;

public class CreateCarpoolRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public string? Description { get; set; }
    //Diem khoi hanh
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

    public DateTime? DepartureDate { get; set; }
    public TimeSpan? DepartureTime { get; set; }
    public string? DepartureTimeText { get; set; }
    //Loai phuong tien
    public Guid? VehicleTypeId { get; set; }
    //Vai tro
    public string? Role { get; set; }
    //Gia
    public decimal Price { get; set; }
    //So ghe
    public int SeatCount { get; set; }
    //Trang thai
    public int Status { get; set; }
}

public class CreateCarpoolRequestValidator : CustomValidator<CreateCarpoolRequest>
{
    public CreateCarpoolRequestValidator(IReadRepository<Carpool> repository, IStringLocalizer<CreateCarpoolRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
           ;
}

public class CreateCarpoolRequestHandler : IRequestHandler<CreateCarpoolRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Carpool> _repository;
    private readonly ICurrentUser _currentUser;

    public CreateCarpoolRequestHandler(IRepositoryWithEvents<Carpool> repository, ICurrentUser currentUser) => (_repository, _currentUser) = (repository, currentUser);

    public async Task<Result<Guid>> Handle(CreateCarpoolRequest request, CancellationToken cancellationToken)
    {
        var item = new Carpool(request.Name, request.PhoneNumber, request.UserName ?? _currentUser.GetUserName(), request.Description, request.DeparturePlaceName, request.DepartureLatitude, request.DepartureLongitude, request.DepartureProvinceId, request.DepartureDistrictId, request.DepartureCommuneId, request.ArrivalPlaceName, request.ArrivalLatitude, request.ArrivalLongitude, request.ArrivalProvinceId, request.ArrivalDistrictId, request.ArrivalCommuneId, request.DepartureDate, request.DepartureTime, request.DepartureTimeText, request.VehicleTypeId, request.Role, request.Price, request.SeatCount, request.Status);
        item.DomainEvents.Add(EntityCreatedEvent.WithEntity(item));

        await _repository.AddAsync(item, cancellationToken);

        return Result<Guid>.Success(item.Id);
    }
}