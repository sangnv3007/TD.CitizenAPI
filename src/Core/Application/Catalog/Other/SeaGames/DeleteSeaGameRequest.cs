namespace TD.CitizenAPI.Application.Catalog.SeaGames;

public class DeleteSeaGameRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteSeaGameRequest(Guid id) => Id = id;
}

public class DeleteSeaGameRequestHandler : IRequestHandler<DeleteSeaGameRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<SeaGame> _repository;
    private readonly IStringLocalizer<DeleteSeaGameRequestHandler> _localizer;

    public DeleteSeaGameRequestHandler(IRepositoryWithEvents<SeaGame> repository, IStringLocalizer<DeleteSeaGameRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteSeaGameRequest request, CancellationToken cancellationToken)
    {


        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["SeaGame.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}