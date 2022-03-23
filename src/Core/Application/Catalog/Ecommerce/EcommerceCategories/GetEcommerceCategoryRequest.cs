using System.Linq;

namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class GetEcommerceCategoryRequest : IRequest<Result<EcommerceCategoryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetEcommerceCategoryRequest(Guid id) => Id = id;
}

public class EcommerceCategoryByIdSpec : Specification<EcommerceCategory, EcommerceCategoryDetailsDto>, ISingleResultSpecification
{
    public EcommerceCategoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id).
        Include(p => p.Parent)
        ;
}

public class GetEcommerceCategoryRequestHandler : IRequestHandler<GetEcommerceCategoryRequest, Result<EcommerceCategoryDetailsDto>>
{
    private readonly IRepository<EcommerceCategory> _repository;
    private readonly IStringLocalizer<GetEcommerceCategoryRequestHandler> _localizer;

    public GetEcommerceCategoryRequestHandler(IRepository<EcommerceCategory> repository, IStringLocalizer<GetEcommerceCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<EcommerceCategoryDetailsDto>> Handle(GetEcommerceCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<EcommerceCategory, EcommerceCategoryDetailsDto>)new EcommerceCategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["EcommerceCategory.notfound"], request.Id));


        List<Guid> ids = new List<Guid>();
        var parentId = item.ParentId;
        while (parentId != null)
        {
            ids.Add((Guid)parentId);
            var itemParent = await _repository.GetBySpecAsync(
           (ISpecification<EcommerceCategory, EcommerceCategoryDetailsDto>)new EcommerceCategoryByIdSpec((Guid)parentId), cancellationToken);
            if (itemParent != null)
            {
                parentId = itemParent.ParentId;
            }
        }

        ids.Reverse();

        item.ParentsId = ids;

        return Result<EcommerceCategoryDetailsDto>.Success(item);

    }
}