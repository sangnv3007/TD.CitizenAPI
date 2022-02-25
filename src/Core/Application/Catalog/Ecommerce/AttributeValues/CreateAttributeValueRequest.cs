namespace TD.CitizenAPI.Application.Catalog.AttributeValues;

public class CreateAttributeValueRequest : IRequest<Result<Guid>>
{
    public string Value { get; set; } = default!;
    public Guid? AttributeId { get; set; }
    public int Position { get; set; } = 0;
    public bool IsDefault { get; set; } = false;
}

public class CreateAttributeValueRequestValidator : CustomValidator<CreateAttributeValueRequest>
{
    public CreateAttributeValueRequestValidator(IReadRepository<AttributeValue> repository, IStringLocalizer<CreateAttributeValueRequestValidator> localizer) =>
        RuleFor(p => p.Value).NotEmpty();
}

public class CreateAttributeValueRequestHandler : IRequestHandler<CreateAttributeValueRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Domain.Catalog.AttributeValue> _repository;

    public CreateAttributeValueRequestHandler(IRepositoryWithEvents<Domain.Catalog.AttributeValue> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateAttributeValueRequest request, CancellationToken cancellationToken)
    {
        var item = new AttributeValue(request.Value, request.AttributeId, request.Position, request.IsDefault, 1);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}