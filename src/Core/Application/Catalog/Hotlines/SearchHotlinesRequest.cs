namespace TD.CitizenAPI.Application.Catalog.Hotlines;

public class SearchHotlinesRequest : PaginationFilter, IRequest<PaginationResponse<HotlineDto>>
{
    public Guid? HotlineCategoryId { get; set; }

}

public class SearchCategoriesRequestHandler : IRequestHandler<SearchHotlinesRequest, PaginationResponse<HotlineDto>>
{
    private readonly IReadRepository<Hotline> _repository;

    public SearchCategoriesRequestHandler(IReadRepository<Hotline> repository) => _repository = repository;

    public async Task<PaginationResponse<HotlineDto>> Handle(SearchHotlinesRequest request, CancellationToken cancellationToken)
    {
        var spec = new HotlinesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<HotlineDto>(list, count, request.PageNumber, request.PageSize);
    }
}