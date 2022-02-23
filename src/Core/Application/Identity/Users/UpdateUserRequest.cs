namespace TD.CitizenAPI.Application.Identity.Users;

public class UpdateUserRequest
{
    public string Id { get; set; } = default!;
    public string? FullName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    //public FileUploadRequest? Image { get; set; }
    //public bool DeleteCurrentImage { get; set; } = false;

    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    //public string? ImageUrl { get; set; }
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

}