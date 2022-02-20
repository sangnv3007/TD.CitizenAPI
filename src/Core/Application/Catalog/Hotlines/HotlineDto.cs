namespace TD.CitizenAPI.Application.Catalog.Hotlines;

public class HotlineDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Image { get; set; }
}