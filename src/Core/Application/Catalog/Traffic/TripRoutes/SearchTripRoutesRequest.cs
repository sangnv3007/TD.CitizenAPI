namespace TD.CitizenAPI.Application.Catalog.TripRoutes;

public class SearchTripRoutesRequest : PaginationFilter, IRequest<PaginationResponse<TripRouteDto>>
{
    public Guid? TripId { get; set; }
   
}



public class SearchTripRoutesRequestHandler : IRequestHandler<SearchTripRoutesRequest, PaginationResponse<TripRouteDto>>
{
    private readonly IReadRepository<TripRoute> _repository;

    public SearchTripRoutesRequestHandler(IReadRepository<TripRoute> repository) => _repository = repository;

    public async Task<PaginationResponse<TripRouteDto>> Handle(SearchTripRoutesRequest request, CancellationToken cancellationToken)
    {
        var spec = new TripRoutesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<TripRouteDto>(list, count, request.PageNumber, request.PageSize);
    }
}