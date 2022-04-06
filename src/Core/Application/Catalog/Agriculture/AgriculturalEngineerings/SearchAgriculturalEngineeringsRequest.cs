namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineerings;

public class SearchAgriculturalEngineeringsRequest : PaginationFilter, IRequest<PaginationResponse<AgriculturalEngineeringDto>>
{
    public Guid? AgriculturalEngineeringCategoryId { get; set; }

}

public class SearchCategoriesRequestHandler : IRequestHandler<SearchAgriculturalEngineeringsRequest, PaginationResponse<AgriculturalEngineeringDto>>
{
    private readonly IReadRepository<AgriculturalEngineering> _repository;

    public SearchCategoriesRequestHandler(IReadRepository<AgriculturalEngineering> repository) => _repository = repository;

    public async Task<PaginationResponse<AgriculturalEngineeringDto>> Handle(SearchAgriculturalEngineeringsRequest request, CancellationToken cancellationToken)
    {
        var spec = new AgriculturalEngineeringsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AgriculturalEngineeringDto>(list, count, request.PageNumber, request.PageSize);
    }
}