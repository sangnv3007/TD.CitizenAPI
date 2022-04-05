using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TD.CitizenAPI.Application.Identity.Users.Password;

namespace TD.CitizenAPI.Application.Identity.Users;

public interface IUserService : ITransientService
{
    Task<PaginationResponse<UserDto>> SearchAsync(UserListFilter filter, CancellationToken cancellationToken);

    Task<bool> ExistsWithNameAsync(string name);
    Task<bool> ExistsWithEmailAsync(string email, string? exceptId = null);
    Task<bool> ExistsWithPhoneNumberAsync(string phoneNumber, string? exceptId = null);
    Task<bool> ExistsWithIdentityNumberAsync(string identityNumber, string? exceptId = null);


    Task<List<UserDetailsDto>> GetListAsync(CancellationToken cancellationToken);

    Task<int> GetCountAsync(CancellationToken cancellationToken);

    Task<UserDetailsDto> GetAsyncByUserName(string userName, CancellationToken cancellationToken);
    Task<UserDetailsDto> GetAsyncByIdentityNumberName(string identityNumber, CancellationToken cancellationToken);


    Task<UserDetailsDto> GetAsync(string userId, CancellationToken cancellationToken);

    Task<List<UserRoleDto>> GetRolesAsyncByUserName(string userName, CancellationToken cancellationToken);
    Task<List<UserRoleDto>> GetRolesAsync(string userId, CancellationToken cancellationToken);
    Task<string> AssignRolesAsync(string userId, UserRolesRequest request, CancellationToken cancellationToken);
    Task<string> AssignRolesAsyncByUserName(string userName, UserRolesRequest request, CancellationToken cancellationToken);


    Task<List<string>> GetPermissionsAsyncByUserName(string userName, CancellationToken cancellationToken);
    Task<List<string>> GetPermissionsAsync(string userId, CancellationToken cancellationToken);
    Task<bool> HasPermissionAsync(string userId, string permission, CancellationToken cancellationToken = default);
    Task InvalidatePermissionCacheAsync(string userId, CancellationToken cancellationToken);

    Task ToggleStatusAsync(ToggleUserStatusRequest request, CancellationToken cancellationToken);

    Task<string> GetOrCreateFromPrincipalAsync(ClaimsPrincipal principal);
    Task<string> CreateAsync(CreateUserRequest request, string origin);
    Task UpdateAsync(UpdateUserRequest request, string userId);

    Task UpdateLocationAsync(UpdateUserLocationRequest request, string userId);


    Task<bool> UpdateAsyncByUserName(UpdateUserRequest request, string userName);


    Task<bool> VerifyAsyncByUserName(VerifyUserRequest request, string userName);

    Task<string> ConfirmEmailAsync(string userId, string code, string tenant, CancellationToken cancellationToken);
    Task<string> ConfirmPhoneNumberAsync(string userId, string code);

    Task<string> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
    Task<string> ResetPasswordAsync(ResetPasswordRequest request);
    Task ChangePasswordAsync(ChangePasswordRequest request, string userId);
    Task UpdateAvatar(IFormFile? request, string userId);

    

}