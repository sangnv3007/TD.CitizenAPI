namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class SearchPlaceTypesRequest : PaginationFilter, IRequest<PaginationResponse<PlaceTypeDto>>
{
    public Guid? CategoryId { get; set; }
    public string? CategoryCode { get; set; }
}

public class SearchCategoriesRequestHandler : IRequestHandler<SearchPlaceTypesRequest, PaginationResponse<PlaceTypeDto>>
{
    private readonly IReadRepository<PlaceType> _repository;

    public SearchCategoriesRequestHandler(IReadRepository<PlaceType> repository) => _repository = repository;

    public async Task<PaginationResponse<PlaceTypeDto>> Handle(SearchPlaceTypesRequest request, CancellationToken cancellationToken)
    {
        var spec = new PlaceTypesBySearchRequestWithCategoriesSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<PlaceTypeDto>(list, count, request.PageNumber, request.PageSize);
    }
}