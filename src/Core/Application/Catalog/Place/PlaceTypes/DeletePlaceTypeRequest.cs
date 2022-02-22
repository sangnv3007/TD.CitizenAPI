using TD.CitizenAPI.Application.Catalog.Places;

namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class DeletePlaceTypeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeletePlaceTypeRequest(Guid id) => Id = id;
}

public class DeletePlaceTypeRequestHandler : IRequestHandler<DeletePlaceTypeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<PlaceType> _placeTypeRepo;
    private readonly IReadRepository<Place> _placeRepo;
    private readonly IStringLocalizer<DeletePlaceTypeRequestHandler> _localizer;

    public DeletePlaceTypeRequestHandler(IRepositoryWithEvents<PlaceType> placeTypeRepo, IReadRepository<Place> placeRepo, IStringLocalizer<DeletePlaceTypeRequestHandler> localizer) =>
        (_placeTypeRepo, _placeRepo, _localizer) = (placeTypeRepo, placeRepo, localizer);

    public async Task<Result<Guid>> Handle(DeletePlaceTypeRequest request, CancellationToken cancellationToken)
    {
        if (await _placeRepo.AnyAsync(new PlacesByPlaceTypeSpec(request.Id), cancellationToken))
        {
            throw new ConflictException(_localizer["placetype.cannotbedeleted"]);
        }

        var item = await _placeTypeRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["placetype.notfound"]);

        await _placeTypeRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}