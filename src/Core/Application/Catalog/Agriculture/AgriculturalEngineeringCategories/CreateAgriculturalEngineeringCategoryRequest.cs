namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineeringCategories;

public partial class CreateAgriculturalEngineeringCategoryRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
}

public class CreateAgriculturalEngineeringCategoryRequestValidator : CustomValidator<CreateAgriculturalEngineeringCategoryRequest>
{
    public CreateAgriculturalEngineeringCategoryRequestValidator(IReadRepository<AgriculturalEngineeringCategory> repository, IStringLocalizer<CreateAgriculturalEngineeringCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateAgriculturalEngineeringCategoryRequestHandler : IRequestHandler<CreateAgriculturalEngineeringCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AgriculturalEngineeringCategory> _repository;

    public CreateAgriculturalEngineeringCategoryRequestHandler(IRepositoryWithEvents<AgriculturalEngineeringCategory> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateAgriculturalEngineeringCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = new AgriculturalEngineeringCategory(request.Name, request.Code, request.Icon, request.Image, request.CoverImage,request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}