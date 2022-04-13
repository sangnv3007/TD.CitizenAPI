namespace TD.CitizenAPI.Application.Catalog.FoodWarnings;

public class SearchFoodWarningsRequest : PaginationFilter, IRequest<PaginationResponse<FoodWarningDto>>
{
}

public class FoodWarningsBySearchRequestSpec : EntitiesByPaginationFilterSpec<FoodWarning, FoodWarningDto>
{
    public FoodWarningsBySearchRequestSpec(SearchFoodWarningsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchFoodWarningsRequestHandler : IRequestHandler<SearchFoodWarningsRequest, PaginationResponse<FoodWarningDto>>
{
    private readonly IReadRepository<FoodWarning> _repository;

    public SearchFoodWarningsRequestHandler(IReadRepository<FoodWarning> repository) => _repository = repository;

    public async Task<PaginationResponse<FoodWarningDto>> Handle(SearchFoodWarningsRequest request, CancellationToken cancellationToken)
    {
        var spec = new FoodWarningsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<FoodWarningDto>(list, count, request.PageNumber, request.PageSize);
    }
}