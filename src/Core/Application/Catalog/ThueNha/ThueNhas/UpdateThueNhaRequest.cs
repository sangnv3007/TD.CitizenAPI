namespace TD.CitizenAPI.Application.Catalog.ThueNhas;

public class UpdateThueNhaRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
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

public class UpdateThueNhaRequestValidator : CustomValidator<UpdateThueNhaRequest>
{
    public UpdateThueNhaRequestValidator(IRepository<ThueNha> repository, IStringLocalizer<UpdateThueNhaRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateThueNhaRequestHandler : IRequestHandler<UpdateThueNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ThueNha> _repository;
    private readonly IStringLocalizer<UpdateThueNhaRequestHandler> _localizer;

    public UpdateThueNhaRequestHandler(IRepositoryWithEvents<ThueNha> repository, IStringLocalizer<UpdateThueNhaRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateThueNhaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["ThueNha.notfound"], request.Id));

        item.Update(request.Name, request.Description, request.ContactName, request.ContactPhone, request.Image, request.Images, request.ProvinceId, request.DistrictId, request.CommuneId, request.Address, request.Latitude, request.Longitude, request.LoaiNhaId, request.ThoiGianThueNhaId, request.DienTichNhaId, request.MucGiaThueNhaId);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}