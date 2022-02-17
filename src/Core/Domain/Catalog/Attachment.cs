namespace TD.CitizenAPI.Domain.Catalog;

public class Attachment : AuditableEntity, IAggregateRoot
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Url { get; set; }
}