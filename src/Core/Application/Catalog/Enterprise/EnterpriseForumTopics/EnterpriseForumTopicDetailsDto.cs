namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumTopics;

public class EnterpriseForumTopicDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Image { get; set; }

    public Guid? EnterpriseForumCategoryId { get; set; }
    public EnterpriseForumCategory? EnterpriseForumCategory { get; set; }
}