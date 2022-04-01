namespace TD.CitizenAPI.Application.Catalog.ProjectInvestCategories;

public class UpdateProjectInvestCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class UpdateProjectInvestCategoryRequestValidator : CustomValidator<UpdateProjectInvestCategoryRequest>
{
    public UpdateProjectInvestCategoryRequestValidator(IRepository<ProjectInvestCategory> repository, IStringLocalizer<UpdateProjectInvestCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateProjectInvestCategoryRequestHandler : IRequestHandler<UpdateProjectInvestCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProjectInvestCategory> _repository;
    private readonly IStringLocalizer<UpdateProjectInvestCategoryRequestHandler> _localizer;

    public UpdateProjectInvestCategoryRequestHandler(IRepositoryWithEvents<ProjectInvestCategory> repository, IStringLocalizer<UpdateProjectInvestCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateProjectInvestCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["ProjectInvestCategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.Image, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}