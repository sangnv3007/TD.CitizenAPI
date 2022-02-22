namespace TD.CitizenAPI.Application.Catalog.Companies;

public class SearchCompaniesRequest : PaginationFilter, IRequest<PaginationResponse<CompanyDto>>
{
    public string? UserName { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
}

public class SearchCompaniesRequestHandler : IRequestHandler<SearchCompaniesRequest, PaginationResponse<CompanyDto>>
{
    private readonly IReadRepository<Company> _repository;

    public SearchCompaniesRequestHandler(IReadRepository<Company> repository) => _repository = repository;

    public async Task<PaginationResponse<CompanyDto>> Handle(SearchCompaniesRequest request, CancellationToken cancellationToken)
    {
        var spec = new CompaniesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<CompanyDto>(list, count, request.PageNumber, request.PageSize);
    }
}