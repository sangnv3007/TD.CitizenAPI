namespace TD.CitizenAPI.Application.Catalog.JobNames;

public class CreateJobNameRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class CreateJobNameRequestValidator : CustomValidator<CreateJobNameRequest>
{
    public CreateJobNameRequestValidator(IReadRepository<JobName> repository, IStringLocalizer<CreateJobNameRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateJobNameRequestHandler : IRequestHandler<CreateJobNameRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobName> _repository;

    public CreateJobNameRequestHandler(IRepositoryWithEvents<JobName> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateJobNameRequest request, CancellationToken cancellationToken)
    {
        var item = new JobName(request.Name, request.Code, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}