namespace TD.CitizenAPI.Application.Catalog.TravelHandbooks;

public class DeleteTravelHandbookRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteTravelHandbookRequest(Guid id) => Id = id;
}

public class DeleteTravelHandbookRequestHandler : IRequestHandler<DeleteTravelHandbookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<TravelHandbook> _TravelHandbookRepo;
    private readonly IStringLocalizer<DeleteTravelHandbookRequestHandler> _localizer;

    public DeleteTravelHandbookRequestHandler(IRepositoryWithEvents<TravelHandbook> TravelHandbookRepo, IStringLocalizer<DeleteTravelHandbookRequestHandler> localizer) =>
        (_TravelHandbookRepo,  _localizer) = (TravelHandbookRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteTravelHandbookRequest request, CancellationToken cancellationToken)
    {
        

        var item = await _TravelHandbookRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["TravelHandbook.notfound"]);

        await _TravelHandbookRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}