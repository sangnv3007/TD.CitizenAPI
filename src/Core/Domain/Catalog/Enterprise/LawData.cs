namespace TD.CitizenAPI.Domain.Catalog;

//Co so du lieu luat
public class LawData : AuditableEntity, IAggregateRoot
{
    public string Title { get; set; }
    public string? Type { get; set; }

    public string? Signer { get; set; }
    public string? Quote { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? DateIssued { get; set; }
    public string? Image { get; set; }
    public string? Link { get; set; }
    public string? Code { get; set; }
    public string? AgencyIssued { get; set; }

    public LawData(string title, string? type, string? signer, string? quote, DateTime? effectiveDate, DateTime? dateIssued, string? image, string? link, string? code, string? agencyIssued)
    {
        Title = title;
        Type = type;
        Signer = signer;
        Quote = quote;
        EffectiveDate = effectiveDate;
        DateIssued = dateIssued;
        Image = image;
        Link = link;
        Code = code;
        AgencyIssued = agencyIssued;
    }

    public LawData Update(string? title, string? type, string? signer, string? quote, DateTime? effectiveDate, DateTime? dateIssued, string? image, string? link, string? code, string? agencyIssued)
    {
        if (title is not null && Title?.Equals(title) is not true) Title = title;
        if (type is not null && Type?.Equals(type) is not true) Type = type;
        if (signer is not null && Signer?.Equals(signer) is not true) Signer = signer;
        if (image is not null && Image?.Equals(image) is not true) Image = image;
        if (quote is not null && Quote?.Equals(quote) is not true) Quote = quote;
        if (link is not null && Link?.Equals(link) is not true) Link = link;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (agencyIssued is not null && AgencyIssued?.Equals(agencyIssued) is not true) AgencyIssued = agencyIssued;
        if (effectiveDate.HasValue && !EffectiveDate.Equals(effectiveDate.Value)) EffectiveDate = effectiveDate.Value;
        if (dateIssued.HasValue && !DateIssued.Equals(dateIssued.Value)) DateIssued = dateIssued.Value;
        return this;
    }
}