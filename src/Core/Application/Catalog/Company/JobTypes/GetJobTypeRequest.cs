namespace TD.CitizenAPI.Application.Catalog.JobTypes;

public class GetJobTypeRequest : IRequest<Result<JobTypeDetailsDto>>
{
    public Guid Id { get; set; }

    public GetJobTypeRequest(Guid id) => Id = id;
}

public class JobTypeByIdSpec : Specification<JobType, JobTypeDetailsDto>, ISingleResultSpecification
{
    public JobTypeByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetJobTypeRequestHandler : IRequestHandler<GetJobTypeRequest, Result<JobTypeDetailsDto>>
{
    private readonly IRepository<JobType> _repository;
    private readonly IStringLocalizer<GetJobTypeRequestHandler> _localizer;

    public GetJobTypeRequestHandler(IRepository<JobType> repository, IStringLocalizer<GetJobTypeRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<JobTypeDetailsDto>> Handle(GetJobTypeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<JobType, JobTypeDetailsDto>)new JobTypeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["JobType.notfound"], request.Id));
        return Result<JobTypeDetailsDto>.Success(item);

    }
}