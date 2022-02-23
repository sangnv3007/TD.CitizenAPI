namespace TD.CitizenAPI.Application.Catalog.CarUtilities;

public class CreateCarUtilityRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
}

public class CreateCarUtilityRequestValidator : CustomValidator<CreateCarUtilityRequest>
{
    public CreateCarUtilityRequestValidator(IReadRepository<CarUtility> repository, IStringLocalizer<CreateCarUtilityRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateVehicleRequestHandler : IRequestHandler<CreateCarUtilityRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<CarUtility> _repository;

    public CreateVehicleRequestHandler(IRepositoryWithEvents<CarUtility> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateCarUtilityRequest request, CancellationToken cancellationToken)
    {
        var item = new CarUtility(request.Name, request.Code, request.Icon, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}