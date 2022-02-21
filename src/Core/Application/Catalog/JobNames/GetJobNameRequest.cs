namespace TD.CitizenAPI.Application.Catalog.JobNames;

public class GetJobNameRequest : IRequest<Result<JobNameDetailsDto>>
{
    public Guid Id { get; set; }

    public GetJobNameRequest(Guid id) => Id = id;
}

public class JobNameByIdSpec : Specification<JobName, JobNameDetailsDto>, ISingleResultSpecification
{
    public JobNameByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetJobNameRequestHandler : IRequestHandler<GetJobNameRequest, Result<JobNameDetailsDto>>
{
    private readonly IRepository<JobName> _repository;
    private readonly IStringLocalizer<GetJobNameRequestHandler> _localizer;

    public GetJobNameRequestHandler(IRepository<JobName> repository, IStringLocalizer<GetJobNameRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<JobNameDetailsDto>> Handle(GetJobNameRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<JobName, JobNameDetailsDto>)new JobNameByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["JobName.notfound"], request.Id));
        return Result<JobNameDetailsDto>.Success(item);

    }
}