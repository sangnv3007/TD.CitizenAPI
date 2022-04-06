namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineeringCategories;

public class UpdateAgriculturalEngineeringCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
}

public class UpdateAgriculturalEngineeringCategoryRequestValidator : CustomValidator<UpdateAgriculturalEngineeringCategoryRequest>
{
    public UpdateAgriculturalEngineeringCategoryRequestValidator(IRepository<AgriculturalEngineeringCategory> repository, IStringLocalizer<UpdateAgriculturalEngineeringCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateAgriculturalEngineeringCategoryRequestHandler : IRequestHandler<UpdateAgriculturalEngineeringCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AgriculturalEngineeringCategory> _repository;
    private readonly IStringLocalizer<UpdateAgriculturalEngineeringCategoryRequestHandler> _localizer;

    public UpdateAgriculturalEngineeringCategoryRequestHandler(IRepositoryWithEvents<AgriculturalEngineeringCategory> repository, IStringLocalizer<UpdateAgriculturalEngineeringCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateAgriculturalEngineeringCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["AgriculturalEngineeringCategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.Image, request.CoverImage, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}