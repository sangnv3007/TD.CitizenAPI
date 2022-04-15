namespace TD.CitizenAPI.Application.Catalog.TravelHandbooks;

public partial class CreateTravelHandbookRequest : IRequest<Result<Guid>>
{
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    public string? Tags { get; set; }
}

public class CreateTravelHandbookRequestValidator : CustomValidator<CreateTravelHandbookRequest>
{
    public CreateTravelHandbookRequestValidator(IReadRepository<TravelHandbook> repository, IStringLocalizer<CreateTravelHandbookRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateTravelHandbookRequestHandler : IRequestHandler<CreateTravelHandbookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<TravelHandbook> _repository;

    public CreateTravelHandbookRequestHandler(IRepositoryWithEvents<TravelHandbook> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateTravelHandbookRequest request, CancellationToken cancellationToken)
    {
        var item = new TravelHandbook(request.Name, request.Content,request.Description, 0, request.Image, request.Source, request.Tags);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}