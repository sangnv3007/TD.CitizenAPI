namespace TD.CitizenAPI.Application.Catalog.Places;

public class DeletePlaceRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeletePlaceRequest(Guid id) => Id = id;
}

public class DeletePlaceRequestHandler : IRequestHandler<DeletePlaceRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Place> _placeRepo;
    private readonly IStringLocalizer<DeletePlaceRequestHandler> _localizer;

    public DeletePlaceRequestHandler(IRepositoryWithEvents<Place> placeRepo, IStringLocalizer<DeletePlaceRequestHandler> localizer) =>
        (_placeRepo, _localizer) = (placeRepo, localizer);

    public async Task<Result<Guid>> Handle(DeletePlaceRequest request, CancellationToken cancellationToken)
    {
        var item = await _placeRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["place.notfound"]);

        await _placeRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}