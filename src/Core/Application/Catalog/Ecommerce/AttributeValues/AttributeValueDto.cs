namespace TD.CitizenAPI.Application.Catalog.AttributeValues;

public class AttributeValueDto : IDto
{
    public Guid Id { get; set; }
    public string Value { get; set; } = default!;
    public Guid? AttributeId { get; set; }
    public int Position { get; set; } = 0;
    public bool IsDefault { get; set; } = false;
    public int Status { get; set; } = 1;
}