namespace TD.CitizenAPI.Application.Identity.Users;

public class VerifyUserRequest
{
    public string? FullName { get; set; }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    //public string? ImageUrl { get; set; }
    public string? IdentityNumber { get; set; }
    public string? IdentityPlace { get; set; }
    public DateTime? IdentityDate { get; set; }
    //Nguyen Quan
    public string? PlaceOfOrigin { get; set; }
    //Thuong tru
    public string? PlaceOfDestination { get; set; }
    //Quoc tich
    public string? Nationality { get; set; }
}