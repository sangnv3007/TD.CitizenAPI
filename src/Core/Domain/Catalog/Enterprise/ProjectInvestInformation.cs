namespace TD.CitizenAPI.Domain.Catalog;

//Du an keu goi dau tu - Noi dung
public class ProjectInvestInformation : AuditableEntity, IAggregateRoot
{
    public string Title { get; set; }
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

    public Guid? ProjectInvestCategoryId { get; set; }
    public Guid? ProjectInvestFormId { get; set; }

    public ProjectInvestCategory? ProjectInvestCategory { get; set; }
    public ProjectInvestForm? ProjectInvestForm { get; set; }

    public ProjectInvestInformation(string title, string? content, string? scale, string? location, string? target, string? state, string? image, string? source, string? investmentForm, string? investor, string? functionContent, string? plan, int? viewQuantity, Guid? projectInvestCategoryId, Guid? projectInvestFormId)
    {
        Title = title;
        Content = content;
        Scale = scale;
        Location = location;
        Target = target;
        State = state;
        Image = image;
        Source = source;
        InvestmentForm = investmentForm;
        Investor = investor;
        FunctionContent = functionContent;
        Plan = plan;
        ViewQuantity = viewQuantity;
        ProjectInvestCategoryId = projectInvestCategoryId;
        ProjectInvestFormId = projectInvestFormId;
    }

    public ProjectInvestInformation Update(string? title, string? content, string? scale, string? location, string? target, string? state, string? image, string? source, string? investmentForm, string? investor, string? functionContent, string? plan, int? viewQuantity, Guid? projectInvestCategoryId, Guid? projectInvestFormId)
    {
        if (title is not null && Title?.Equals(title) is not true) Title = title;
        if (content is not null && Content?.Equals(content) is not true) Content = content;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (scale is not null && Scale?.Equals(scale) is not true) Scale = scale;
        if (location is not null && Location?.Equals(location) is not true) Location = location;

        if (target is not null && Target?.Equals(target) is not true) Target = target;
        if (state is not null && State?.Equals(state) is not true) State = state;
        if (source is not null && Source?.Equals(source) is not true) Source = source;
        if (investmentForm is not null && InvestmentForm?.Equals(investmentForm) is not true) InvestmentForm = investmentForm;
        if (investor is not null && Investor?.Equals(investor) is not true) Investor = investor;
        if (functionContent is not null && FunctionContent?.Equals(functionContent) is not true) FunctionContent = functionContent;
        if (plan is not null && Location?.Equals(plan) is not true) Location = plan;

        if (projectInvestFormId.HasValue && projectInvestFormId.Value != Guid.Empty && !ProjectInvestFormId.Equals(projectInvestFormId.Value)) ProjectInvestFormId = projectInvestFormId.Value;
        if (projectInvestCategoryId.HasValue && projectInvestCategoryId.Value != Guid.Empty && !ProjectInvestCategoryId.Equals(projectInvestCategoryId.Value)) ProjectInvestCategoryId = projectInvestCategoryId.Value;
        return this;
    }
}