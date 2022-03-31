namespace TD.CitizenAPI.Domain.Catalog;

public class AlertInformation : AuditableEntity, IAggregateRoot
{
    public string Title { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
    public bool? Active { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public int? Level { get; set; }
    public string? Image { get; set; }
    public string? File { get; set; }
    public Guid? AlertCategoryId { get; set; }
    public Guid? AlertOrganizationId { get; set; }
    public AlertCategory? AlertCategory { get; set; }
    public AlertOrganization? AlertOrganization { get; set; }

    public AlertInformation(string title, string? content, string? description, bool? active, DateTime? startDate, DateTime? finishDate, int? level, string? image, string? file, Guid? alertCategoryId, Guid? alertOrganizationId)
    {
        Title = title;
        Content = content;
        Description = description;
        Active = active;
        StartDate = startDate;
        FinishDate = finishDate;
        Level = level;
        Image = image;
        File = file;
        AlertCategoryId = alertCategoryId;
        AlertOrganizationId = alertOrganizationId;
    }

    public AlertInformation Update(string? title, string? content, string? description, bool? active, DateTime? startDate, DateTime? finishDate, int? level, string? image, string? file, Guid? alertCategoryId, Guid? alertOrganizationId)
    {
        if (title is not null && Title?.Equals(title) is not true) Title = title;
        if (content is not null && Content?.Equals(content) is not true) Content = content;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (file is not null && File?.Equals(file) is not true) File = file;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        if (active.HasValue  && !Active != active.Value) Active = active.Value;
        if (startDate.HasValue && !StartDate.Equals(startDate.Value)) StartDate = startDate.Value;
        if (finishDate.HasValue && !FinishDate.Equals(finishDate.Value)) FinishDate = finishDate.Value;
        if (level.HasValue && Level != level) Level = level.Value;


        if (alertCategoryId.HasValue && alertCategoryId.Value != Guid.Empty && !AlertCategoryId.Equals(alertCategoryId.Value)) AlertCategoryId = alertCategoryId.Value;
        if (alertOrganizationId.HasValue && alertOrganizationId.Value != Guid.Empty && !AlertOrganizationId.Equals(alertOrganizationId.Value)) AlertOrganizationId = alertOrganizationId.Value;

        return this;
    }
}