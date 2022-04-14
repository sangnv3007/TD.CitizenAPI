namespace TD.CitizenAPI.Application.Catalog.FoodFactories;

public class GetFoodFactoryRequest : IRequest<Result<FoodFactoryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetFoodFactoryRequest(Guid id) => Id = id;
}

public class FoodFactoryByIdSpec : Specification<FoodFactory, FoodFactoryDetailsDto>, ISingleResultSpecification
{
    public FoodFactoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetFoodFactoryRequestHandler : IRequestHandler<GetFoodFactoryRequest, Result<FoodFactoryDetailsDto>>
{
    private readonly IRepository<FoodFactory> _repository;
    private readonly IStringLocalizer<GetFoodFactoryRequestHandler> _localizer;

    public GetFoodFactoryRequestHandler(IRepository<FoodFactory> repository, IStringLocalizer<GetFoodFactoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<FoodFactoryDetailsDto>> Handle(GetFoodFactoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<FoodFactory, FoodFactoryDetailsDto>)new FoodFactoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["FoodFactory.notfound"], request.Id));
        return Result<FoodFactoryDetailsDto>.Success(item);

    }
}