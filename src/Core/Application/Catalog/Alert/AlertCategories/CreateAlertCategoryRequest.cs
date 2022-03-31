namespace TD.CitizenAPI.Application.Catalog.AlertCategories;

public partial class CreateAlertCategoryRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class CreateAlertCategoryRequestValidator : CustomValidator<CreateAlertCategoryRequest>
{
    public CreateAlertCategoryRequestValidator(IReadRepository<AlertCategory> repository, IStringLocalizer<CreateAlertCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateAlertCategoryRequestHandler : IRequestHandler<CreateAlertCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AlertCategory> _repository;

    public CreateAlertCategoryRequestHandler(IRepositoryWithEvents<AlertCategory> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateAlertCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = new AlertCategory(request.Name, request.Code, request.Image, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}