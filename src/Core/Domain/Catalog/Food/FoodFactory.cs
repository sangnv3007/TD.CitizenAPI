namespace TD.CitizenAPI.Domain.Catalog;

public class FoodFactory : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Address { get; set; }
    //Linh vuc kinh doanh
    public string? BusinessArea { get; set; }

    //So chung nhan
    public string? CertificationNumber { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Description { get; set; }
    //Chu co so
    public string? OwnerName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? TaxCode { get; set; }
    //Dia chi cong ty
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Files { get; set; }
    //Ngay cap
    public DateTime? DateOfIssue { get; set; }
    //Ngay het han
    public DateTime? ExpirationDate { get; set; }

    public FoodFactory(string name, string? address, string? businessArea, string? certificationNumber, string? image, string? images, string? description, string? ownerName, string? email, string? phone, string? taxCode, double? latitude, double? longitude, string? files, DateTime? dateOfIssue, DateTime? expirationDate)
    {
        Name = name;
        Address = address;
        BusinessArea = businessArea;
        CertificationNumber = certificationNumber;
        Image = image;
        Images = images;
        Description = description;
        OwnerName = ownerName;
        Email = email;
        Phone = phone;
        TaxCode = taxCode;
        Latitude = latitude;
        Longitude = longitude;
        Files = files;
        DateOfIssue = dateOfIssue;
        ExpirationDate = expirationDate;
    }

    public FoodFactory Update(string? name, string? address, string? businessArea, string? certificationNumber, string? image, string? images, string? description, string? ownerName, string? email, string? phone, string? taxCode, double? latitude, double? longitude, string? files, DateTime? dateOfIssue, DateTime? expirationDate)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (address is not null && Address?.Equals(address) is not true) Address = address;
        if (businessArea is not null && BusinessArea?.Equals(businessArea) is not true) BusinessArea = businessArea;
        if (certificationNumber is not null && CertificationNumber?.Equals(certificationNumber) is not true) CertificationNumber = certificationNumber;
        if (ownerName is not null && OwnerName?.Equals(ownerName) is not true) OwnerName = ownerName;

        if (email is not null && Email?.Equals(email) is not true) Email = email;
        if (phone is not null && Phone?.Equals(phone) is not true) Phone = phone;
        if (taxCode is not null && TaxCode?.Equals(taxCode) is not true) TaxCode = taxCode;
        if (files is not null && Files?.Equals(files) is not true) Files = files;

        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (images is not null && Images?.Equals(images) is not true) Images = images;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        if (dateOfIssue.HasValue && !DateOfIssue.Equals(dateOfIssue.Value)) DateOfIssue = dateOfIssue.Value;
        if (expirationDate.HasValue && !ExpirationDate.Equals(expirationDate.Value)) ExpirationDate = expirationDate.Value;

        if (latitude.HasValue && !Latitude.Equals(latitude.Value)) Latitude = latitude.Value;
        if (longitude.HasValue && !Longitude.Equals(longitude.Value)) Longitude = longitude.Value;


        return this;
    }
}