namespace TD.CitizenAPI.Application.Catalog.Benefits;

public class BenefitDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
}