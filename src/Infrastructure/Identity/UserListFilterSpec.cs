using Ardalis.Specification;
using TD.CitizenAPI.Application.Common.Specification;
using TD.CitizenAPI.Application.Identity.Users;

namespace TD.CitizenAPI.Infrastructure.Identity;

public class UserListFilterSpec : EntitiesByPaginationFilterSpec<ApplicationUser>
{
    public UserListFilterSpec(UserListFilter request)
        : base(request) =>
        Query
            .Where(p => p.Gender == request.Gender, !string.IsNullOrEmpty(request.Gender))
            .Where(p => p.IsActive == request.IsActive, request.IsActive.HasValue)
            .Where(p => p.IsVerified == request.IsVerified, request.IsVerified.HasValue)
        ;
}