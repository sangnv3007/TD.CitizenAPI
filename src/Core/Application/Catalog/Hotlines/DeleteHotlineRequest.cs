namespace TD.CitizenAPI.Application.Catalog.Hotlines;

public class DeleteHotlineRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteHotlineRequest(Guid id) => Id = id;
}

public class DeleteHotlineRequestHandler : IRequestHandler<DeleteHotlineRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Hotline> _repository;
    private readonly IStringLocalizer<DeleteHotlineRequestHandler> _localizer;

    public DeleteHotlineRequestHandler(IRepositoryWithEvents<Hotline> repository, IStringLocalizer<DeleteHotlineRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteHotlineRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["hotline.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}