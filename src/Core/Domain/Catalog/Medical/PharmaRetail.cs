namespace TD.CitizenAPI.Domain.Catalog;

public class PharmaRetail : AuditableEntity, IAggregateRoot
{
    //Co so kinh doanh thuoc
    public string? Code { get; set; }
    public string? Stt { get; set; }
    public string? Title { get; set; }
    public string? Address { get; set; }
    public string? MumberDkkd { get; set; }
    public string? BusinessForm { get; set; }
    public string? BusinessScope { get; set; }
    public string? IssueDate { get; set; }
    public string? HoDem { get; set; }
    public string? Ten { get; set; }
    public string? NgaySinh { get; set; }
    public string? Cchn { get; set; }
    public string? NgayCapCchn { get; set; }
    public string? NoiCapCchn { get; set; }
    public string? Note { get; set; }

    public PharmaRetail(string? code, string? stt, string? title, string? address, string? mumberDkkd, string? businessForm, string? businessScope, string? issueDate, string? hoDem, string? ten, string? ngaySinh, string? cchn, string? ngayCapCchn, string? noiCapCchn, string? note)
    {
        Code = code;
        Stt = stt;
        Title = title;
        Address = address;
        MumberDkkd = mumberDkkd;
        BusinessForm = businessForm;
        BusinessScope = businessScope;
        IssueDate = issueDate;
        HoDem = hoDem;
        Ten = ten;
        NgaySinh = ngaySinh;
        Cchn = cchn;
        NgayCapCchn = ngayCapCchn;
        NoiCapCchn = noiCapCchn;
        Note = note;
    }

    public PharmaRetail Update(string? code, string? stt, string? title, string? address, string? mumberDkkd, string? businessForm, string? businessScope, string? issueDate, string? hoDem, string? ten, string? ngaySinh, string? cchn, string? ngayCapCchn, string? noiCapCchn, string? note)
    {
        Code = code;
        Stt = stt;
        Title = title;
        Address = address;
        MumberDkkd = mumberDkkd;
        BusinessForm = businessForm;
        BusinessScope = businessScope;
        IssueDate = issueDate;
        HoDem = hoDem;
        Ten = ten;
        NgaySinh = ngaySinh;
        Cchn = cchn;
        NgayCapCchn = ngayCapCchn;
        NoiCapCchn = noiCapCchn;
        Note = note;
        return this;
    }
}