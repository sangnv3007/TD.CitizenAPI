using TD.CitizenAPI.Application.Catalog.EcommerceCategories;
using TD.CitizenAPI.Application.Catalog.EcommerceCategoryAttributes;
using TD.CitizenAPI.Application.Catalog.MarketProducts;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class EcommerceCategoriesController : VersionedApiController
{
    [HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Search categories using available filters.", "")]
    public Task<PaginationResponse<EcommerceCategoryDto>> SearchAsync(SearchEcommerceCategoriesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpPost("{id:guid}/Attributes/search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Search categories using available filters.", "")]
    public Task<PaginationResponse<EcommerceCategoryAttributeDto>> SearchAsync(SearchEcommerceCategoryAttributesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost("{id:guid}/Attributes")]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Create a new category.", "")]
    public Task<Result<Guid>> CreateAsync(CreateEcommerceCategoryAttributeRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpPut("{id:guid}/Attributes/{idAttribute:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Update a category.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateEcommerceCategoryAttributeRequest request, Guid id, Guid idAttribute)
    {
        return (id != request.AttributeId || idAttribute != request.Id)
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}/Attributes/{idAttribute:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Delete a category.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id, Guid idAttribute)
    {
        return Mediator.Send(new DeleteEcommerceCategoryAttributeRequest(idAttribute));
    }


    [HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Get category details.", "")]
    public Task<Result<EcommerceCategoryDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetEcommerceCategoryRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Create a new category.", "")]
    public Task<Result<Guid>> CreateAsync(CreateEcommerceCategoryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Update a category.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateEcommerceCategoryRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Delete a category.", "")]
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
}