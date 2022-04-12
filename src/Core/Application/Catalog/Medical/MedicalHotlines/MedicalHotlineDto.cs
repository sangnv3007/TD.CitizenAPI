namespace TD.CitizenAPI.Application.Catalog.MedicalHotlines;

public class MedicalHotlineDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Image { get; set; }
}