namespace TD.CitizenAPI.Application.Catalog.JobTypes;

public class CreateJobTypeRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class CreateJobTypeRequestValidator : CustomValidator<CreateJobTypeRequest>
{
    public CreateJobTypeRequestValidator(IReadRepository<JobType> repository, IStringLocalizer<CreateJobTypeRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateJobTypeRequestHandler : IRequestHandler<CreateJobTypeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobType> _repository;

    public CreateJobTypeRequestHandler(IRepositoryWithEvents<JobType> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateJobTypeRequest request, CancellationToken cancellationToken)
    {
        var item = new JobType(request.Name, request.Code, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}