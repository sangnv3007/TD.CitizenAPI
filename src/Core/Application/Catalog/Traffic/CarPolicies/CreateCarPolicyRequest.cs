namespace TD.CitizenAPI.Application.Catalog.CarPolicies;

public class CreateCarPolicyRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
}

public class CreateCarPolicyRequestValidator : CustomValidator<CreateCarPolicyRequest>
{
    public CreateCarPolicyRequestValidator(IReadRepository<CarPolicy> repository, IStringLocalizer<CreateCarPolicyRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateVehicleRequestHandler : IRequestHandler<CreateCarPolicyRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<CarPolicy> _repository;

    public CreateVehicleRequestHandler(IRepositoryWithEvents<CarPolicy> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateCarPolicyRequest request, CancellationToken cancellationToken)
    {
        var item = new CarPolicy(request.Name, request.Code, request.Icon, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}