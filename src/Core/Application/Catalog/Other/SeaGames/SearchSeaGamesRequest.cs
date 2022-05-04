namespace TD.CitizenAPI.Application.Catalog.SeaGames;

public class SearchSeaGamesRequest : PaginationFilter, IRequest<PaginationResponse<SeaGameDto>>
{
}

public class AlertCategoriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<SeaGame, SeaGameDto>
{
    public AlertCategoriesBySearchRequestSpec(SearchSeaGamesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy());
}

public class SearchAlertCategoriesRequestHandler : IRequestHandler<SearchSeaGamesRequest, PaginationResponse<SeaGameDto>>
{
    private readonly IReadRepository<SeaGame> _repository;

    public SearchAlertCategoriesRequestHandler(IReadRepository<SeaGame> repository) => _repository = repository;

    public async Task<PaginationResponse<SeaGameDto>> Handle(SearchSeaGamesRequest request, CancellationToken cancellationToken)
    {
        var spec = new AlertCategoriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<SeaGameDto>(list, count, request.PageNumber, request.PageSize);
    }
}