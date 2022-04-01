namespace TD.CitizenAPI.Application.Catalog.LaborMarketInformations;

public partial class CreateLaborMarketInformationRequest : IRequest<Result<Guid>>
{
    public string Title { get; set; } = default!;
    public string? Actor { get; set; }
    public string? Content { get; set; }
    public DateTime? Date { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    public int? ViewQuantity { get; set; }
}

public class CreateLaborMarketInformationRequestValidator : CustomValidator<CreateLaborMarketInformationRequest>
{
    public CreateLaborMarketInformationRequestValidator(IReadRepository<LaborMarketInformation> repository, IStringLocalizer<CreateLaborMarketInformationRequestValidator> localizer) =>
        RuleFor(p => p.Title).NotEmpty();
}

public class CreateLaborMarketInformationRequestHandler : IRequestHandler<CreateLaborMarketInformationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<LaborMarketInformation> _repository;

    public CreateLaborMarketInformationRequestHandler(IRepositoryWithEvents<LaborMarketInformation> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateLaborMarketInformationRequest request, CancellationToken cancellationToken)
    {
        var item = new LaborMarketInformation(request.Title,request.Actor,request.Content,request.Date,request.Image,request.Source,request.ViewQuantity);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}