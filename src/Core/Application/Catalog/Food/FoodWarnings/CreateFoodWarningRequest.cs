namespace TD.CitizenAPI.Application.Catalog.FoodWarnings;

public partial class CreateFoodWarningRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
}

public class CreateFoodWarningRequestValidator : CustomValidator<CreateFoodWarningRequest>
{
    public CreateFoodWarningRequestValidator(IReadRepository<FoodWarning> repository, IStringLocalizer<CreateFoodWarningRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateFoodWarningRequestHandler : IRequestHandler<CreateFoodWarningRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FoodWarning> _repository;

    public CreateFoodWarningRequestHandler(IRepositoryWithEvents<FoodWarning> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateFoodWarningRequest request, CancellationToken cancellationToken)
    {
        var item = new FoodWarning(request.Name, request.Code, request.Image, request.Images, request.Description, request.Content);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}