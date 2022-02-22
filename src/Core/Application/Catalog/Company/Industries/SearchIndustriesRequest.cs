namespace TD.CitizenAPI.Application.Catalog.Industries;

public class SearchIndustriesRequest : PaginationFilter, IRequest<PaginationResponse<IndustryDto>>
{
}

public class IndustriesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Industry, IndustryDto>
{
    public IndustriesBySearchRequestSpec(SearchIndustriesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchIndustriesRequestHandler : IRequestHandler<SearchIndustriesRequest, PaginationResponse<IndustryDto>>
{
    private readonly IReadRepository<Industry> _repository;

    public SearchIndustriesRequestHandler(IReadRepository<Industry> repository) => _repository = repository;

    public async Task<PaginationResponse<IndustryDto>> Handle(SearchIndustriesRequest request, CancellationToken cancellationToken)
    {
        var spec = new IndustriesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<IndustryDto>(list, count, request.PageNumber, request.PageSize);
    }
}