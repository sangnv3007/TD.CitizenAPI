namespace TD.CitizenAPI.Application.Catalog.JobAges;

public class GetJobAgeRequest : IRequest<Result<JobAgeDetailsDto>>
{
    public Guid Id { get; set; }

    public GetJobAgeRequest(Guid id) => Id = id;
}

public class JobAgeByIdSpec : Specification<JobAge, JobAgeDetailsDto>, ISingleResultSpecification
{
    public JobAgeByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetJobAgeRequestHandler : IRequestHandler<GetJobAgeRequest, Result<JobAgeDetailsDto>>
{
    private readonly IRepository<JobAge> _repository;
    private readonly IStringLocalizer<GetJobAgeRequestHandler> _localizer;

    public GetJobAgeRequestHandler(IRepository<JobAge> repository, IStringLocalizer<GetJobAgeRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<JobAgeDetailsDto>> Handle(GetJobAgeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<JobAge, JobAgeDetailsDto>)new JobAgeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["JobAge.notfound"], request.Id));
        return Result<JobAgeDetailsDto>.Success(item);

    }
}