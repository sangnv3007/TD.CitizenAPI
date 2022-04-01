namespace TD.CitizenAPI.Domain.Catalog;

//Dien dan doanh nghiep nha dau tu - Bai viet
public class EnterpriseForumTopic : AuditableEntity, IAggregateRoot
{
    public string? UserName { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Image { get; set; }

    public Guid? EnterpriseForumCategoryId { get; set; }
    public EnterpriseForumCategory? EnterpriseForumCategory { get; set; }

    public EnterpriseForumTopic(string? userName, string? title, string? content, string? image, Guid? enterpriseForumCategoryId)
    {
        UserName = userName;
        Title = title;
        Content = content;
        Image = image;
        EnterpriseForumCategoryId = enterpriseForumCategoryId;
    }

    public EnterpriseForumTopic Update(string? userName, string? title, string? content, string? image, Guid? enterpriseForumCategoryId)
    {
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (title is not null && Title?.Equals(title) is not true) Title = title;
        if (content is not null && Content?.Equals(content) is not true) Content = content;
        if (image is not null && Image?.Equals(image) is not true) Image = image;

        if (enterpriseForumCategoryId.HasValue && enterpriseForumCategoryId.Value != Guid.Empty && !EnterpriseForumCategoryId.Equals(enterpriseForumCategoryId.Value)) EnterpriseForumCategoryId = enterpriseForumCategoryId.Value;
        return this;
    }
}