namespace TD.CitizenAPI.Application.Catalog.AlertInformations;

public class AlertInformationDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
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
}