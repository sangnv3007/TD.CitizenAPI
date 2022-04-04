namespace TD.CitizenAPI.Application.Catalog.TourGuides;

public partial class CreateTourGuideRequest : IRequest<Result<Guid>>
{
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


public class CreateTourGuideRequestHandler : IRequestHandler<CreateTourGuideRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<TourGuide> _repository;

    public CreateTourGuideRequestHandler(IRepositoryWithEvents<TourGuide> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateTourGuideRequest request, CancellationToken cancellationToken)
    {
        var item = new TourGuide(request.FullName,request.Experience,request.PlaceOfIssue,request.CardNumber,request.Image,request.CardType,request.Experience,request.ForeignLanguage);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}