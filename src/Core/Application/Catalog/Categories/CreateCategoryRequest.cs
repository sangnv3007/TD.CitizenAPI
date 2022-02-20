using Mapster;

namespace TD.CitizenAPI.Application.Catalog.Categories;

public partial class CreateCategoryRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
}

public class CreateCategoryRequestValidator : CustomValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator(IReadRepository<Category> repository, IStringLocalizer<CreateCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(256)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new CategoryByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["category.alreadyexists"], name));
}

public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Category> _repository;

    public CreateCategoryRequestHandler(IRepositoryWithEvents<Category> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        //var item = request.Adapt<Category>();
        var item = new Category(request.Name, request.Code, request.Icon, request.Image, request.CoverImage, request.Description);


        await _repository.AddAsync(item, cancellationToken);

        return Result<Guid>.Success(item.Id);
    }
}