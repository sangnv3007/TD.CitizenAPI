namespace TD.CitizenAPI.Application.Catalog.JobAges;

public partial class CreateJobAgeRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class CreateJobAgeRequestValidator : CustomValidator<CreateJobAgeRequest>
{
    public CreateJobAgeRequestValidator(IReadRepository<JobAge> repository, IStringLocalizer<CreateJobAgeRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateJobAgeRequestHandler : IRequestHandler<CreateJobAgeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobAge> _repository;

    public CreateJobAgeRequestHandler(IRepositoryWithEvents<JobAge> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateJobAgeRequest request, CancellationToken cancellationToken)
    {
        var item = new JobAge(request.Name, request.Code, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}