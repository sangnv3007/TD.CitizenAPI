namespace TD.CitizenAPI.Application.Catalog.TourGuides;

public class DeleteTourGuideRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteTourGuideRequest(Guid id) => Id = id;
}

public class DeleteTourGuideRequestHandler : IRequestHandler<DeleteTourGuideRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<TourGuide> _TourGuideRepo;
    private readonly IStringLocalizer<DeleteTourGuideRequestHandler> _localizer;

    public DeleteTourGuideRequestHandler(IRepositoryWithEvents<TourGuide> TourGuideRepo, IStringLocalizer<DeleteTourGuideRequestHandler> localizer) =>
        (_TourGuideRepo, _localizer) = (TourGuideRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteTourGuideRequest request, CancellationToken cancellationToken)
    {
   

        var item = await _TourGuideRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["TourGuide.notfound"]);

        await _TourGuideRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}