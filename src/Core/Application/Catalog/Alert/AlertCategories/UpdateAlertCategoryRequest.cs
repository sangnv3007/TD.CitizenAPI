namespace TD.CitizenAPI.Application.Catalog.AlertCategories;

public class UpdateAlertCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class UpdateAlertCategoryRequestValidator : CustomValidator<UpdateAlertCategoryRequest>
{
    public UpdateAlertCategoryRequestValidator(IRepository<AlertCategory> repository, IStringLocalizer<UpdateAlertCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateAlertCategoryRequestHandler : IRequestHandler<UpdateAlertCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AlertCategory> _repository;
    private readonly IStringLocalizer<UpdateAlertCategoryRequestHandler> _localizer;

    public UpdateAlertCategoryRequestHandler(IRepositoryWithEvents<AlertCategory> repository, IStringLocalizer<UpdateAlertCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateAlertCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["AlertCategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Image, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}