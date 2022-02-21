namespace TD.CitizenAPI.Domain.Catalog;

public class Salary : AuditableEntity, IAggregateRoot
{
    //Loai hinh cong viec / ban thoi gian, toan thoi gian
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }

    public Salary(string name, string? code, string? description)
    {
        Name = name;
        Code = code;
        Description = description;
    }

    public Salary Update(string? name, string? code,  string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        return this;
    }
}