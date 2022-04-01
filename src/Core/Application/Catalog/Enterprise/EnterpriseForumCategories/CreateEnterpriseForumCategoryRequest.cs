namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumCategories;

public partial class CreateEnterpriseForumCategoryRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class CreateEnterpriseForumCategoryRequestValidator : CustomValidator<CreateEnterpriseForumCategoryRequest>
{
    public CreateEnterpriseForumCategoryRequestValidator(IReadRepository<EnterpriseForumCategory> repository, IStringLocalizer<CreateEnterpriseForumCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateEnterpriseForumCategoryRequestHandler : IRequestHandler<CreateEnterpriseForumCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EnterpriseForumCategory> _repository;

    public CreateEnterpriseForumCategoryRequestHandler(IRepositoryWithEvents<EnterpriseForumCategory> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateEnterpriseForumCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = new EnterpriseForumCategory(request.Name, request.Code, request.Icon, request.Image, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}