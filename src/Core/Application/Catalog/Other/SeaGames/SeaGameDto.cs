namespace TD.CitizenAPI.Application.Catalog.SeaGames;

public class SeaGameDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Actor { get; set; }
    public DateTime? Date { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    public int? ViewQuantity { get; set; }

}