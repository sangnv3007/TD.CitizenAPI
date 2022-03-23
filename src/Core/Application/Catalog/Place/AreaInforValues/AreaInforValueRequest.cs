namespace TD.CitizenAPI.Application.Catalog.AreaInforValues;

public class AreaInforValueRequest : IDto
{
    public string? Key { get; set; }
    public string? Value { get; set; }
    public int? Order { get; set; }
}