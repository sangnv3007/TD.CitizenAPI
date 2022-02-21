namespace TD.CitizenAPI.Application.Catalog.Experiences;

public partial class CreateExperienceRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class CreateExperienceRequestValidator : CustomValidator<CreateExperienceRequest>
{
    public CreateExperienceRequestValidator(IReadRepository<Experience> repository, IStringLocalizer<CreateExperienceRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateDegreeRequestHandler : IRequestHandler<CreateExperienceRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Experience> _repository;

    public CreateDegreeRequestHandler(IRepositoryWithEvents<Experience> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateExperienceRequest request, CancellationToken cancellationToken)
    {
        var item = new Experience(request.Name, request.Code, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}