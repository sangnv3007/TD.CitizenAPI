namespace TD.CitizenAPI.Application.Catalog.DienTichNhas;

public class DienTichNhaDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedOn { get; set; }
}