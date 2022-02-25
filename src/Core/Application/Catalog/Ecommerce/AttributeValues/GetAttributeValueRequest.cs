namespace TD.CitizenAPI.Application.Catalog.AttributeValues;

public class GetAttributeValueRequest : IRequest<Result<AttributeValueDetailsDto>>
{
    public Guid Id { get; set; }

    public GetAttributeValueRequest(Guid id) => Id = id;
}

public class AttributeValueByIdSpec : Specification<AttributeValue, AttributeValueDetailsDto>, ISingleResultSpecification
{
    public AttributeValueByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetAttributeValueRequestHandler : IRequestHandler<GetAttributeValueRequest, Result<AttributeValueDetailsDto>>
{
    private readonly IRepository<AttributeValue> _repository;
    private readonly IStringLocalizer<GetAttributeValueRequestHandler> _localizer;

    public GetAttributeValueRequestHandler(IRepository<AttributeValue> repository, IStringLocalizer<GetAttributeValueRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<AttributeValueDetailsDto>> Handle(GetAttributeValueRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<AttributeValue, AttributeValueDetailsDto>)new AttributeValueByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Attribute.notfound"], request.Id));
        return Result<AttributeValueDetailsDto>.Success(item);

    }
}