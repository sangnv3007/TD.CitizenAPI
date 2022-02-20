namespace TD.CitizenAPI.Domain.Catalog;

public class Feedback : AuditableEntity, IAggregateRoot
{
    public string UserName { get; set; }
    public int Rate { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
    public int Status { get; set; }

    public Feedback(string userName, int rate, string? description, string? content, int status)
    {
        UserName = userName;
        Rate = rate;
        Description = description;
        Content = content;
        Status = status;
    }
}