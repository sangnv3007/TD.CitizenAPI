using Microsoft.AspNetCore.Identity;

namespace TD.CitizenAPI.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsVerified { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? IdentityNumber { get; set; }
    public string? IdentityPlace { get; set; }
    public string? IdentityDate { get; set; }
    //Nguyen Quan
    public string? PlaceOfOrigin { get; set; }
    //Thuong tru
    public string? PlaceOfDestination { get; set; }
    //Quoc tich
    public string? Nationality { get; set; }
    public string? ProvinceCode { get; set; }
    public string? DistrictCode { get; set; }
    public string? CommuneCode { get; set; }
    public string? Address { get; set; }
    

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public string? ObjectId { get; set; }
}