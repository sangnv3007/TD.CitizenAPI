namespace TD.CitizenAPI.Application.Identity.Users;

public class CreateUserRequest
{
    public string FullName { get; set; } = default!;
   
    public string Email { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? IdentityNumber { get; set; }


}