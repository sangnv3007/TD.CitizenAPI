namespace TD.CitizenAPI.Application.Catalog.LawDatas;

public class LawDataDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Type { get; set; }

    public string? Signer { get; set; }
    public string? Quote { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? DateIssued { get; set; }
    public string? Image { get; set; }
    public string? Link { get; set; }
    public string? Code { get; set; }
    public string? AgencyIssued { get; set; }
}