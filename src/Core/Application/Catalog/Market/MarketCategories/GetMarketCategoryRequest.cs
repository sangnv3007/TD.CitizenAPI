namespace TD.CitizenAPI.Application.Catalog.MarketCategories;

public class GetMarketCategoryRequest : IRequest<Result<MarketCategoryDetailsDto>>
{
    public Guid Id { get; set; }

    public GetMarketCategoryRequest(Guid id) => Id = id;
}

public class MarketCategoryByIdSpec : Specification<MarketCategory, MarketCategoryDetailsDto>, ISingleResultSpecification
{
    public MarketCategoryByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetMarketCategoryRequestHandler : IRequestHandler<GetMarketCategoryRequest, Result<MarketCategoryDetailsDto>>
{
    private readonly IRepository<MarketCategory> _repository;
    private readonly IStringLocalizer<GetMarketCategoryRequestHandler> _localizer;

    public GetMarketCategoryRequestHandler(IRepository<MarketCategory> repository, IStringLocalizer<GetMarketCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<MarketCategoryDetailsDto>> Handle(GetMarketCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<MarketCategory, MarketCategoryDetailsDto>)new MarketCategoryByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["marketcategory.notfound"], request.Id));
        return Result<MarketCategoryDetailsDto>.Success(item);

    }
}