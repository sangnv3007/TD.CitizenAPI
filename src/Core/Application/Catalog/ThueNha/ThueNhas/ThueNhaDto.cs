namespace TD.CitizenAPI.Application.Catalog.ThueNhas;

public class ThueNhaDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

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
    public DateTime? CreatedOn { get; set; }
}