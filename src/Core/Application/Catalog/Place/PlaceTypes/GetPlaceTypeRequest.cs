namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class GetPlaceTypeRequest : IRequest<Result<PlaceTypeDetailsDto>>
{
    public Guid Id { get; set; }

    public GetPlaceTypeRequest(Guid id) => Id = id;
}

public class GetPlaceTypeRequestHandler : IRequestHandler<GetPlaceTypeRequest, Result<PlaceTypeDetailsDto>>
{
    private readonly IRepository<PlaceType> _repository;
    private readonly IStringLocalizer<GetPlaceTypeRequestHandler> _localizer;

    public GetPlaceTypeRequestHandler(IRepository<PlaceType> repository, IStringLocalizer<GetPlaceTypeRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<PlaceTypeDetailsDto>> Handle(GetPlaceTypeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<PlaceType, PlaceTypeDetailsDto>)new PlaceTypeByIdWithCategorySpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["placetype.notfound"], request.Id));
        return Result<PlaceTypeDetailsDto>.Success(item);

    }
}