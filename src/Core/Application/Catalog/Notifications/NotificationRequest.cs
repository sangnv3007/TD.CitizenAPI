namespace TD.CitizenAPI.Application.Catalog.Notifications;

public class NotificationRequest : IDto
{
    public List<string> Topics { get; set; } = default!;
    public string Body { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string? Data { get; set; }
    public string? AppType { get; set; }
    public string? AreaCode { get; set; }
    public string? ImageUrl { get; set; }
    public string? CollapseKey { get; set; }

}