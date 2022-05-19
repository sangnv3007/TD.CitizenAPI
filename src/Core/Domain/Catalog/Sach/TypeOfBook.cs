namespace TD.CitizenAPI.Domain.Catalog;

public class TypeOfBook : AuditableEntity, IAggregateRoot
{
    public string NameType { get; set; }
    public string? Description { get; set; }
    public ICollection<Book>? Books { get; set; }
    public TypeOfBook(string nameType, string? description)
    {
        NameType = nameType;
        Description = description;
    }

    public TypeOfBook Update(string nameType, string? description)
    {
        if (nameType is not null && NameType?.Equals(nameType) is not true) NameType = nameType;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}
