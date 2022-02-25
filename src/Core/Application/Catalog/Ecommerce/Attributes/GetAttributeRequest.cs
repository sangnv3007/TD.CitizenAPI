using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class GetAttributeRequest : IRequest<Result<AttributeDetailsDto>>
{
    public Guid Id { get; set; }

    public GetAttributeRequest(Guid id) => Id = id;
}

public class AttributeByIdSpec : Specification<Attribute, AttributeDetailsDto>, ISingleResultSpecification
{
    public AttributeByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetAttributeRequestHandler : IRequestHandler<GetAttributeRequest, Result<AttributeDetailsDto>>
{
    private readonly IRepository<Attribute> _repository;
    private readonly IStringLocalizer<GetAttributeRequestHandler> _localizer;

    public GetAttributeRequestHandler(IRepository<Attribute> repository, IStringLocalizer<GetAttributeRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<AttributeDetailsDto>> Handle(GetAttributeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Attribute, AttributeDetailsDto>)new AttributeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Attribute.notfound"], request.Id));
        return Result<AttributeDetailsDto>.Success(item);

    }
}