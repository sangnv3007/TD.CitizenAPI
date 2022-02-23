namespace TD.CitizenAPI.Application.Catalog.JobSaveds;

public class SearchJobSavedsRequest : PaginationFilter, IRequest<PaginationResponse<JobSavedDto>>
{
}

public class JobSavedsBySearchRequestSpec : EntitiesByPaginationFilterSpec<JobSaved, JobSavedDto>
{

    public JobSavedsBySearchRequestSpec(SearchJobSavedsRequest request, string? UserName)
        : base(request)
    =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy()).Include(p => p.Recruitment).Where(p => p.UserName == UserName);
}

public class SearchJobSavedsRequestHandler : IRequestHandler<SearchJobSavedsRequest, PaginationResponse<JobSavedDto>>
{
    private readonly IReadRepository<JobSaved> _repository;
    private readonly ICurrentUser _currentUser;
    public SearchJobSavedsRequestHandler(IReadRepository<JobSaved> repository, ICurrentUser currentUser) => (_repository, _currentUser) = (repository, currentUser);

    public async Task<PaginationResponse<JobSavedDto>> Handle(SearchJobSavedsRequest request, CancellationToken cancellationToken)
    {
        var spec = new JobSavedsBySearchRequestSpec(request, _currentUser.GetUserName());

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<JobSavedDto>(list, count, request.PageNumber, request.PageSize);
    }
}