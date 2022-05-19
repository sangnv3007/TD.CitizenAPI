namespace TD.CitizenAPI.Domain.Catalog;
public class Book : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public Guid? TypeID { get; set; }
    public string? Author { get; set; }
    public string? PubDate { get; set; }
    public double? Price { get; set; }
    public double? Sale { get; set; }
    public string? PageNumber { get; set; }
    public virtual TypeOfBook? TypeOfBook { get; set; }
    public Book(string name, Guid? typeID, string? author, string? pubDate, double? price, double? sale, string? pageNumber)
    {
        Name = name;
        TypeID = typeID;
        Author = author;
        PubDate = pubDate;
        Price = price;
        Sale = sale;
        PageNumber = pageNumber;
    }

    public Book Update(string name, Guid? typeID, string? author, string? pubDate, double? price, double? sale, string? pageNumber)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (author is not null && Author?.Equals(author) is not true) Author = author;
        if (pubDate is not null && PubDate?.Equals(pubDate) is not true) PubDate = pubDate;
        if (price is not null && Price?.Equals(price) is not true) Price = price;
        if (sale is not null && Sale?.Equals(sale) is not true) Sale = sale;
        if (pageNumber is not null && PageNumber?.Equals(pageNumber) is not true) PageNumber = pageNumber;
        if (typeID.HasValue && typeID.Value != Guid.Empty && !TypeID.Equals(typeID.Value)) TypeID = typeID.Value;
        return this;
    }
}
