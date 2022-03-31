namespace TD.CitizenAPI.Application.Catalog.AlertOrganizations;

public class AlertOrganizationDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}