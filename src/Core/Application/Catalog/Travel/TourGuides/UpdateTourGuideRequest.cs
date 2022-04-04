namespace TD.CitizenAPI.Application.Catalog.TourGuides;

public class UpdateTourGuideRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    //Ngay het han
    public string? ExpirationDate { get; set; }
    //Noi cap
    public string? PlaceOfIssue { get; set; }
    //So the
    public string? CardNumber { get; set; }
    public string? Image { get; set; }
    //Loai the
    public string? CardType { get; set; }
    //Kinh nghiem
    public string? Experience { get; set; }
    //Ngoai ngu
    public string? ForeignLanguage { get; set; }
}


public class UpdateTourGuideRequestHandler : IRequestHandler<UpdateTourGuideRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<TourGuide> _repository;
    private readonly IStringLocalizer<UpdateTourGuideRequestHandler> _localizer;

    public UpdateTourGuideRequestHandler(IRepositoryWithEvents<TourGuide> repository, IStringLocalizer<UpdateTourGuideRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateTourGuideRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["TourGuide.notfound"], request.Id));

        item.Update(request.FullName, request.Experience, request.PlaceOfIssue, request.CardNumber, request.Image, request.CardType, request.Experience, request.ForeignLanguage);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}