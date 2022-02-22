namespace TD.CitizenAPI.Application.Catalog.HotlineCategories;

public class UpdateHotlineCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
}

public class UpdateHotlineCategoryRequestValidator : CustomValidator<UpdateHotlineCategoryRequest>
{
    public UpdateHotlineCategoryRequestValidator(IRepository<HotlineCategory> repository, IStringLocalizer<UpdateHotlineCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateHotlineCategoryRequestHandler : IRequestHandler<UpdateHotlineCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<HotlineCategory> _repository;
    private readonly IStringLocalizer<UpdateHotlineCategoryRequestHandler> _localizer;

    public UpdateHotlineCategoryRequestHandler(IRepositoryWithEvents<HotlineCategory> repository, IStringLocalizer<UpdateHotlineCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateHotlineCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["hotlinecategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.Image, request.CoverImage, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}