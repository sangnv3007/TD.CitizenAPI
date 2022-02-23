namespace TD.CitizenAPI.Application.Catalog.CarUtilities;

public class SearchCarUtilitiesRequest : PaginationFilter, IRequest<PaginationResponse<CarUtilityDto>>
{
}

public class CarUtilitysBySearchRequestSpec : EntitiesByPaginationFilterSpec<CarUtility, CarUtilityDto>
{
    public CarUtilitysBySearchRequestSpec(SearchCarUtilitiesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCarUtilitysRequestHandler : IRequestHandler<SearchCarUtilitiesRequest, PaginationResponse<CarUtilityDto>>
{
    private readonly IReadRepository<CarUtility> _repository;

    public SearchCarUtilitysRequestHandler(IReadRepository<CarUtility> repository) => _repository = repository;

    public async Task<PaginationResponse<CarUtilityDto>> Handle(SearchCarUtilitiesRequest request, CancellationToken cancellationToken)
    {
        var spec = new CarUtilitysBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<CarUtilityDto>(list, count, request.PageNumber, request.PageSize);
    }
}