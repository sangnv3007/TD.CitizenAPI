namespace TD.CitizenAPI.Application.Catalog.ProjectInvestInformations;

public class ProjectInvestInformationDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Content { get; set; }
    //Quy mo
    public string? Scale { get; set; }
    //Dia diem
    public string? Location { get; set; }
    //Muc tieu
    public string? Target { get; set; }
    //hien trang
    public string? State { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    //Hinh thuc lua chon nha dau tu
    public string? InvestmentForm { get; set; }
    //Co quan chu tri
    public string? Investor { get; set; }
    //chuc nang muc dich su dung
    public string? FunctionContent { get; set; }
    //Chi tieu quy hoach
    public string? Plan { get; set; }
    public int? ViewQuantity { get; set; }
    public DateTime? CreatedOn { get; set; }

    public Guid? ProjectInvestCategoryId { get; set; }
    public Guid? ProjectInvestFormId { get; set; }

    public ProjectInvestCategory? ProjectInvestCategory { get; set; }
    public ProjectInvestForm? ProjectInvestForm { get; set; }
}