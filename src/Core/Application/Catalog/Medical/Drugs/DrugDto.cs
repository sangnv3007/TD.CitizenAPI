namespace TD.CitizenAPI.Application.Catalog.Drugs;

public class DrugDto : IDto
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? Images { get; set; }
    public string? TenThuoc { get; set; }
    public string? DotPheDuyet { get; set; }
    public string? SoQuyetDinh { get; set; }
    public string? PheDuyet { get; set; }
    public string? HieuLuc { get; set; }
    public string? SoDangKy { get; set; }
    public string? HoatChat { get; set; }
    public string? PhanLoai { get; set; }
    public string? NongDo { get; set; }
    public string? TaDuoc { get; set; }
    public string? BaoChe { get; set; }
    public string? DongGoi { get; set; }
    public string? TieuChuan { get; set; }
    public string? TuoiTho { get; set; }
    public string? CongTySx { get; set; }
    public string? CongTySxCode { get; set; }
    public string? NuocSx { get; set; }
    public string? DiaChiSx { get; set; }
    public string? CongTyDk { get; set; }
    public string? NuocDk { get; set; }
    public string? DiaChiDk { get; set; }
    public string? GiaKeKhai { get; set; }
    public string? HuongDanSuDung { get; set; }
    public string? HuongDanSuDungBn { get; set; }
    public string? NhomThuoc { get; set; }

    public string? FileName { get; set; }
}