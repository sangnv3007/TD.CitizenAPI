namespace TD.CitizenAPI.Application.Catalog.Notifications;

public class NotificationDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Body { get; set; }
    public bool? IsRead { get; set; }
    public string? Title { get; set; }
    public string? Data { get; set; }
    public string? AppType { get; set; }
    public string? Code { get; set; }
    public string? AreaCode { get; set; }
    public DateTime? CreatedOn { get; set; }

}