namespace TD.CitizenAPI.Application.Catalog.SeaGames;

public class UpdateSeaGameRequest : IRequest<Result<Guid>>
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

public class UpdateSeaGameRequestValidator : CustomValidator<UpdateSeaGameRequest>
{
    public UpdateSeaGameRequestValidator(IRepository<SeaGame> repository, IStringLocalizer<UpdateSeaGameRequestValidator> localizer) =>
        RuleFor(p => p.Title)
            .NotEmpty();
}

public class UpdateSeaGameRequestHandler : IRequestHandler<UpdateSeaGameRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SeaGame> _repository;
    private readonly IStringLocalizer<UpdateSeaGameRequestHandler> _localizer;

    public UpdateSeaGameRequestHandler(IRepositoryWithEvents<SeaGame> repository, IStringLocalizer<UpdateSeaGameRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateSeaGameRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["SeaGame.notfound"], request.Id));

        item.Update(request.Title, request.Actor, request.Content, request.Date, request.Image, request.Source, request.ViewQuantity);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}