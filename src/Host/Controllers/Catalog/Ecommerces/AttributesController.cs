using TD.CitizenAPI.Application.Catalog.Attributes;
using TD.CitizenAPI.Application.Catalog.AttributeValues;
using TD.CitizenAPI.Application.Catalog.MarketCategories;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class AttributesController : VersionedApiController
{
    [HttpPost("search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách danh mục thuộc tính.", "")]
    public Task<PaginationResponse<AttributeDto>> SearchAsync(SearchAttributesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost("{id:guid}/Values/search")]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách giá trị select của thuộc tính (nếu thuộc tính có dạng select).", "")]
    public Task<PaginationResponse<AttributeValueDto>> GetAllValuesInAttribute(SearchAttributeValuesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpPost("{id:guid}/Values")]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới giá trị của thuộc tính.", "")]
    public Task<Result<Guid>> CreateAsync(CreateAttributeValueRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}/Values/{idValue:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật giá trị của thuộc tính.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateAttributeValueRequest request, Guid id, Guid idValue)
    {
        return id != request.AttributeId || idValue != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }


    [HttpDelete("{id:guid}/Values/{idValue:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa giá trị của thuộc tính.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id, Guid idValue)
    {
        return Mediator.Send(new DeleteAttributeValueRequest(idValue));
    }


    [HttpGet("{id:guid}")]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết thuộc tính.", "")]
    public Task<Result<AttributeDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetAttributeRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới thuộc tính.", "")]
    public Task<Result<Guid>> CreateAsync(CreateAttributeRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật thuộc tính.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateAttributeRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa thuộc tính.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteAttributeRequest(id));
    }
}