namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class GetMarketProductRequest : IRequest<Result<MarketProductDetailsDto>>
{
    public Guid Id { get; set; }

    public GetMarketProductRequest(Guid id) => Id = id;
}

public class GetMarketProductRequestHandler : IRequestHandler<GetMarketProductRequest, Result<MarketProductDetailsDto>>
{
    private readonly IRepository<MarketProduct> _repository;
    private readonly IStringLocalizer<GetMarketProductRequestHandler> _localizer;

    public GetMarketProductRequestHandler(IRepository<MarketProduct> repository, IStringLocalizer<GetMarketProductRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<MarketProductDetailsDto>> Handle(GetMarketProductRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<MarketProduct, MarketProductDetailsDto>)new MarketProductByIdWithIncludeSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["marketproduct.notfound"], request.Id));
        return Result<MarketProductDetailsDto>.Success(item);

    }
}