namespace TD.CitizenAPI.Application.Catalog.Areas;

public class AreaDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? ParentCode { get; set; }
    public string? Slug { get; set; }
    public string? Type { get; set; }
    public int Level { get; set; }
    public string? NameWithType { get; set; }
    public string? Path { get; set; }
    public string? PathWithType { get; set; }
    public string? Description { get; set; }
}