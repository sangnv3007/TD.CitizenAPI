namespace TD.CitizenAPI.Application.Catalog.CarUtilities;

public class GetCarUtilityRequest : IRequest<Result<CarUtilityDetailsDto>>
{
    public Guid Id { get; set; }

    public GetCarUtilityRequest(Guid id) => Id = id;
}

public class CarUtilityByIdSpec : Specification<CarUtility, CarUtilityDetailsDto>, ISingleResultSpecification
{
    public CarUtilityByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetCarUtilityRequestHandler : IRequestHandler<GetCarUtilityRequest, Result<CarUtilityDetailsDto>>
{
    private readonly IRepository<CarUtility> _repository;
    private readonly IStringLocalizer<GetCarUtilityRequestHandler> _localizer;

    public GetCarUtilityRequestHandler(IRepository<CarUtility> repository, IStringLocalizer<GetCarUtilityRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<CarUtilityDetailsDto>> Handle(GetCarUtilityRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<CarUtility, CarUtilityDetailsDto>)new CarUtilityByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["CarUtility.notfound"], request.Id));
        return Result<CarUtilityDetailsDto>.Success(item);

    }
}