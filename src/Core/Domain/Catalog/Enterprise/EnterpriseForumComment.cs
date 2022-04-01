namespace TD.CitizenAPI.Domain.Catalog;

//Dien dan doanh nghiep nha dau tu - Binh luan
public class EnterpriseForumComment : AuditableEntity, IAggregateRoot
{
    public string? UserName { get; set; }
    public string? Content { get; set; }

    public Guid? EnterpriseForumTopicId { get; set; }
    public EnterpriseForumTopic? EnterpriseForumTopic { get; set; }

    public EnterpriseForumComment(string? userName,  string? content, Guid? enterpriseForumTopicId)
    {
        UserName = userName;
        Content = content;
        EnterpriseForumTopicId = enterpriseForumTopicId;
    }

    public EnterpriseForumComment Update(string? userName, string? content, Guid? enterpriseForumTopicId)
    {
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (content is not null && Content?.Equals(content) is not true) Content = content;

        if (enterpriseForumTopicId.HasValue && enterpriseForumTopicId.Value != Guid.Empty && !EnterpriseForumTopicId.Equals(enterpriseForumTopicId.Value)) EnterpriseForumTopicId = enterpriseForumTopicId.Value;
        return this;
    }
}