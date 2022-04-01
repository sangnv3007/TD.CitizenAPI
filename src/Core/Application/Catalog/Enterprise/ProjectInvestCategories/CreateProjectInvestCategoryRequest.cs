namespace TD.CitizenAPI.Application.Catalog.ProjectInvestCategories;

public partial class CreateProjectInvestCategoryRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class CreateProjectInvestCategoryRequestValidator : CustomValidator<CreateProjectInvestCategoryRequest>
{
    public CreateProjectInvestCategoryRequestValidator(IReadRepository<ProjectInvestCategory> repository, IStringLocalizer<CreateProjectInvestCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateProjectInvestCategoryRequestHandler : IRequestHandler<CreateProjectInvestCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProjectInvestCategory> _repository;

    public CreateProjectInvestCategoryRequestHandler(IRepositoryWithEvents<ProjectInvestCategory> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateProjectInvestCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = new ProjectInvestCategory(request.Name, request.Code, request.Icon, request.Image, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}