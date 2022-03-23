namespace TD.CitizenAPI.Application.Identity.Users;

public class CreateUserRequest
{
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = "Tandan@123";
    public string ConfirmPassword { get; set; } = "Tandan@123";
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }
    public string? IdentityNumber { get; set; }

    public string? IdentityPlace { get; set; }
    public DateTime? IdentityDate { get; set; }
    public string? ProvinceId { get; set; }
    public string? DistrictId { get; set; }
    public string? CommuneId { get; set; }
    public string? Address { get; set; }
    public string? ImageUrl { get; set; }



}