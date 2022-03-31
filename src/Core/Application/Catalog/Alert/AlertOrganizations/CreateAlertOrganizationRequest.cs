namespace TD.CitizenAPI.Application.Catalog.AlertOrganizations;

public partial class CreateAlertOrganizationRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class CreateAlertOrganizationRequestValidator : CustomValidator<CreateAlertOrganizationRequest>
{
    public CreateAlertOrganizationRequestValidator(IReadRepository<AlertOrganization> repository, IStringLocalizer<CreateAlertOrganizationRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateAlertOrganizationRequestHandler : IRequestHandler<CreateAlertOrganizationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AlertOrganization> _repository;

    public CreateAlertOrganizationRequestHandler(IRepositoryWithEvents<AlertOrganization> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateAlertOrganizationRequest request, CancellationToken cancellationToken)
    {
        var item = new AlertOrganization(request.Name, request.Code, request.Image, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}