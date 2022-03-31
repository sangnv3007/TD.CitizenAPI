using TD.CitizenAPI.Application.Catalog.Salaries;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class SalariesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách mức lương.", "")]
    public Task<PaginationResponse<SalaryDto>> SearchAsync(SearchSalariesRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết mức lương.", "")]
    public Task<Result<SalaryDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetSalaryRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới mức lương.", "")]
    public Task<Result<Guid>> CreateAsync(CreateSalaryRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật mức lương.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateSalaryRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa mức lương.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteSalaryRequest(id));
    }

   
}