namespace TD.CitizenAPI.Application.Catalog.HomePageInfors;

public class HomePageInforDto : IDto
{
    public Guid Id { get; set; }
    public string? ImagePad { get; set; }
    public string? Image { get; set; }
    public string? Url { get; set; }
    public string? Title { get; set; }
    public int? Order { get; set; }
}