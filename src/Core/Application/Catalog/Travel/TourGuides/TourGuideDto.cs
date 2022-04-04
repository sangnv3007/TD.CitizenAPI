namespace TD.CitizenAPI.Application.Catalog.TourGuides;

public class TourGuideDto : IDto
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    //Ngay het han
    public string? ExpirationDate { get; set; }
    //Noi cap
    public string? PlaceOfIssue { get; set; }
    //So the
    public string? CardNumber { get; set; }
    public string? Image { get; set; }
    //Loai the
    public string? CardType { get; set; }
    //Kinh nghiem
    public string? Experience { get; set; }
    //Ngoai ngu
    public string? ForeignLanguage { get; set; }
}