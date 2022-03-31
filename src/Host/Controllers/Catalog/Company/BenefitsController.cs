using TD.CitizenAPI.Application.Catalog.Benefits;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class BenefitsController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách phúc lợi của công ty.", "")]
    public Task<PaginationResponse<BenefitDto>> SearchAsync(SearchBenefitsRequest request)
    {
        return Mediator.Send(request);
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Chi tiết phúc lợi của công ty.", "")]
    public Task<Result<BenefitDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetBenefitRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới phúc lợi của công ty.", "")]
    public Task<Result<Guid>> CreateAsync(CreateBenefitRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật phúc lợi của công ty.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateBenefitRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa phúc lợi của công ty.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteBenefitRequest(id));
    }

   
}