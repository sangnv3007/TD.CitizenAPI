namespace TD.CitizenAPI.Application.Catalog.MedicalHotlines;

public class SearchMedicalHotlinesRequest : PaginationFilter, IRequest<PaginationResponse<MedicalHotlineDto>>
{
    public Guid? HotlineCategoryId { get; set; }

}

public class MedicalHotlinesBySearchRequestSpec : EntitiesByPaginationFilterSpec<MedicalHotline, MedicalHotlineDto>
{
    public MedicalHotlinesBySearchRequestSpec(SearchMedicalHotlinesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchCategoriesRequestHandler : IRequestHandler<SearchMedicalHotlinesRequest, PaginationResponse<MedicalHotlineDto>>
{
    private readonly IReadRepository<MedicalHotline> _repository;

    public SearchCategoriesRequestHandler(IReadRepository<MedicalHotline> repository) => _repository = repository;

    public async Task<PaginationResponse<MedicalHotlineDto>> Handle(SearchMedicalHotlinesRequest request, CancellationToken cancellationToken)
    {
        var spec = new MedicalHotlinesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<MedicalHotlineDto>(list, count, request.PageNumber, request.PageSize);
    }
}