namespace TD.CitizenAPI.Application.Catalog.AreaInforValues;

public class AreaInforValueDto : IDto
{
    public Guid Id { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
    public string? Type { get; set; }
    public int? Order { get; set; }
}