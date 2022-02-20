namespace TD.CitizenAPI.Application.Catalog.Places;

public class GetPlaceRequest : IRequest<Result<PlaceDetailsDto>>
{
    public Guid Id { get; set; }

    public GetPlaceRequest(Guid id) => Id = id;
}

public class GetPlaceRequestHandler : IRequestHandler<GetPlaceRequest, Result<PlaceDetailsDto>>
{
    private readonly IRepository<Place> _repository;
    private readonly IStringLocalizer<GetPlaceRequestHandler> _localizer;

    public GetPlaceRequestHandler(IRepository<Place> repository, IStringLocalizer<GetPlaceRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<PlaceDetailsDto>> Handle(GetPlaceRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Place, PlaceDetailsDto>)new PlaceByIdWithIncludeSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["place.notfound"], request.Id));
        return Result<PlaceDetailsDto>.Success(item);

    }
}