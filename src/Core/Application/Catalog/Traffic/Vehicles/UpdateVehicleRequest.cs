namespace TD.CitizenAPI.Application.Catalog.Vehicles;

public class UpdateVehicleRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
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

public class UpdateVehicleRequestValidator : CustomValidator<UpdateVehicleRequest>
{
    public UpdateVehicleRequestValidator(IRepository<Vehicle> repository, IStringLocalizer<UpdateVehicleRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateVehicleRequestHandler : IRequestHandler<UpdateVehicleRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Vehicle> _repository;
    private readonly IStringLocalizer<UpdateVehicleRequestHandler> _localizer;
    private readonly IRepositoryWithEvents<VehicleCarUtility> _vehicleCarUtilitRepository;

    public UpdateVehicleRequestHandler(IRepositoryWithEvents<Vehicle> repository, IRepositoryWithEvents<VehicleCarUtility> vehicleCarUtilitRepository, IStringLocalizer<UpdateVehicleRequestHandler> localizer) =>
        (_repository, _vehicleCarUtilitRepository, _localizer) = (repository, vehicleCarUtilitRepository, localizer);

    public async Task<Result<Guid>> Handle(UpdateVehicleRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["vehicle.notfound"], request.Id));

        item.Update(request.UserName, request.Name, request.Description, request.Image, request.Images, request.DriverPhone, request.DriverPhone, request.Icon, request.SeatLimit, request.Status, request.SeatType, request.RegistrationPlate, request.VehicleTypeId, request.CompanyId);

        await _repository.UpdateAsync(item, cancellationToken);


        var item_CompanyIndustries = await _vehicleCarUtilitRepository.ListAsync(new VehicleCarUtilitiesByVehicleSpec(item.Id), cancellationToken);

        if (item_CompanyIndustries != null && item_CompanyIndustries.Count > 0)
        {
            await _vehicleCarUtilitRepository.DeleteRangeAsync(item_CompanyIndustries);

        }

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

        return Result<Guid>.Success(request.Id);
    }
}