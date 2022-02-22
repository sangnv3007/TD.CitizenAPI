namespace TD.CitizenAPI.Application.Catalog.Experiences;

public class SearchExperiencesRequest : PaginationFilter, IRequest<PaginationResponse<ExperienceDto>>
{
}

public class ExperiencesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Experience, ExperienceDto>
{
    public ExperiencesBySearchRequestSpec(SearchExperiencesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Name, !request.HasOrderBy());
}

public class SearchExperiencesRequestHandler : IRequestHandler<SearchExperiencesRequest, PaginationResponse<ExperienceDto>>
{
    private readonly IReadRepository<Experience> _repository;

    public SearchExperiencesRequestHandler(IReadRepository<Experience> repository) => _repository = repository;

    public async Task<PaginationResponse<ExperienceDto>> Handle(SearchExperiencesRequest request, CancellationToken cancellationToken)
    {
        var spec = new ExperiencesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<ExperienceDto>(list, count, request.PageNumber, request.PageSize);
    }
}