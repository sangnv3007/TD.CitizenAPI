using System.Security.Claims;

namespace TD.CitizenAPI.Infrastructure.Auth;

public interface ICurrentUserInitializer
{
    void SetCurrentUser(ClaimsPrincipal user);

    void SetCurrentUserId(string userId);
    void SetCurrentUserName(string userName);
}