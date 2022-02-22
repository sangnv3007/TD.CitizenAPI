namespace TD.CitizenAPI.Application.Catalog.AreaInfors;

public class AreaInforChildResponse : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int? Level { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
}