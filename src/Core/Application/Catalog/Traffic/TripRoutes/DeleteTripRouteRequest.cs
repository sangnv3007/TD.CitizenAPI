namespace TD.CitizenAPI.Application.Catalog.TripRoutes;

public class DeleteTripRouteRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteTripRouteRequest(Guid id) => Id = id;
}

public class DeleteTripRouteRequestHandler : IRequestHandler<DeleteTripRouteRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<TripRoute> _repository;
    private readonly IStringLocalizer<DeleteTripRouteRequestHandler> _localizer;

    public DeleteTripRouteRequestHandler(IRepositoryWithEvents<TripRoute> repository,  IStringLocalizer<DeleteTripRouteRequestHandler> localizer) =>
        (_repository,  _localizer) = (repository,  localizer);

    public async Task<Result<Guid>> Handle(DeleteTripRouteRequest request, CancellationToken cancellationToken)
    {
 

        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["TripRoute.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}