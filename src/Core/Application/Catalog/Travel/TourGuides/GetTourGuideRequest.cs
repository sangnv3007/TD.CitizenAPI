namespace TD.CitizenAPI.Application.Catalog.TourGuides;

public class GetTourGuideRequest : IRequest<Result<TourGuideDetailsDto>>
{
    public Guid Id { get; set; }

    public GetTourGuideRequest(Guid id) => Id = id;
}

public class TourGuideByIdSpec : Specification<TourGuide, TourGuideDetailsDto>, ISingleResultSpecification
{
    public TourGuideByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetTourGuideRequestHandler : IRequestHandler<GetTourGuideRequest, Result<TourGuideDetailsDto>>
{
    private readonly IRepository<TourGuide> _repository;
    private readonly IStringLocalizer<GetTourGuideRequestHandler> _localizer;

    public GetTourGuideRequestHandler(IRepository<TourGuide> repository, IStringLocalizer<GetTourGuideRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<TourGuideDetailsDto>> Handle(GetTourGuideRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<TourGuide, TourGuideDetailsDto>)new TourGuideByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["TourGuide.notfound"], request.Id));
        return Result<TourGuideDetailsDto>.Success(item);

    }
}