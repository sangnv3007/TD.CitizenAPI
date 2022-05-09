namespace TD.CitizenAPI.Application.Catalog.ThueNhas;

public partial class CreateThueNhaRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;

    public string? Description { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }

    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
    public string? Address { get; set; }

    public Guid? LoaiNhaId { get; set; }
    public Guid? ThoiGianThueNhaId { get; set; }
    public Guid? DienTichNhaId { get; set; }
    public Guid? MucGiaThueNhaId { get; set; }

    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}

public class CreateThueNhaRequestValidator : CustomValidator<CreateThueNhaRequest>
{
    public CreateThueNhaRequestValidator(IReadRepository<ThueNha> repository, IStringLocalizer<CreateThueNhaRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateThueNhaRequestHandler : IRequestHandler<CreateThueNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ThueNha> _repository;

    public CreateThueNhaRequestHandler(IRepositoryWithEvents<ThueNha> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateThueNhaRequest request, CancellationToken cancellationToken)
    {
        var item = new ThueNha(request.Name,request.Description, request.ContactName,request.ContactPhone,request.Image,request.Images,request.ProvinceId,request.DistrictId,request.CommuneId,request.Address,request.Latitude,request.Longitude,request.LoaiNhaId,request.ThoiGianThueNhaId,request.DienTichNhaId,request.MucGiaThueNhaId);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}