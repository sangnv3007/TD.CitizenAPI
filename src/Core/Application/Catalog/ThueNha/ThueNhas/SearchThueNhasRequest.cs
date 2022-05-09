namespace TD.CitizenAPI.Application.Catalog.ThueNhas;

public class SearchThueNhasRequest : PaginationFilter, IRequest<PaginationResponse<ThueNhaDto>>
{
}

public class ThueNhasBySearchRequestSpec : EntitiesByPaginationFilterSpec<ThueNha, ThueNhaDto>
{
    public ThueNhasBySearchRequestSpec(SearchThueNhasRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchThueNhasRequestHandler : IRequestHandler<SearchThueNhasRequest, PaginationResponse<ThueNhaDto>>
{
    private readonly IReadRepository<ThueNha> _repository;

    public SearchThueNhasRequestHandler(IReadRepository<ThueNha> repository) => _repository = repository;

    public async Task<PaginationResponse<ThueNhaDto>> Handle(SearchThueNhasRequest request, CancellationToken cancellationToken)
    {
        var spec = new ThueNhasBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ThueNhaDto>(list, count, request.PageNumber, request.PageSize);
    }
}