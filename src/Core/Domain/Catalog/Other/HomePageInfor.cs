namespace TD.CitizenAPI.Domain.Catalog;

public class HomePageInfor : AuditableEntity, IAggregateRoot
{
    public string? ImagePad { get; set; }
    public string? Image { get; set; }
    public string? Url { get; set; }
    public string? Title { get; set; }
    public int? Order { get; set; }
    public bool? Status { get; set; }

    public HomePageInfor(string? imagePad, string? image, string? url, string? title, int? order, bool? status)
    {
        ImagePad = imagePad;
        Image = image;
        Url = url;
        Title = title;
        Order = order;
        Status = status;
    }

    public HomePageInfor Update(string? imagePad, string? image, string? url, string? title, int? order, bool? status)
    {
        if (imagePad is not null && ImagePad?.Equals(imagePad) is not true) ImagePad = imagePad;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (url is not null && Url?.Equals(url) is not true) Url = url;
        if (title is not null && Title?.Equals(title) is not true) Title = title;
        if (order is not null && Order?.Equals(order) is not true) Order = order;
        if (status is not null && Status?.Equals(status) is not true) Status = status;
        return this;
    }
}