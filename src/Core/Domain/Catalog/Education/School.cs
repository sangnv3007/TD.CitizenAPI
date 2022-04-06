namespace TD.CitizenAPI.Domain.Catalog;

public class School : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? PhoneNumber { get; set; }
    //Hieu truong
    public string? Principal { get; set; }
    //So dien thoai hieu truong
    public string? PrincipalPhone { get; set; }
    public string? Category { get; set; }
    //Loai hinh
    public string? Type { get; set; }
    //Phong giao duc va dao tao
    public string? Department { get; set; }
    //Quy Mo
    public string? Size { get; set; }
    //Chuan quoc gua muc do
    public string? Standard { get; set; }
    public string? Address { get; set; }
    public string? District { get; set; }
    public string? Province { get; set; }
    public string? Ward { get; set; }
    public string? Description { get; set; }

    public string? Image { get; set; }

    public School(string name, string? code, string? phoneNumber, string? principal, string? principalPhone, string? category, string? type, string? department, string? size, string? standard, string? address, string? district, string? province, string? ward, string? description, string? image)
    {
        Name = name;
        Code = code;
        PhoneNumber = phoneNumber;
        Principal = principal;
        PrincipalPhone = principalPhone;
        Category = category;
        Type = type;
        Department = department;
        Size = size;
        Standard = standard;
        Address = address;
        District = district;
        Province = province;
        Ward = ward;
        Description = description;
        Image = image;
    }

    public School Update(string? name, string? code, string? phoneNumber, string? principal, string? principalPhone, string? category, string? type, string? department, string? size, string? standard, string? address, string? district, string? province, string? ward, string? description, string? image)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        if (phoneNumber is not null && PhoneNumber?.Equals(phoneNumber) is not true) PhoneNumber = phoneNumber;
        if (principal is not null && Principal?.Equals(principal) is not true) Principal = principal;
        if (principalPhone is not null && PrincipalPhone?.Equals(principalPhone) is not true) PrincipalPhone = principalPhone;
        if (category is not null && Category?.Equals(category) is not true) Category = category;
        if (type is not null && Type?.Equals(type) is not true) Type = type;
        if (department is not null && Department?.Equals(department) is not true) Department = department;
        if (size is not null && Size?.Equals(size) is not true) Size = size;
        if (standard is not null && Standard?.Equals(standard) is not true) Standard = standard;
        if (address is not null && Address?.Equals(address) is not true) Address = address;
        if (district is not null && District?.Equals(district) is not true) District = district;
        if (province is not null && Province?.Equals(province) is not true) Province = province;
        if (ward is not null && Ward?.Equals(ward) is not true) Ward = ward;

        return this;
    }
}