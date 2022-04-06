using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineerings;

public class CreateAgriculturalEngineeringRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public Guid? AgriculturalEngineeringCategoryId { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
}

public class CreateAgriculturalEngineeringRequestValidator : CustomValidator<CreateAgriculturalEngineeringRequest>
{
    public CreateAgriculturalEngineeringRequestValidator(IReadRepository<AgriculturalEngineering> repository, IStringLocalizer<CreateAgriculturalEngineeringRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(256);
}

public class CreateAgriculturalEngineeringRequestHandler : IRequestHandler<CreateAgriculturalEngineeringRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AgriculturalEngineering> _repository;

    public CreateAgriculturalEngineeringRequestHandler(IRepositoryWithEvents<AgriculturalEngineering> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateAgriculturalEngineeringRequest request, CancellationToken cancellationToken)
    {
        var item = new AgriculturalEngineering(request.Name,request.AgriculturalEngineeringCategoryId,request.Code,request.Image,request.Content,request.Description);
        item.DomainEvents.Add(EntityCreatedEvent.WithEntity(item));

        await _repository.AddAsync(item, cancellationToken);

        return Result<Guid>.Success(item.Id);
    }
}