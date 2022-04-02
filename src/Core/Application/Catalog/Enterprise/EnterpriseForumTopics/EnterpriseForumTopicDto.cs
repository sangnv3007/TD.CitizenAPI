namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumTopics;

public class EnterpriseForumTopicDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? ImageUrl { get; set; }
    public string? PhoneNumber { get; set; }

    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Image { get; set; }
    public Guid? EnterpriseForumCategoryId { get; set; }
    public DateTime? CreatedOn { get; set; }
    public EnterpriseForumCategory? EnterpriseForumCategory { get; set; }
}