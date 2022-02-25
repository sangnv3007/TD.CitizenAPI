using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.AttributeValues;

public class SearchAttributeValuesRequest : PaginationFilter, IRequest<PaginationResponse<AttributeValueDto>>
{
    public Guid? AttributeId { get; set; }
}

public class AttributesBySearchRequestSpec : EntitiesByPaginationFilterSpec<AttributeValue, AttributeValueDto>
{
    public AttributesBySearchRequestSpec(SearchAttributeValuesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy())
        .Where(p => p.AttributeId == request.AttributeId, request.AttributeId.HasValue)
        ;
}

public class SearchHotlineCategoriesRequestHandler : IRequestHandler<SearchAttributeValuesRequest, PaginationResponse<AttributeValueDto>>
{
    private readonly IReadRepository<AttributeValue> _repository;

    public SearchHotlineCategoriesRequestHandler(IReadRepository<AttributeValue> repository) => _repository = repository;

    public async Task<PaginationResponse<AttributeValueDto>> Handle(SearchAttributeValuesRequest request, CancellationToken cancellationToken)
    {
        var spec = new AttributesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AttributeValueDto>(list, count, request.PageNumber, request.PageSize);
    }
}