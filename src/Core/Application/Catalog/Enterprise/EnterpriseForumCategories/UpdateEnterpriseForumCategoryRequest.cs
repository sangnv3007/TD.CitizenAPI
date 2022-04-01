namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumCategories;

public class UpdateEnterpriseForumCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class UpdateEnterpriseForumCategoryRequestValidator : CustomValidator<UpdateEnterpriseForumCategoryRequest>
{
    public UpdateEnterpriseForumCategoryRequestValidator(IRepository<EnterpriseForumCategory> repository, IStringLocalizer<UpdateEnterpriseForumCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateEnterpriseForumCategoryRequestHandler : IRequestHandler<UpdateEnterpriseForumCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EnterpriseForumCategory> _repository;
    private readonly IStringLocalizer<UpdateEnterpriseForumCategoryRequestHandler> _localizer;

    public UpdateEnterpriseForumCategoryRequestHandler(IRepositoryWithEvents<EnterpriseForumCategory> repository, IStringLocalizer<UpdateEnterpriseForumCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateEnterpriseForumCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["EnterpriseForumCategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.Image, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}