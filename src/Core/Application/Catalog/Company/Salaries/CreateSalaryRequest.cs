namespace TD.CitizenAPI.Application.Catalog.Salaries;

public class CreateSalaryRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class CreateSalaryRequestValidator : CustomValidator<CreateSalaryRequest>
{
    public CreateSalaryRequestValidator(IReadRepository<Salary> repository, IStringLocalizer<CreateSalaryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateSalaryRequestHandler : IRequestHandler<CreateSalaryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Salary> _repository;

    public CreateSalaryRequestHandler(IRepositoryWithEvents<Salary> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateSalaryRequest request, CancellationToken cancellationToken)
    {
        var item = new Salary(request.Name, request.Code, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}