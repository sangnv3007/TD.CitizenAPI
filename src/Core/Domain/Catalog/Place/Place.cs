namespace TD.CitizenAPI.Domain.Catalog;

public class Place : AuditableEntity, IAggregateRoot
{
    public string? PlaceName { get; set; }
    public string? Title { get; set; }
    public string? AddressDetail { get; set; }
    public string? Source { get; set; }
    public string? ExtraInfo { get; set; }
    public string? PhoneContact { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? Content { get; set; }
    public string? ContentHtml { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public string? Tags { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Status { get; set; }

    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public DateTime? TimeStart { get; set; }
    public DateTime? TimeEnd { get; set; }

    public Guid? PlaceTypeId { get; set; }
    public virtual PlaceType? PlaceType { get; set; }

    public Guid? ProvinceId { get; set; }
    public virtual Area? Province { get; set; }
    public Guid? DistrictId { get; set; }
    public virtual Area? District { get; set; }
    public Guid? CommuneId { get; set; }
    public virtual Area? Commune { get; set; }

    public Place(string? placeName, string? title, string? addressDetail, string? source, string? extraInfo, string? phoneContact, string? website, string? email, string? content, string? contentHtml, double? latitude, double? longitude, string? tags, string? image, string? images, string? status, DateTime? dateStart, DateTime? dateEnd, DateTime? timeStart, DateTime? timeEnd, Guid? placeTypeId, Guid? provinceId, Guid? districtId, Guid? communeId)
    {
        PlaceName = placeName;
        Title = title;
        AddressDetail = addressDetail;
        Source = source;
        ExtraInfo = extraInfo;
        PhoneContact = phoneContact;
        Website = website;
        Email = email;
        Content = content;
        ContentHtml = contentHtml;
        Latitude = latitude;
        Longitude = longitude;
        Tags = tags;
        Image = image;
        Images = images;
        Status = status;
        DateStart = dateStart;
        DateEnd = dateEnd;
        TimeStart = timeStart;
        TimeEnd = timeEnd;
        PlaceTypeId = placeTypeId;
        ProvinceId = provinceId;
        DistrictId = districtId;
        CommuneId = communeId;
    }

    public Place Update(string? placeName, string? title, string? addressDetail, string? source, string? extraInfo, string? phoneContact, string? website, string? email, string? content, string? contentHtml, double? latitude, double? longitude, string? tags, string? image, string? images, string? status, DateTime? dateStart, DateTime? dateEnd, DateTime? timeStart, DateTime? timeEnd, Guid? placeTypeId, Guid? provinceId, Guid? districtId, Guid? communeId)
    {
        if (placeName is not null && PlaceName?.Equals(placeName) is not true) PlaceName = placeName;
        if (title is not null && Title?.Equals(title) is not true) Title = title;
        if (addressDetail is not null && AddressDetail?.Equals(addressDetail) is not true) AddressDetail = addressDetail;
        if (source is not null && Source?.Equals(source) is not true) Source = source;
        if (extraInfo is not null && ExtraInfo?.Equals(extraInfo) is not true) ExtraInfo = extraInfo;
        if (phoneContact is not null && PhoneContact?.Equals(phoneContact) is not true) PhoneContact = phoneContact;
        if (website is not null && Website?.Equals(website) is not true) Website = website;
        if (email is not null && Email?.Equals(email) is not true) Email = email;
        if (content is not null && Content?.Equals(content) is not true) Content = content;
        if (tags is not null && Tags?.Equals(tags) is not true) Tags = tags;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (images is not null && Images?.Equals(images) is not true) Images = images;
        if (status is not null && Status?.Equals(status) is not true) Status = status;
        if (contentHtml is not null && ContentHtml?.Equals(contentHtml) is not true) ContentHtml = contentHtml;

        if (latitude.HasValue && !Latitude.Equals(latitude.Value)) Latitude = latitude.Value;
        if (longitude.HasValue && !Longitude.Equals(longitude.Value)) Longitude = longitude.Value;

        if (dateStart.HasValue && !DateStart.Equals(dateStart.Value)) DateStart = dateStart.Value;
        if (dateEnd.HasValue && !DateEnd.Equals(dateEnd.Value)) DateEnd = dateEnd.Value;
        if (timeStart.HasValue && !TimeStart.Equals(timeStart.Value)) TimeStart = timeStart.Value;
        if (timeEnd.HasValue && !TimeEnd.Equals(timeEnd.Value)) TimeEnd = timeEnd.Value;

        if (provinceId.HasValue && provinceId.Value != Guid.Empty && !ProvinceId.Equals(provinceId.Value)) ProvinceId = provinceId.Value;
        if (districtId.HasValue && districtId.Value != Guid.Empty && !DistrictId.Equals(districtId.Value)) DistrictId = districtId.Value;
        if (communeId.HasValue && communeId.Value != Guid.Empty && !CommuneId.Equals(communeId.Value)) CommuneId = communeId.Value;
        if (placeTypeId.HasValue && placeTypeId.Value != Guid.Empty && !PlaceTypeId.Equals(placeTypeId.Value)) PlaceTypeId = placeTypeId.Value;
        return this;
    }
}