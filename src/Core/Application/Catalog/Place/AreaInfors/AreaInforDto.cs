namespace TD.CitizenAPI.Application.Catalog.AreaInfors;

public class AreaInforDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int Level { get; set; }
    public string AreaCode { get; set; } = default!;
    public string? Introduce { get; set; }
    public string? Acreage { get; set; }
    public string? Population { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
}