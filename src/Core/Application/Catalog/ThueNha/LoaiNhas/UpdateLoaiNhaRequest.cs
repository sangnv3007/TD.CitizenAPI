namespace TD.CitizenAPI.Application.Catalog.LoaiNhas;

public class UpdateLoaiNhaRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
   
    public string? Description { get; set; }
}

public class UpdateLoaiNhaRequestValidator : CustomValidator<UpdateLoaiNhaRequest>
{
    public UpdateLoaiNhaRequestValidator(IRepository<LoaiNha> repository, IStringLocalizer<UpdateLoaiNhaRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateLoaiNhaRequestHandler : IRequestHandler<UpdateLoaiNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<LoaiNha> _repository;
    private readonly IStringLocalizer<UpdateLoaiNhaRequestHandler> _localizer;

    public UpdateLoaiNhaRequestHandler(IRepositoryWithEvents<LoaiNha> repository, IStringLocalizer<UpdateLoaiNhaRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateLoaiNhaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["LoaiNha.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}