namespace TD.CitizenAPI.Application.Catalog.JobApplieds;

public class GetJobAppliedRequest : IRequest<Result<JobAppliedDetailsDto>>
{
    public Guid Id { get; set; }

    public GetJobAppliedRequest(Guid id) => Id = id;
}

public class JobAppliedByIdSpec : Specification<JobApplied, JobAppliedDetailsDto>, ISingleResultSpecification
{
    public JobAppliedByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.Recruitment)
        .Include(p => p.JobApplication)
        ;
}

public class GetJobAppliedRequestHandler : IRequestHandler<GetJobAppliedRequest, Result<JobAppliedDetailsDto>>
{
    private readonly IRepository<JobApplied> _repository;
    private readonly IStringLocalizer<GetJobAppliedRequestHandler> _localizer;

    public GetJobAppliedRequestHandler(IRepository<JobApplied> repository, IStringLocalizer<GetJobAppliedRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<JobAppliedDetailsDto>> Handle(GetJobAppliedRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<JobApplied, JobAppliedDetailsDto>)new JobAppliedByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["JobApplied.notfound"], request.Id));
        return Result<JobAppliedDetailsDto>.Success(item);

    }
}