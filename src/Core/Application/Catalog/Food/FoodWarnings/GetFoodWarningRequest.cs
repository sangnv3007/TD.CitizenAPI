namespace TD.CitizenAPI.Application.Catalog.FoodWarnings;

public class GetFoodWarningRequest : IRequest<Result<FoodWarningDetailsDto>>
{
    public Guid Id { get; set; }

    public GetFoodWarningRequest(Guid id) => Id = id;
}

public class FoodWarningByIdSpec : Specification<FoodWarning, FoodWarningDetailsDto>, ISingleResultSpecification
{
    public FoodWarningByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetFoodWarningRequestHandler : IRequestHandler<GetFoodWarningRequest, Result<FoodWarningDetailsDto>>
{
    private readonly IRepository<FoodWarning> _repository;
    private readonly IStringLocalizer<GetFoodWarningRequestHandler> _localizer;

    public GetFoodWarningRequestHandler(IRepository<FoodWarning> repository, IStringLocalizer<GetFoodWarningRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<FoodWarningDetailsDto>> Handle(GetFoodWarningRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<FoodWarning, FoodWarningDetailsDto>)new FoodWarningByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["FoodWarning.notfound"], request.Id));
        return Result<FoodWarningDetailsDto>.Success(item);

    }
}