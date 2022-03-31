using TD.CitizenAPI.Application.Catalog.Companies;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class CompaniesController : VersionedApiController
{
    [HttpPost("search")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Danh sách công ty, doanh nghiệp.", "")]
    public Task<PaginationResponse<CompanyDto>> SearchAsync(SearchCompaniesRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("current-company")]
    [OpenApiOperation("Thông tin công ty, doanh nghiệp hiện tại của người dùng.", "")]
    public Task<Result<CompanyDetailsDto>> CurrentCompany()
    {
        return Mediator.Send(new CurrentCompaniesRequest());
    }


    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [TenantIdHeader]
    //[MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Thông tin chi tiết của công ty, doanh nghiệp.", "")]
    public Task<Result<CompanyDetailsDto>> GetAsync(Guid id)
    {
        return Mediator.Send(new GetCompanyRequest(id));
    }

    [HttpPost]
    //[MustHavePermission(FSHAction.Create, FSHResource.Brands)]
    [OpenApiOperation("Tạo mới công ty, doanh nghiệp.", "")]
    public Task<Result<Guid>> CreateAsync(CreateCompanyRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    //[MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Cập nhật công ty, doanh nghiệp.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateCompanyRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    //[MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Xóa công ty, doanh nghiệp.", "")]
    public Task<Result<Guid>> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteCompanyRequest(id));
    }

   
}