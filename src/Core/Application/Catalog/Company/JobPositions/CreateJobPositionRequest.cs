namespace TD.CitizenAPI.Application.Catalog.JobPositions;

public class CreateJobPositionRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class CreateJobPositionRequestValidator : CustomValidator<CreateJobPositionRequest>
{
    public CreateJobPositionRequestValidator(IReadRepository<JobPosition> repository, IStringLocalizer<CreateJobPositionRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateJobPositionRequestHandler : IRequestHandler<CreateJobPositionRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobPosition> _repository;

    public CreateJobPositionRequestHandler(IRepositoryWithEvents<JobPosition> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateJobPositionRequest request, CancellationToken cancellationToken)
    {
        var item = new JobPosition(request.Name, request.Code, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}