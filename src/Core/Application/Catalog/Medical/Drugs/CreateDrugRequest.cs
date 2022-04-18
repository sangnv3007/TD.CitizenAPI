namespace TD.CitizenAPI.Application.Catalog.Drugs;

public partial class CreateDrugRequest : IRequest<Result<Guid>>
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
}

public class CreateDrugRequestValidator : CustomValidator<CreateDrugRequest>
{
    public CreateDrugRequestValidator(IReadRepository<Drug> repository, IStringLocalizer<CreateDrugRequestValidator> localizer) =>
        RuleFor(p => p.Code).NotEmpty();
}

public class CreateDrugRequestHandler : IRequestHandler<CreateDrugRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepository<Drug> _repository;

    public CreateDrugRequestHandler(IRepository<Drug> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateDrugRequest request, CancellationToken cancellationToken)
    {
        var item = new Drug(request.Code, request.Images, request.TenThuoc, request.DotPheDuyet, request.SoQuyetDinh, request.PheDuyet, request.HieuLuc, request.SoDangKy, request.HoatChat, request.PhanLoai, request.NongDo, request.TaDuoc, request.BaoChe, request.DongGoi, request.TieuChuan, request.TuoiTho, request.CongTySx, request.CongTySxCode, request.NuocSx, request.DiaChiSx, request.CongTyDk, request.NuocDk, request.DiaChiDk, request.GiaKeKhai, request.HuongDanSuDung, request.HuongDanSuDungBn, request.NhomThuoc, request.FileName);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}