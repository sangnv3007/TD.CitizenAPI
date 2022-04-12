namespace TD.CitizenAPI.Application.Catalog.MedicalHotlines;

public class DeleteMedicalHotlineRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteMedicalHotlineRequest(Guid id) => Id = id;
}

public class DeleteMedicalHotlineRequestHandler : IRequestHandler<DeleteMedicalHotlineRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MedicalHotline> _repository;
    private readonly IStringLocalizer<DeleteMedicalHotlineRequestHandler> _localizer;

    public DeleteMedicalHotlineRequestHandler(IRepositoryWithEvents<MedicalHotline> repository, IStringLocalizer<DeleteMedicalHotlineRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteMedicalHotlineRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["MedicalHotline.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}