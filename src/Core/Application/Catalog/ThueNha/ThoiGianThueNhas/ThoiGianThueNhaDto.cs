namespace TD.CitizenAPI.Application.Catalog.ThoiGianThueNhas;

public class ThoiGianThueNhaDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedOn { get; set; }
}