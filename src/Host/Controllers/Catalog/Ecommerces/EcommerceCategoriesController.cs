using TD.CitizenAPI.Application.Catalog.EcommerceCategories;
using TD.CitizenAPI.Application.Catalog.EcommerceCategoryAttributes;
using TD.CitizenAPI.Application.Catalog.MarketProducts;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class EcommerceCategoriesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách danh mục sản phẩm.", "")]
    public Task<PaginationResponse<EcommerceCategoryDto>> SearchAsync(SearchEcommerceCategoriesRequest request)
    {
        return Mediator.Send(request);
    }

    [AllowAnonymous]
    [TenantIdHeader]
    [HttpGet("allChild")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Toàn bộ danh mục sản phẩm theo dạng cây cha con.", "")]
    public Task<Result<List<EcommerceCategoryWithChildDto>>> SearchAsyansc()
    {
        return Mediator.Send(new AllEcommerceCategoryRequest());
    }

    [AllowAnonymous]
    [TenantIdHeader]
    [HttpPost("{id:guid}/Attributes/search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách thuộc tính của danh mục sản phẩm.", "")]
    public Task<PaginationResponse<EcommerceCategoryAttributeDto>> SearchAsync(SearchEcommerceCategoryAttributesRequest request, Guid id)
    {
        request.EcommerceCategoryId = id;
        return Mediator.Send(request);
    }


    [HttpPost("{id:guid}/Attributes")]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Thêm mới thuộc tính cho danh mục sản phẩm.", "")]
    public Task<Result<Guid>> CreateAsync(CreateEcommerceCategoryAttributeRequest request, Guid id)
    {
        request.EcommerceCategoryId = id;
        return Mediator.Send(request);
    }


    [HttpPut("{id:guid}/Attributes/{idAttribute:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Update a category.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateEcommerceCategoryAttributeRequest request, Guid id, Guid idAttribute)
    {

        request.EcommerceCategoryId = id;
        request.Id = idAttribute;
        return Ok(await Mediator.Send(request));
        /*return (id != request.EcommerceCategoryId || idAttribute != request.Id)
            ? BadRequest()
            : Ok(await Mediator.Send(request));*/
    }

    [HttpDelete("{id:guid}/Attributes/{idAttribute:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa thuộc tính khỏi danh mục sản phẩm.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id, Guid idAttribute)
    {
        return Mediator.Send(new DeleteEcommerceCategoryAttributeRequest(idAttribute));
    }


    [HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết danh mục sản phẩm.", "")]
    public Task<Result<EcommerceCategoryDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetEcommerceCategoryRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới danh mục sản phẩm.", "")]
    public Task<Result<Guid>> CreateAsync(CreateEcommerceCategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật danh mục sản phẩm.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateEcommerceCategoryRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa danh mục sản phẩm.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteEcommerceCategoryRequest(id));
    }

    /* [HttpPost("fetchdata")]
     //[MustHavePermission(FSHAction.Generate, FSHResource.Brands)]
     [OpenApiOperation("Generate a number of random brands.", "")]
     public Task<string> FetchMarketProductAsync(FetchMarketProductRequest request)
     {
         return Mediator.Send(request);
     }*/

    [HttpPost("fetchdata")]
    //[MustHavePermission(FSHAction.Generate, FSHResource.Brands)]
    [OpenApiOperation("Fetch dữ liệu danh mục sản phẩm Tiki.", "")]
    public Task<string> FetchCategoriesAsync(GenerateEcommerceCategoriesRequest request)
    {
        return Mediator.Send(request);
    }
}