namespace TD.CitizenAPI.Application.Catalog.Vehicles;

public class CreateVehicleRequest : IRequest<Result<Guid>>
{
    public string? UserName { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? DriverName { get; set; }
    public string? DriverPhone { get; set; }
    public string? Icon { get; set; }
    //So ghe
    public int? SeatLimit { get; set; }
    //Trang thai su dung
    public bool? Status { get; set; }
    //Loai ghe
    public string? SeatType { get; set; }
    //Bien so xe
    public string? RegistrationPlate { get; set; }

    public Guid? VehicleTypeId { get; set; }
    public Guid? CompanyId { get; set; }

    public virtual ICollection<Guid>? CarUtilities { get; set; }
}

public class CreateVehicleRequestValidator : CustomValidator<CreateVehicleRequest>
{
    public CreateVehicleRequestValidator(IReadRepository<Vehicle> repository, IStringLocalizer<CreateVehicleRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateVehicleRequestHandler : IRequestHandler<CreateVehicleRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Vehicle> _repository;
    private readonly IRepositoryWithEvents<VehicleCarUtility> _vehicleCarUtilitRepository;

    public CreateVehicleRequestHandler(IRepositoryWithEvents<Vehicle> repository, IRepositoryWithEvents<VehicleCarUtility> vehicleCarUtilitRepository) => (_repository, _vehicleCarUtilitRepository) = (repository, vehicleCarUtilitRepository);

    public async Task<Result<Guid>> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        var item = new Vehicle(request.UserName,request.Name, request.Description, request.Image, request.Images, request.DriverPhone, request.DriverPhone, request.Icon, request.SeatLimit, request.Status, request.SeatType, request.RegistrationPlate, request.VehicleTypeId, request.CompanyId);
        await _repository.AddAsync(item, cancellationToken);


        if (request.CarUtilities != null)
        {
            foreach (var industryId in request.CarUtilities)
            {
                try
                {
                    var companyIndustry = new VehicleCarUtility(item.Id, industryId);
                    await _vehicleCarUtilitRepository.AddAsync(companyIndustry, cancellationToken);
                }
                catch
                {

                }
            }
        }

        return Result<Guid>.Success(item.Id);
    }
}