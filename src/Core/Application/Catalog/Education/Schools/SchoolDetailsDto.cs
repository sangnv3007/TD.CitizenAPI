namespace TD.CitizenAPI.Application.Catalog.Schools;

public class SchoolDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
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
}