namespace TD.CitizenAPI.Application.Catalog.Degrees;

public partial class CreateDegreeRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class CreateDegreeRequestValidator : CustomValidator<CreateDegreeRequest>
{
    public CreateDegreeRequestValidator(IReadRepository<Degree> repository, IStringLocalizer<CreateDegreeRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateDegreeRequestHandler : IRequestHandler<CreateDegreeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Degree> _repository;

    public CreateDegreeRequestHandler(IRepositoryWithEvents<Degree> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateDegreeRequest request, CancellationToken cancellationToken)
    {
        var item = new Degree(request.Name, request.Code, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}