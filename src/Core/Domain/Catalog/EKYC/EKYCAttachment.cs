namespace TD.CitizenAPI.Domain.Catalog;

public class EKYCAttachment : AuditableEntity, IAggregateRoot
{
    public string? UserName { get; set; }
    public string? FileName { get; set; }
    public string? FileType { get; set; }
    public string? Url { get; set; }
    //Loai anh: ChanDung, MatTruoc, MatSau
    public string? ImageType { get; set; }

}