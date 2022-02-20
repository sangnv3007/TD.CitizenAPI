namespace TD.CitizenAPI.Domain.Catalog;

public class Notification : AuditableEntity, IAggregateRoot
{
    public string? UserName { get; set; }
    public string? Body { get; set; }
    public bool? IsRead { get; set; }
    public string? Title { get; set; }
    public string? Data { get; set; }
    public string? AppType { get; set; }
    public string? Code { get; set; }
    public string? AreaCode { get; set; }

    public Notification(string? userName, string? body, bool? isRead, string? title, string? data, string? appType, string? code, string? areaCode)
    {
        UserName = userName;
        Body = body;
        IsRead = isRead;
        Title = title;
        Data = data;
        AppType = appType;
        Code = code;
        AreaCode = areaCode;
    }

    public Notification Update(string? userName, string? body, bool? isRead, string? title, string? data, string? appType, string? code, string? areaCode)
    {
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (body is not null && Body?.Equals(body) is not true) Body = body;
        if (isRead is not null && IsRead?.Equals(isRead) is not true) IsRead = isRead;
        if (title is not null && Title?.Equals(title) is not true) Title = title;
        if (data is not null && Data?.Equals(data) is not true) Data = data;
        if (appType is not null && AppType?.Equals(appType) is not true) AppType = appType;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (areaCode is not null && AreaCode?.Equals(areaCode) is not true) AreaCode = areaCode;
        return this;
    }

    public Notification Update(bool? isRead)
    {
        if (isRead is not null && IsRead?.Equals(isRead) is not true) IsRead = isRead;
        return this;
    }
}