namespace TD.CitizenAPI.Application.Catalog.Carpools;

public class SearchCarpoolsRequest : PaginationFilter, IRequest<PaginationResponse<CarpoolDto>>
{
    public decimal? PriceFrom { get; set; }
    public decimal? PriceTo { get; set; }

    public Guid? DepartureProvinceId { get; set; }
    public Guid? DepartureDistrictId { get; set; }
    public Guid? DepartureCommuneId { get; set; }

    public Guid? ArrivalProvinceId { get; set; }
    public Guid? ArrivalDistrictId { get; set; }
    public Guid? ArrivalCommuneId { get; set; }

    public Guid? VehicleTypeId { get; set; }

    public string? DepartureDateStart { get; set; }
    public string? DepartureDateEnd { get; set; }
    public int? Status { get; set; }
    public string? UserName { get; set; }
    public string? Role { get; set; }
   

}

public class SearchCategoriesRequestHandler : IRequestHandler<SearchCarpoolsRequest, PaginationResponse<CarpoolDto>>
{
    private readonly IReadRepository<Carpool> _repository;

    public SearchCategoriesRequestHandler(IReadRepository<Carpool> repository) => _repository = repository;

    public async Task<PaginationResponse<CarpoolDto>> Handle(SearchCarpoolsRequest request, CancellationToken cancellationToken)
    {
        var spec = new CarpoolsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<CarpoolDto>(list, count, request.PageNumber, request.PageSize);
    }
}