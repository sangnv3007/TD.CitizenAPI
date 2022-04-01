namespace TD.CitizenAPI.Application.Catalog.LawDatas;

public partial class CreateLawDataRequest : IRequest<Result<Guid>>
{
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

public class CreateLawDataRequestValidator : CustomValidator<CreateLawDataRequest>
{
    public CreateLawDataRequestValidator(IReadRepository<LawData> repository, IStringLocalizer<CreateLawDataRequestValidator> localizer) =>
        RuleFor(p => p.Title).NotEmpty();
}

public class CreateLawDataRequestHandler : IRequestHandler<CreateLawDataRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<LawData> _repository;

    public CreateLawDataRequestHandler(IRepositoryWithEvents<LawData> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateLawDataRequest request, CancellationToken cancellationToken)
    {
        var item = new LawData(request.Title, request.Type, request.Signer, request.Quote, request.EffectiveDate, request.DateIssued, request.Image, request.Link, request.Code, request.AgencyIssued);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}