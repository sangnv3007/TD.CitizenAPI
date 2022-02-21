namespace TD.CitizenAPI.Application.Catalog.Benefits;

public class SearchBenefitsRequest : PaginationFilter, IRequest<PaginationResponse<BenefitDto>>
{
}

public class BenefitsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Benefit, BenefitDto>
{
    public BenefitsBySearchRequestSpec(SearchBenefitsRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchHotlineCategoriesRequestHandler : IRequestHandler<SearchBenefitsRequest, PaginationResponse<BenefitDto>>
{
    private readonly IReadRepository<Benefit> _repository;

    public SearchHotlineCategoriesRequestHandler(IReadRepository<Benefit> repository) => _repository = repository;

    public async Task<PaginationResponse<BenefitDto>> Handle(SearchBenefitsRequest request, CancellationToken cancellationToken)
    {
        var spec = new BenefitsBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<BenefitDto>(list, count, request.PageNumber, request.PageSize);
    }
}