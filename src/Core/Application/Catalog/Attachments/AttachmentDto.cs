namespace TD.CitizenAPI.Application.Catalog.Attachments;

public class AttachmentDto : IDto
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Url { get; set; }
}