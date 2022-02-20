namespace TD.CitizenAPI.Application.Catalog.HotlineCategories;

public partial class CreateHotlineCategoryRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
}

public class CreateHotlineCategoryRequestValidator : CustomValidator<CreateHotlineCategoryRequest>
{
    public CreateHotlineCategoryRequestValidator(IReadRepository<HotlineCategory> repository, IStringLocalizer<CreateHotlineCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateHotlineCategoryRequestHandler : IRequestHandler<CreateHotlineCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<HotlineCategory> _repository;

    public CreateHotlineCategoryRequestHandler(IRepositoryWithEvents<HotlineCategory> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateHotlineCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = new HotlineCategory(request.Name, request.Code, request.Icon, request.Image, request.CoverImage, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}