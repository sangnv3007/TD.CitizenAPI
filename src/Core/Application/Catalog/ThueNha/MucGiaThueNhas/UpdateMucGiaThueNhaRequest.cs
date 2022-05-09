namespace TD.CitizenAPI.Application.Catalog.MucGiaThueNhas;

public class UpdateMucGiaThueNhaRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
   
    public string? Description { get; set; }
}

public class UpdateMucGiaThueNhaRequestValidator : CustomValidator<UpdateMucGiaThueNhaRequest>
{
    public UpdateMucGiaThueNhaRequestValidator(IRepository<MucGiaThueNha> repository, IStringLocalizer<UpdateMucGiaThueNhaRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateMucGiaThueNhaRequestHandler : IRequestHandler<UpdateMucGiaThueNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MucGiaThueNha> _repository;
    private readonly IStringLocalizer<UpdateMucGiaThueNhaRequestHandler> _localizer;

    public UpdateMucGiaThueNhaRequestHandler(IRepositoryWithEvents<MucGiaThueNha> repository, IStringLocalizer<UpdateMucGiaThueNhaRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateMucGiaThueNhaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["MucGiaThueNha.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}