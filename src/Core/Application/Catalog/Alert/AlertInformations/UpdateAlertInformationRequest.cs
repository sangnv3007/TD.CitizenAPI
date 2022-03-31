namespace TD.CitizenAPI.Application.Catalog.AlertInformations;

public class UpdateAlertInformationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Content { get; set; }
    public string? Description { get; set; }
    public bool? Active { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public int? Level { get; set; }
    public string? Image { get; set; }
    public string? File { get; set; }
    public Guid? AlertCategoryId { get; set; }
    public Guid? AlertOrganizationId { get; set; }
}

public class UpdateAlertInformationRequestValidator : CustomValidator<UpdateAlertInformationRequest>
{
    public UpdateAlertInformationRequestValidator(IRepository<AlertInformation> repository, IStringLocalizer<UpdateAlertInformationRequestValidator> localizer) =>
        RuleFor(p => p.Title)
            .NotEmpty();
}

public class UpdateAlertInformationRequestHandler : IRequestHandler<UpdateAlertInformationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AlertInformation> _repository;
    private readonly IStringLocalizer<UpdateAlertInformationRequestHandler> _localizer;

    public UpdateAlertInformationRequestHandler(IRepositoryWithEvents<AlertInformation> repository, IStringLocalizer<UpdateAlertInformationRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateAlertInformationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["AlertInformation.notfound"], request.Id));

        item.Update(request.Title, request.Content, request.Description, request.Active, request.StartDate, request.FinishDate, request.Level, request.Image, request.File, request.AlertCategoryId, request.AlertOrganizationId);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}