using TD.CitizenAPI.Application.Catalog.Areas;

namespace TD.CitizenAPI.Application.Identity.Users;

public class UserDto
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set;}

    public bool IsActive { get; set; } = true;
    public bool IsVerified { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public string? ImageUrl { get; set; }

}