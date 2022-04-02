using TD.CitizenAPI.Application.Identity.Users;

namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumComments;

public class EnterpriseForumCommentDto : IDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Content { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? FullName { get; set; }
    public string? ImageUrl { get; set; }
    public string? PhoneNumber { get; set; }

    public Guid? EnterpriseForumTopicId { get; set; }
}