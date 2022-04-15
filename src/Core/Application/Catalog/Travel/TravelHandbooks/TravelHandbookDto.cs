namespace TD.CitizenAPI.Application.Catalog.TravelHandbooks;

public class TravelHandbookDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int ViewQuantity { get; set; }
    public string? Image { get; set; }
    public DateTime? CreatedOn { get; set; }
}