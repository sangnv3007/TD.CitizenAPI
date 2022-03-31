namespace TD.CitizenAPI.Application.Catalog.AlertOrganizations;

public class UpdateAlertOrganizationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class UpdateAlertOrganizationRequestValidator : CustomValidator<UpdateAlertOrganizationRequest>
{
    public UpdateAlertOrganizationRequestValidator(IRepository<AlertOrganization> repository, IStringLocalizer<UpdateAlertOrganizationRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateAlertOrganizationRequestHandler : IRequestHandler<UpdateAlertOrganizationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AlertOrganization> _repository;
    private readonly IStringLocalizer<UpdateAlertOrganizationRequestHandler> _localizer;

    public UpdateAlertOrganizationRequestHandler(IRepositoryWithEvents<AlertOrganization> repository, IStringLocalizer<UpdateAlertOrganizationRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateAlertOrganizationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["AlertOrganization.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Image, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}