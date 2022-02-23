namespace TD.CitizenAPI.Application.Catalog.Trips;

public class DeleteTripRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteTripRequest(Guid id) => Id = id;
}

public class DeleteTripRequestHandler : IRequestHandler<DeleteTripRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Trip> _repository;
    private readonly IStringLocalizer<DeleteTripRequestHandler> _localizer;

    public DeleteTripRequestHandler(IRepositoryWithEvents<Trip> repository,  IStringLocalizer<DeleteTripRequestHandler> localizer) =>
        (_repository,  _localizer) = (repository,  localizer);

    public async Task<Result<Guid>> Handle(DeleteTripRequest request, CancellationToken cancellationToken)
    {

        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Trip.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}