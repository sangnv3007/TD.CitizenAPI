namespace TD.CitizenAPI.Application.Catalog.JobPositions;

public class GetJobPositionRequest : IRequest<Result<JobPositionDetailsDto>>
{
    public Guid Id { get; set; }

    public GetJobPositionRequest(Guid id) => Id = id;
}

public class JobPositionByIdSpec : Specification<JobPosition, JobPositionDetailsDto>, ISingleResultSpecification
{
    public JobPositionByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetJobPositionRequestHandler : IRequestHandler<GetJobPositionRequest, Result<JobPositionDetailsDto>>
{
    private readonly IRepository<JobPosition> _repository;
    private readonly IStringLocalizer<GetJobPositionRequestHandler> _localizer;

    public GetJobPositionRequestHandler(IRepository<JobPosition> repository, IStringLocalizer<GetJobPositionRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<JobPositionDetailsDto>> Handle(GetJobPositionRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<JobPosition, JobPositionDetailsDto>)new JobPositionByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["JobPosition.notfound"], request.Id));
        return Result<JobPositionDetailsDto>.Success(item);

    }
}