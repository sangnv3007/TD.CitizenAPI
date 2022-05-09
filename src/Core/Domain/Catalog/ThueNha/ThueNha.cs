namespace TD.CitizenAPI.Domain.Catalog;

public class ThueNha : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
   
    public string? Description { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }

    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
    public string? Address { get; set; }

    public Guid? LoaiNhaId { get; set; }
    public Guid? ThoiGianThueNhaId { get; set; }
    public Guid? DienTichNhaId { get; set; }
    public Guid? MucGiaThueNhaId { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public virtual DienTichNha? DienTichNha { get; set; }
    public virtual MucGiaThueNha? MucGiaThueNha { get; set; }
    public virtual ThoiGianThueNha? ThoiGianThueNha { get; set; }
    public virtual LoaiNha? LoaiNha { get; set; }
    public virtual Area? Province { get; set; }
    public virtual Area? District { get; set; }
    public virtual Area? Commune { get; set; }

    public ThueNha(string name, string? description, string? contactName, string? contactPhone, string? image, string? images, Guid? provinceId, Guid? districtId, Guid? communeId, string? address, double? latitude, double? longitude, Guid? loaiNhaId, Guid? thoiGianThueNhaId, Guid? dienTichNhaId, Guid? mucGiaThueNhaId)
    {
        Name = name;
        Description = description;
        ContactName = contactName;
        ContactPhone = contactPhone;
        Image = image;
        Images = images;
        ProvinceId = provinceId;
        DistrictId = districtId;
        CommuneId = communeId;
        Address = address;
        LoaiNhaId = loaiNhaId;
        ThoiGianThueNhaId = thoiGianThueNhaId;
        DienTichNhaId = dienTichNhaId;
        MucGiaThueNhaId = mucGiaThueNhaId;
        Latitude = latitude;
        Longitude = longitude;
    }

    public ThueNha Update(string? name, string? description, string? contactName, string? contactPhone, string? image, string? images, Guid? provinceId, Guid? districtId, Guid? communeId, string? address, double? latitude, double? longitude, Guid? loaiNhaId, Guid? thoiGianThueNhaId, Guid? dienTichNhaId, Guid? mucGiaThueNhaId)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (contactName is not null && ContactName?.Equals(contactName) is not true) ContactName = contactName;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (images is not null && Images?.Equals(images) is not true) Images = images;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (address is not null && Address?.Equals(address) is not true) Address = address;
        if (contactPhone is not null && ContactPhone?.Equals(contactPhone) is not true) ContactPhone = contactPhone;

        if (loaiNhaId.HasValue && loaiNhaId.Value != Guid.Empty && !LoaiNhaId.Equals(loaiNhaId.Value)) LoaiNhaId = loaiNhaId.Value;
        if (thoiGianThueNhaId.HasValue && thoiGianThueNhaId.Value != Guid.Empty && !thoiGianThueNhaId.Equals(thoiGianThueNhaId.Value)) ThoiGianThueNhaId = thoiGianThueNhaId.Value;
        if (dienTichNhaId.HasValue && dienTichNhaId.Value != Guid.Empty && !DienTichNhaId.Equals(dienTichNhaId.Value)) DienTichNhaId = dienTichNhaId.Value;
        if (mucGiaThueNhaId.HasValue && mucGiaThueNhaId.Value != Guid.Empty && !MucGiaThueNhaId.Equals(mucGiaThueNhaId.Value)) MucGiaThueNhaId = mucGiaThueNhaId.Value;
        if (provinceId.HasValue && provinceId.Value != Guid.Empty && !ProvinceId.Equals(provinceId.Value)) ProvinceId = provinceId.Value;
        if (districtId.HasValue && districtId.Value != Guid.Empty && !DistrictId.Equals(districtId.Value)) DistrictId = districtId.Value;
        if (communeId.HasValue && communeId.Value != Guid.Empty && !CommuneId.Equals(communeId.Value)) CommuneId = communeId.Value;

        if (latitude.HasValue && !Latitude.Equals(latitude.Value)) Latitude = latitude.Value;
        if (longitude.HasValue && !Longitude.Equals(longitude.Value)) Longitude = longitude.Value;

        return this;
    }
}