namespace TD.CitizenAPI.Application.Catalog.Feedbacks;

public class FeedbackDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = default!;
    public int Rate { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
}