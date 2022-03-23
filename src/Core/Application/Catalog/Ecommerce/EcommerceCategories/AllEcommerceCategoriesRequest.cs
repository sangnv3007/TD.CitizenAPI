using Mapster;

namespace TD.CitizenAPI.Application.Catalog.EcommerceCategories;

public class AllEcommerceCategoryRequest : IRequest<Result<List<EcommerceCategoryWithChildDto>>>
{
    public AllEcommerceCategoryRequest()
    {
    }
}

public class AllEcommerceCategoryRequestHandler : IRequestHandler<AllEcommerceCategoryRequest, Result<List<EcommerceCategoryWithChildDto>>>
{
    private readonly IRepository<EcommerceCategory> _repository;
    private readonly IStringLocalizer<AllEcommerceCategoryRequestHandler> _localizer;

    public AllEcommerceCategoryRequestHandler(IRepository<EcommerceCategory> repository, IStringLocalizer<AllEcommerceCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<List<EcommerceCategoryWithChildDto>>> Handle(AllEcommerceCategoryRequest request, CancellationToken cancellationToken)
    {
        var list = await getListCategory(null, cancellationToken);

        return Result<List<EcommerceCategoryWithChildDto>>.Success(list);

    }


    private async Task<List<EcommerceCategoryWithChildDto>> getListCategory(Guid? ParentId, CancellationToken cancellationToken)
    {
        List<EcommerceCategoryWithChildDto> list = new List<EcommerceCategoryWithChildDto>();

        var categories = await _repository.ListAsync(new EcommerceCategoriesByParentSpec(ParentId), cancellationToken);
        foreach (var cate in categories)
        {
            var mapped = cate.Adapt<EcommerceCategoryWithChildDto> ();
            mapped.Categories = await getListCategory(cate.Id, cancellationToken);
            list.Add(mapped);
        }

        return list;
    }

}