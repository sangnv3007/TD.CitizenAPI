using TD.CitizenAPI.Application.Catalog.Attachments;
using TD.CitizenAPI.Application.Catalog.Products;

namespace TD.CitizenAPI.Host.Controllers.Catalog;

public class AttachmentsController : VersionedApiController
{
    [HttpPost]
    [DisableRequestSizeLimit]
    //[MustHavePermission(FSHAction.Create, FSHResource.Products)]
    [OpenApiOperation("Create a new attachment.", "")]
    public async Task<IActionResult> Post([FromForm(Name = "files")] List<IFormFile> files)
    {
        return Ok(await Mediator.Send(new CreateAttachmentRequest() { Files = files }));
    }
    /* public Task<Guid> CreateAsync(CreateAttachmentRequest request)
     {
         return Mediator.Send(request);
     }*/
 }