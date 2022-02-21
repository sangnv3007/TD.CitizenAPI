namespace TD.CitizenAPI.Domain.Catalog;

public class Company : AuditableEntity, IAggregateRoot
{
    public string? UserName { get; set; }
    public string Name { get; set; }
    public string? InternationalName { get; set; }
    public string? ShortName { get; set; }
    public string? TaxCode { get; set; }
    //Dia chi cong ty
    public string? Address { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
    //Dai dien
    public string? Representative { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? ProfileVideo { get; set; }
    public string? Fax { get; set; }
    //Ngay cap
    public DateTime? DateOfIssue { get; set; }
    //Linh vuc kinh doanh
    public string? BusinessSector { get; set; }
    public string? Images { get; set; }
    public string? Image { get; set; }
    public string? Logo { get; set; }
    public string? Description { get; set; }
    //Quy mo cong ty
    public string? CompanySize { get; set; }

    public virtual Area? Province { get; set; }
    public virtual Area? District { get; set; }
    public virtual Area? Commune { get; set; }

    public Company(string? userName, string name, string? internationalName, string? shortName, string? taxCode, string? address, double? latitude, double? longitude, Guid? provinceId, Guid? districtId, Guid? communeId, string? representative, string? phoneNumber, string? website, string? email, string? profileVideo, string? fax, DateTime? dateOfIssue, string? businessSector, string? images, string? image, string? logo, string? description, string? companySize)
    {
        UserName = userName;
        Name = name;
        InternationalName = internationalName;
        ShortName = shortName;
        TaxCode = taxCode;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        ProvinceId = provinceId;
        DistrictId = districtId;
        CommuneId = communeId;
        Representative = representative;
        PhoneNumber = phoneNumber;
        Website = website;
        Email = email;
        ProfileVideo = profileVideo;
        Fax = fax;
        DateOfIssue = dateOfIssue;
        BusinessSector = businessSector;
        Images = images;
        Image = image;
        Logo = logo;
        Description = description;
        CompanySize = companySize;
    }

    public Company Update(string? userName, string? name, string? internationalName, string? shortName, string? taxCode, string? address, double? latitude, double? longitude, Guid? provinceId, Guid? districtId, Guid? communeId, string? representative, string? phoneNumber, string? website, string? email, string? profileVideo, string? fax, DateTime? dateOfIssue, string? businessSector, string? images, string? image, string? logo, string? description, string? companySize)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (internationalName is not null && InternationalName?.Equals(internationalName) is not true) InternationalName = internationalName;
        if (shortName is not null && ShortName?.Equals(shortName) is not true) ShortName = shortName;
        if (representative is not null && Representative?.Equals(representative) is not true) Representative = representative;
        if (phoneNumber is not null && PhoneNumber?.Equals(phoneNumber) is not true) PhoneNumber = phoneNumber;
        if (website is not null && Website?.Equals(website) is not true) Website = website;
        if (taxCode is not null && TaxCode?.Equals(taxCode) is not true) TaxCode = taxCode;
        if (email is not null && Email?.Equals(email) is not true) Email = email;
        if (profileVideo is not null && ProfileVideo?.Equals(profileVideo) is not true) ProfileVideo = profileVideo;
        if (fax is not null && Fax?.Equals(fax) is not true) Fax = fax;
        if (businessSector is not null && BusinessSector?.Equals(businessSector) is not true) BusinessSector = businessSector;
        if (images is not null && Images?.Equals(images) is not true) Images = images;
        if (image is not null && Image?.Equals(taxCode) is not true) Image = taxCode;
        if (logo is not null && Logo?.Equals(logo) is not true) Logo = logo;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (companySize is not null && CompanySize?.Equals(companySize) is not true) CompanySize = companySize;


        if (address is not null && Address?.Equals(address) is not true) Address = address;
        if (provinceId.HasValue && provinceId.Value != Guid.Empty && !ProvinceId.Equals(provinceId.Value)) ProvinceId = provinceId.Value;
        if (districtId.HasValue && districtId.Value != Guid.Empty && !DistrictId.Equals(districtId.Value)) DistrictId = districtId.Value;
        if (communeId.HasValue && communeId.Value != Guid.Empty && !CommuneId.Equals(communeId.Value)) CommuneId = communeId.Value;
        if (latitude.HasValue && !Latitude.Equals(latitude.Value)) Latitude = latitude.Value;
        if (longitude.HasValue && !Longitude.Equals(longitude.Value)) Longitude = longitude.Value;
        if (dateOfIssue.HasValue && !DateOfIssue.Equals(dateOfIssue.Value)) DateOfIssue = dateOfIssue.Value;

        return this;
    }
}