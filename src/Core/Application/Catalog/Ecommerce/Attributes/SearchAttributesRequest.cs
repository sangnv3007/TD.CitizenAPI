using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class SearchAttributesRequest : PaginationFilter, IRequest<PaginationResponse<AttributeDto>>
{
}

public class AttributesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Attribute, AttributeDto>
{
    public AttributesBySearchRequestSpec(SearchAttributesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy());
}

public class SearchHotlineCategoriesRequestHandler : IRequestHandler<SearchAttributesRequest, PaginationResponse<AttributeDto>>
{
    private readonly IReadRepository<Attribute> _repository;

    public SearchHotlineCategoriesRequestHandler(IReadRepository<Attribute> repository) => _repository = repository;

    public async Task<PaginationResponse<AttributeDto>> Handle(SearchAttributesRequest request, CancellationToken cancellationToken)
    {
        var spec = new AttributesBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<AttributeDto>(list, count, request.PageNumber, request.PageSize);
    }
}