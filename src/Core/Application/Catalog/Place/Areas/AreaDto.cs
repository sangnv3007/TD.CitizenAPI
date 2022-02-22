namespace TD.CitizenAPI.Application.Catalog.Areas;

public class AreaDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? ParentCode { get; set; }
    public string? NameWithType { get; set; }
    public string? PathWithType { get; set; }
}