namespace TD.CitizenAPI.Application.Catalog.DienTichNhas;

public class UpdateDienTichNhaRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
   
    public string? Description { get; set; }
}

public class UpdateDienTichNhaRequestValidator : CustomValidator<UpdateDienTichNhaRequest>
{
    public UpdateDienTichNhaRequestValidator(IRepository<DienTichNha> repository, IStringLocalizer<UpdateDienTichNhaRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateDienTichNhaRequestHandler : IRequestHandler<UpdateDienTichNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<DienTichNha> _repository;
    private readonly IStringLocalizer<UpdateDienTichNhaRequestHandler> _localizer;

    public UpdateDienTichNhaRequestHandler(IRepositoryWithEvents<DienTichNha> repository, IStringLocalizer<UpdateDienTichNhaRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateDienTichNhaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["DienTichNha.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}