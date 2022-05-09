namespace TD.CitizenAPI.Application.Catalog.MucGiaThueNhas;

public class MucGiaThueNhaDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedOn { get; set; }
}