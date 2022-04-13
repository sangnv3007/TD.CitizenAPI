namespace TD.CitizenAPI.Application.Catalog.Diseases;

public class SearchDiseasesRequest : PaginationFilter, IRequest<PaginationResponse<DiseaseDto>>
{
}

public class DiseasesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Disease, DiseaseDto>
{
    public DiseasesBySearchRequestSpec(SearchDiseasesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchDiseasesRequestHandler : IRequestHandler<SearchDiseasesRequest, PaginationResponse<DiseaseDto>>
{
    private readonly IReadRepository<Disease> _repository;

    public SearchDiseasesRequestHandler(IReadRepository<Disease> repository) => _repository = repository;

    public async Task<PaginationResponse<DiseaseDto>> Handle(SearchDiseasesRequest request, CancellationToken cancellationToken)
    {
        var spec = new DiseasesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<DiseaseDto>(list, count, request.PageNumber, request.PageSize);
    }
}