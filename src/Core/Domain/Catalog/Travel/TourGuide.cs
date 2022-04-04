namespace TD.CitizenAPI.Domain.Catalog;

public class TourGuide : AuditableEntity, IAggregateRoot
{
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
    public string? ForeignLanguage {get;set;}

    public TourGuide(string? fullName, string? expirationDate, string? placeOfIssue, string? cardNumber, string? image, string? cardType, string? experience, string? foreignLanguage)
    {
        FullName = fullName;
        ExpirationDate = expirationDate;
        PlaceOfIssue = placeOfIssue;
        CardNumber = cardNumber;
        Image = image;
        CardType = cardType;
        Experience = experience;
        ForeignLanguage = foreignLanguage;
    }

    public TourGuide Update(string? fullName, string? expirationDate, string? placeOfIssue, string? cardNumber, string? image, string? cardType, string? experience, string? foreignLanguage)
    {
        if (fullName is not null && FullName?.Equals(fullName) is not true) FullName = fullName;
        if (expirationDate is not null && ExpirationDate?.Equals(expirationDate) is not true) ExpirationDate = expirationDate;
        if (placeOfIssue is not null && PlaceOfIssue?.Equals(placeOfIssue) is not true) PlaceOfIssue = placeOfIssue;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (cardType is not null && CardType?.Equals(cardType) is not true) CardType = cardType;
        if (cardNumber is not null && CardNumber?.Equals(cardNumber) is not true) CardNumber = cardNumber;
        if (experience is not null && Experience?.Equals(experience) is not true) Experience = experience;
        if (foreignLanguage is not null && ForeignLanguage?.Equals(foreignLanguage) is not true) ForeignLanguage = foreignLanguage;
        return this;
    }
}