namespace TD.CitizenAPI.Application.Catalog.LawDatas;

public class UpdateLawDataRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Type { get; set; }

    public string? Signer { get; set; }
    public string? Quote { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? DateIssued { get; set; }
    public string? Image { get; set; }
    public string? Link { get; set; }
    public string? Code { get; set; }
    public string? AgencyIssued { get; set; }
}

public class UpdateLawDataRequestValidator : CustomValidator<UpdateLawDataRequest>
{
    public UpdateLawDataRequestValidator(IRepository<LawData> repository, IStringLocalizer<UpdateLawDataRequestValidator> localizer) =>
        RuleFor(p => p.Title)
            .NotEmpty();
}

public class UpdateLawDataRequestHandler : IRequestHandler<UpdateLawDataRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<LawData> _repository;
    private readonly IStringLocalizer<UpdateLawDataRequestHandler> _localizer;

    public UpdateLawDataRequestHandler(IRepositoryWithEvents<LawData> repository, IStringLocalizer<UpdateLawDataRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateLawDataRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["LawData.notfound"], request.Id));

        item.Update(request.Title, request.Type, request.Signer, request.Quote, request.EffectiveDate, request.DateIssued, request.Image, request.Link, request.Code, request.AgencyIssued);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}