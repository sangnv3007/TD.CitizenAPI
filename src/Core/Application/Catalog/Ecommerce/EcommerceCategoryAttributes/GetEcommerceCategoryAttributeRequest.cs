namespace TD.CitizenAPI.Application.Catalog.EcommerceCategoryAttributes;

public class GetEcommerceCategoryAttributeRequest : IRequest<Result<EcommerceCategoryAttributeDetailsDto>>
{
    public Guid Id { get; set; }

    public GetEcommerceCategoryAttributeRequest(Guid id) => Id = id;
}

public class EcommerceCategoryAttributeByIdSpec : Specification<EcommerceCategoryAttribute, EcommerceCategoryAttributeDetailsDto>, ISingleResultSpecification
{
    public EcommerceCategoryAttributeByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.Attribute)
        .Include(p => p.EcommerceCategory)
        ;
}

public class GetEcommerceCategoryAttributeRequestHandler : IRequestHandler<GetEcommerceCategoryAttributeRequest, Result<EcommerceCategoryAttributeDetailsDto>>
{
    private readonly IRepository<EcommerceCategoryAttribute> _repository;
    private readonly IStringLocalizer<GetEcommerceCategoryAttributeRequestHandler> _localizer;

    public GetEcommerceCategoryAttributeRequestHandler(IRepository<EcommerceCategoryAttribute> repository, IStringLocalizer<GetEcommerceCategoryAttributeRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<EcommerceCategoryAttributeDetailsDto>> Handle(GetEcommerceCategoryAttributeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<EcommerceCategoryAttribute, EcommerceCategoryAttributeDetailsDto>)new EcommerceCategoryAttributeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["EcommerceCategoryAttribute.notfound"], request.Id));
        return Result<EcommerceCategoryAttributeDetailsDto>.Success(item);

    }
}