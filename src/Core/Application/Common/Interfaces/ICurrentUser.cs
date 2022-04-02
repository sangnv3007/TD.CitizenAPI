using System.Security.Claims;

namespace TD.CitizenAPI.Application.Common.Interfaces;

public interface ICurrentUser
{
    string? Name { get; }
    string? GetUserName();
    string? GetFullName();
    Guid GetUserId();

    string? GetUserEmail();

    string? GetTenant();

    bool IsAuthenticated();

    bool IsInRole(string role);

    IEnumerable<Claim>? GetUserClaims();
}