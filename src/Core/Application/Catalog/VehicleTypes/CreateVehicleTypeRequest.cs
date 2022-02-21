namespace TD.CitizenAPI.Application.Catalog.VehicleTypes;

public class CreateVehicleTypeRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public int? SeatCount { get; set; }
    public string? Description { get; set; }
}

public class CreateVehicleTypeRequestValidator : CustomValidator<CreateVehicleTypeRequest>
{
    public CreateVehicleTypeRequestValidator(IReadRepository<VehicleType> repository, IStringLocalizer<CreateVehicleTypeRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateVehicleRequestHandler : IRequestHandler<CreateVehicleTypeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<VehicleType> _repository;

    public CreateVehicleRequestHandler(IRepositoryWithEvents<VehicleType> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateVehicleTypeRequest request, CancellationToken cancellationToken)
    {
        var item = new VehicleType(request.Name, request.Code, request.Icon, request.SeatCount, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}