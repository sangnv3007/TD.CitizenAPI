namespace TD.CitizenAPI.Application.Catalog.JobApplieds;

public class SearchCurrentJobAppliedsRequest : PaginationFilter, IRequest<PaginationResponse<JobAppliedDto>>
{
}

public class JobAppliedsBySearchRequestSpec : EntitiesByPaginationFilterSpec<JobApplied, JobAppliedDto>
{
    public JobAppliedsBySearchRequestSpec(SearchCurrentJobAppliedsRequest request, string? UserName)
        : base(request)
    => Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy()).Include(p => p.Recruitment.Company).Include(p => p.JobApplication).Where(p => p.UserName == UserName);
}

public class SearchJobAppliedsRequestHandler : IRequestHandler<SearchCurrentJobAppliedsRequest, PaginationResponse<JobAppliedDto>>
{
    private readonly IReadRepository<JobApplied> _repository;
    private readonly ICurrentUser _currentUser;
    public SearchJobAppliedsRequestHandler(IReadRepository<JobApplied> repository, ICurrentUser currentUser) => (_repository, _currentUser) = (repository, currentUser);

    public async Task<PaginationResponse<JobAppliedDto>> Handle(SearchCurrentJobAppliedsRequest request, CancellationToken cancellationToken)
    {
        var spec = new JobAppliedsBySearchRequestSpec(request, _currentUser.GetUserName());

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<JobAppliedDto>(list, count, request.PageNumber, request.PageSize);
    }
}