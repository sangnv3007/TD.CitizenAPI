namespace TD.CitizenAPI.Application.Catalog.ProjectInvestForms;

public partial class CreateProjectInvestFormRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class CreateProjectInvestFormRequestValidator : CustomValidator<CreateProjectInvestFormRequest>
{
    public CreateProjectInvestFormRequestValidator(IReadRepository<ProjectInvestForm> repository, IStringLocalizer<CreateProjectInvestFormRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateProjectInvestFormRequestHandler : IRequestHandler<CreateProjectInvestFormRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProjectInvestForm> _repository;

    public CreateProjectInvestFormRequestHandler(IRepositoryWithEvents<ProjectInvestForm> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateProjectInvestFormRequest request, CancellationToken cancellationToken)
    {
        var item = new ProjectInvestForm(request.Name, request.Code, request.Icon, request.Image, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}