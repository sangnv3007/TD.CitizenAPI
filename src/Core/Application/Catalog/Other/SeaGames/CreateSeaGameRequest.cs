namespace TD.CitizenAPI.Application.Catalog.SeaGames;

public partial class CreateSeaGameRequest : IRequest<Result<Guid>>
{
    public string Title { get; set; } = default!;
    public string? Actor { get; set; }
    public string? Content { get; set; }
    public DateTime? Date { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    public int? ViewQuantity { get; set; }
}

public class CreateSeaGameRequestValidator : CustomValidator<CreateSeaGameRequest>
{
    public CreateSeaGameRequestValidator(IReadRepository<SeaGame> repository, IStringLocalizer<CreateSeaGameRequestValidator> localizer) =>
        RuleFor(p => p.Title).NotEmpty();
}

public class CreateSeaGameRequestHandler : IRequestHandler<CreateSeaGameRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SeaGame> _repository;

    public CreateSeaGameRequestHandler(IRepositoryWithEvents<SeaGame> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateSeaGameRequest request, CancellationToken cancellationToken)
    {
        var item = new SeaGame(request.Title,request.Actor,request.Content,request.Date,request.Image,request.Source,request.ViewQuantity);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}