namespace TD.CitizenAPI.Domain.Catalog;

public class Drug : AuditableEntity, IAggregateRoot
{
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

    public Drug(string? code, string? images, string? tenThuoc, string? dotPheDuyet, string? soQuyetDinh, string? pheDuyet, string? hieuLuc, string? soDangKy, string? hoatChat, string? phanLoai, string? nongDo, string? taDuoc, string? baoChe, string? dongGoi, string? tieuChuan, string? tuoiTho, string? congTySx, string? congTySxCode, string? nuocSx, string? diaChiSx, string? congTyDk, string? nuocDk, string? diaChiDk, string? giaKeKhai, string? huongDanSuDung, string? huongDanSuDungBn, string? nhomThuoc, string? fileName)
    {
        Code = code;
        Images = images;
        TenThuoc = tenThuoc;
        DotPheDuyet = dotPheDuyet;
        SoQuyetDinh = soQuyetDinh;
        PheDuyet = pheDuyet;
        HieuLuc = hieuLuc;
        SoDangKy = soDangKy;
        HoatChat = hoatChat;
        PhanLoai = phanLoai;
        NongDo = nongDo;
        TaDuoc = taDuoc;
        BaoChe = baoChe;
        DongGoi = dongGoi;
        TieuChuan = tieuChuan;
        TuoiTho = tuoiTho;
        CongTySx = congTySx;
        CongTySxCode = congTySxCode;
        NuocSx = nuocSx;
        DiaChiSx = diaChiSx;
        CongTyDk = congTyDk;
        NuocDk = nuocDk;
        DiaChiDk = diaChiDk;
        GiaKeKhai = giaKeKhai;
        HuongDanSuDung = huongDanSuDung;
        HuongDanSuDungBn = huongDanSuDungBn;
        NhomThuoc = nhomThuoc;
        FileName = fileName;
    }

    public Drug Update(string? code, string? images, string? tenThuoc, string? dotPheDuyet, string? soQuyetDinh, string? pheDuyet, string? hieuLuc, string? soDangKy, string? hoatChat, string? phanLoai, string? nongDo, string? taDuoc, string? baoChe, string? dongGoi, string? tieuChuan, string? tuoiTho, string? congTySx, string? congTySxCode, string? nuocSx, string? diaChiSx, string? congTyDk, string? nuocDk, string? diaChiDk, string? giaKeKhai, string? huongDanSuDung, string? huongDanSuDungBn, string? nhomThuoc, string? fileName)
    {
        Code = code;
        Images = images;
        TenThuoc = tenThuoc;
        DotPheDuyet = dotPheDuyet;
        SoQuyetDinh = soQuyetDinh;
        PheDuyet = pheDuyet;
        HieuLuc = hieuLuc;
        SoDangKy = soDangKy;
        HoatChat = hoatChat;
        PhanLoai = phanLoai;
        NongDo = nongDo;
        TaDuoc = taDuoc;
        BaoChe = baoChe;
        DongGoi = dongGoi;
        TieuChuan = tieuChuan;
        TuoiTho = tuoiTho;
        CongTySx = congTySx;
        CongTySxCode = congTySxCode;
        NuocSx = nuocSx;
        DiaChiSx = diaChiSx;
        CongTyDk = congTyDk;
        NuocDk = nuocDk;
        DiaChiDk = diaChiDk;
        GiaKeKhai = giaKeKhai;
        HuongDanSuDung = huongDanSuDung;
        HuongDanSuDungBn = huongDanSuDungBn;
        NhomThuoc = nhomThuoc;
        FileName = fileName;
        return this;
    }
}