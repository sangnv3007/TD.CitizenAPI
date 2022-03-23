namespace TD.CitizenAPI.Application.Identity.Users;

public class UserListFilter : PaginationFilter
{
    public bool? IsActive { get; set; }
    public bool? IsVerified { get; set; }
    public string? Gender { get; set; }
}