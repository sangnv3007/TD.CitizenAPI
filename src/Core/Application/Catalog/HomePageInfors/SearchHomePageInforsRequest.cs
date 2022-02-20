namespace TD.CitizenAPI.Application.Catalog.HomePageInfors;

public class SearchHomePageInforsRequest : PaginationFilter, IRequest<PaginationResponse<HomePageInforDto>>
{
}

public class HomePageInforsBySearchRequestSpec : EntitiesByPaginationFilterSpec<HomePageInfor, HomePageInforDto>
{
    public HomePageInforsBySearchRequestSpec(SearchHomePageInforsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Title, !request.HasOrderBy());
}

public class SearchCategoriesRequestHandler : IRequestHandler<SearchHomePageInforsRequest, PaginationResponse<HomePageInforDto>>
{
    private readonly IReadRepository<HomePageInfor> _repository;

    public SearchCategoriesRequestHandler(IReadRepository<HomePageInfor> repository) => _repository = repository;

    public async Task<PaginationResponse<HomePageInforDto>> Handle(SearchHomePageInforsRequest request, CancellationToken cancellationToken)
    {
        var spec = new HomePageInforsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<HomePageInforDto>(list, count, request.PageNumber, request.PageSize);
    }
}