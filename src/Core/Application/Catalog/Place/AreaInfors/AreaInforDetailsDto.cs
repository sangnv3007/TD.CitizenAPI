using TD.CitizenAPI.Application.Catalog.AreaInforValues;

namespace TD.CitizenAPI.Application.Catalog.AreaInfors;

public class AreaInforDetailsDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int? Level { get; set; }
    public string?Type { get; set; }
    public string? NameWithType { get; set; }
    public string? AreaCode { get; set; }
    public string? Introduce { get; set; }
    public string? Acreage { get; set; }
    public string? Population { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }

    public List<AreaInforValueDto>? Administrative { get; set; }
    public List<AreaInforValueDto>? Populations { get; set; }
    public List<AreaInforValueDto>? Topographic { get; set; }
    public List<AreaInforValueDto>? Weather { get; set; }
    public List<AreaInforValueDto>? Mineral { get; set; }
    public List<AreaInforValueDto>? History { get; set; }
    public List<AreaInforValueDto>? Economy { get; set; }

    public List<AreaInforChildResponse>? Children { get; set; }
}