using System.Security.Claims;
using TD.CitizenAPI.Application.Auditing;
using TD.CitizenAPI.Application.Catalog.EKYCAttachments;
using TD.CitizenAPI.Application.Identity.Users;
using TD.CitizenAPI.Application.Identity.Users.Password;

namespace TD.CitizenAPI.Host.Controllers.Identity;

public class PersonalController : VersionNeutralApiController
{
    private readonly IUserService _userService;

    public PersonalController(IUserService userService) => _userService = userService;

    [HttpGet("profile")]
    [OpenApiOperation("Chi tiết thông tin người dùng hiện tại.", "")]
    public async Task<ActionResult<UserDetailsDto>> GetProfileAsync(CancellationToken cancellationToken)
    {
        return User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId)
            ? Unauthorized()
            : Ok(await _userService.GetAsync(userId, cancellationToken));
    }

   /* [HttpGet("user-infor")]
    public async Task<IActionResult> UserInfor()
    {
        return Ok(await _identityService.GetUserInfor());
    }*/

    [HttpPut("profile")]
    [OpenApiOperation("Cập nhật thông tin người dùng hiện tại.", "")]
    public async Task<ActionResult> UpdateProfileAsync(UpdateUserRequest request)
    {
        if (User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        await _userService.UpdateAsync(request, userId);
        return Ok();
    }

    [HttpPut("update-location")]
    [OpenApiOperation("Cập nhật vị trí người dùng hiện tại.", "")]
    public async Task<ActionResult> UpdateLocationAsync(UpdateUserLocationRequest request)
    {
        if (User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        await _userService.UpdateLocationAsync(request, userId);
        return Ok();
    }

    [HttpPut("change-password")]
    [OpenApiOperation("Đổi mật khẩu.", "")]
    [ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Register))]
    public async Task<ActionResult> ChangePasswordAsync(ChangePasswordRequest model)
    {
        if (User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        await _userService.ChangePasswordAsync(model, userId);
        return Ok();
    }


    [HttpPost("update-avatar")]
    [OpenApiOperation("Cập nhật avatar.", "")]
    [DisableRequestSizeLimit]
    public async Task<IActionResult> UpdateAvatar([FromForm(Name = "file")] IFormFile file)
    {
        if (User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        await _userService.UpdateAvatar(file, userId);
        return Ok();
    }


    [HttpGet("permissions")]
    [OpenApiOperation("Danh sách quyền của người dùng hiện tại.", "")]
    public async Task<ActionResult<List<string>>> GetPermissionsAsync(CancellationToken cancellationToken)
    {
        return User.GetUserId() is not { } userId || string.IsNullOrEmpty(userId)
            ? Unauthorized()
            : Ok(await _userService.GetPermissionsAsync(userId, cancellationToken));
    }

    [HttpGet("logs")]
    [OpenApiOperation("Danh sách lịch sử thao tác của người dùng hiện tại.", "")]
    public Task<List<AuditDto>> GetLogsAsync()
    {
        return Mediator.Send(new GetMyAuditLogsRequest());
    }

    [HttpPost("ekyc")]
    [DisableRequestSizeLimit]
    //[MustHavePermission(FSHAction.Create, FSHResource.Products)]
    [OpenApiOperation("Create a new attachment.", "")]
    public async Task<IActionResult> Post([FromForm(Name = "file")] IFormFile file, [FromForm(Name = "imageType")] string imageType)
    {
        return Ok(await Mediator.Send(new CreateEKYCAttachmentRequest() { File = file, ImageType = imageType }));
    }

    [HttpGet("ekyc")]
    //[MustHavePermission(FSHAction.Create, FSHResource.Products)]
    [OpenApiOperation("Toàn bộ ảnh eKYC của người dùng.", "")]
    public Task<Result<List<EKYCAttachmentDto>>> SearchAsyansc()
    {
        return Mediator.Send(new AllEKYCAttachmentRequest());
    }

    [HttpGet("verify-user")]
    //[MustHavePermission(FSHAction.Create, FSHResource.Products)]
    [OpenApiOperation("Kiểm tra xác thực người dùng.", "")]
    public Task<Result<bool>> VerifyUserAsyansc()
    {
        return Mediator.Send(new VerifyUserWitheKYCRequest());
    }
}