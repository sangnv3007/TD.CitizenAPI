namespace TD.CitizenAPI.Application.Catalog.Carpools;

public class DeleteCarpoolRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteCarpoolRequest(Guid id) => Id = id;
}

public class DeleteCarpoolRequestHandler : IRequestHandler<DeleteCarpoolRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Carpool> _repository;
    private readonly IStringLocalizer<DeleteCarpoolRequestHandler> _localizer;

    public DeleteCarpoolRequestHandler(IRepositoryWithEvents<Carpool> repository, IStringLocalizer<DeleteCarpoolRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteCarpoolRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["carpool.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}