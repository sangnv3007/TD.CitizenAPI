namespace TD.CitizenAPI.Application.Catalog.FoodFactories;

public class SearchFoodFactoriesRequest : PaginationFilter, IRequest<PaginationResponse<FoodFactoryDto>>
{
}

public class FoodFactorysBySearchRequestSpec : EntitiesByPaginationFilterSpec<FoodFactory, FoodFactoryDto>
{
    public FoodFactorysBySearchRequestSpec(SearchFoodFactoriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchFoodFactorysRequestHandler : IRequestHandler<SearchFoodFactoriesRequest, PaginationResponse<FoodFactoryDto>>
{
    private readonly IReadRepository<FoodFactory> _repository;

    public SearchFoodFactorysRequestHandler(IReadRepository<FoodFactory> repository) => _repository = repository;

    public async Task<PaginationResponse<FoodFactoryDto>> Handle(SearchFoodFactoriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new FoodFactorysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<FoodFactoryDto>(list, count, request.PageNumber, request.PageSize);
    }
}