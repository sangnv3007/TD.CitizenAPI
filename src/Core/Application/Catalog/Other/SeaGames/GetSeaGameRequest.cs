namespace TD.CitizenAPI.Application.Catalog.SeaGames;

public class GetSeaGameRequest : IRequest<Result<SeaGameDetailsDto>>
{
    public Guid Id { get; set; }

    public GetSeaGameRequest(Guid id) => Id = id;
}

public class SeaGameByIdSpec : Specification<SeaGame, SeaGameDetailsDto>, ISingleResultSpecification
{
    public SeaGameByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetSeaGameRequestHandler : IRequestHandler<GetSeaGameRequest, Result<SeaGameDetailsDto>>
{
    private readonly IRepository<SeaGame> _repository;
    private readonly IStringLocalizer<GetSeaGameRequestHandler> _localizer;

    public GetSeaGameRequestHandler(IRepository<SeaGame> repository, IStringLocalizer<GetSeaGameRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<SeaGameDetailsDto>> Handle(GetSeaGameRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<SeaGame, SeaGameDetailsDto>)new SeaGameByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["SeaGame.notfound"], request.Id));
        return Result<SeaGameDetailsDto>.Success(item);

    }
}