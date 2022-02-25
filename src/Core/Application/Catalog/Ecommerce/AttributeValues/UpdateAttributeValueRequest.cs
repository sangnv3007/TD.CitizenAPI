namespace TD.CitizenAPI.Application.Catalog.AttributeValues;

public class UpdateAttributeValueRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public Guid? AttributeId { get; set; }
    public int? Position { get; set; }
    public bool? IsDefault { get; set; }
}

public class UpdateAttributeValueRequestValidator : CustomValidator<UpdateAttributeValueRequest>
{
    public UpdateAttributeValueRequestValidator(IRepository<AttributeValue> repository, IStringLocalizer<UpdateAttributeValueRequestValidator> localizer)
    {
        RuleFor(p => p.Value)
            .NotEmpty();
       
    }
}

public class UpdateAttributeValueRequestHandler : IRequestHandler<UpdateAttributeValueRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AttributeValue> _repository;
    private readonly IStringLocalizer<UpdateAttributeValueRequestHandler> _localizer;

    public UpdateAttributeValueRequestHandler(IRepositoryWithEvents<AttributeValue> repository, IStringLocalizer<UpdateAttributeValueRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateAttributeValueRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["hotlinecategory.notfound"], request.Id));

        item.Update(request.Value, request.AttributeId, request.Position, request.IsDefault);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}