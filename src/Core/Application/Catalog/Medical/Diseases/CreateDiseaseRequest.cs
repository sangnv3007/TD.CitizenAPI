namespace TD.CitizenAPI.Application.Catalog.Diseases;

public partial class CreateDiseaseRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
}

public class CreateDiseaseRequestValidator : CustomValidator<CreateDiseaseRequest>
{
    public CreateDiseaseRequestValidator(IReadRepository<Disease> repository, IStringLocalizer<CreateDiseaseRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateDiseaseRequestHandler : IRequestHandler<CreateDiseaseRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Disease> _repository;

    public CreateDiseaseRequestHandler(IRepositoryWithEvents<Disease> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateDiseaseRequest request, CancellationToken cancellationToken)
    {
        var item = new Disease(request.Name, request.Code, request.Image, request.Images, request.Description, request.Content);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}