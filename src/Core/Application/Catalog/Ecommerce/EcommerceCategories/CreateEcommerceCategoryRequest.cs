namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class CreateEcommerceCategoryRequest : IRequest<Result<Guid>>
{
    public Guid? ParentId { get; set; }
    public string Name { get; set; } = default!;
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public int? Position { get; set; }
    public bool? IncludeInMenu { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string[]? Tags { get; set; }

}

public class CreateEcommerceCategoryRequestValidator : CustomValidator<CreateEcommerceCategoryRequest>
{
    public CreateEcommerceCategoryRequestValidator(IReadRepository<EcommerceCategory> repository, IStringLocalizer<CreateEcommerceCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateEcommerceCategoryRequestHandler : IRequestHandler<CreateEcommerceCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EcommerceCategory> _repository;
    private readonly IStringLocalizer<CreateEcommerceCategoryRequestHandler> _localizer;

    public CreateEcommerceCategoryRequestHandler(IRepositoryWithEvents<EcommerceCategory> repository, IStringLocalizer<CreateEcommerceCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(CreateEcommerceCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = new EcommerceCategory(request.ParentId, request.Name, request.Slug, request.Description, request.MetaTitle, request.MetaDescription, request.Position, request.IncludeInMenu, 1, request.Icon, request.Image, request.Tags, 1, true);


        if (request.ParentId == null)
        {
            item.Level = 1;
        }
        else
        {
            var category = await _repository.GetByIdAsync(request.ParentId, cancellationToken);
            _ = category ?? throw new NotFoundException(_localizer["parentecommercecategory.notfound"]);

            item.Level = category.Level + 1;

        }
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}