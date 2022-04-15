namespace TD.CitizenAPI.Application.Catalog.TravelHandbooks;

public class TravelHandbookDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
    public int ViewQuantity { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    public string? Tags { get; set; }

    public DateTime? CreatedOn { get; set; }
}