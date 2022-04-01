namespace TD.CitizenAPI.Application.Catalog.LaborMarketInformations;

public class UpdateLaborMarketInformationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Actor { get; set; }
    public string? Content { get; set; }
    public DateTime? Date { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    public int? ViewQuantity { get; set; }
}

public class UpdateLaborMarketInformationRequestValidator : CustomValidator<UpdateLaborMarketInformationRequest>
{
    public UpdateLaborMarketInformationRequestValidator(IRepository<LaborMarketInformation> repository, IStringLocalizer<UpdateLaborMarketInformationRequestValidator> localizer) =>
        RuleFor(p => p.Title)
            .NotEmpty();
}

public class UpdateLaborMarketInformationRequestHandler : IRequestHandler<UpdateLaborMarketInformationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<LaborMarketInformation> _repository;
    private readonly IStringLocalizer<UpdateLaborMarketInformationRequestHandler> _localizer;

    public UpdateLaborMarketInformationRequestHandler(IRepositoryWithEvents<LaborMarketInformation> repository, IStringLocalizer<UpdateLaborMarketInformationRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateLaborMarketInformationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["LaborMarketInformation.notfound"], request.Id));

        item.Update(request.Title, request.Actor, request.Content, request.Date, request.Image, request.Source, request.ViewQuantity);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}