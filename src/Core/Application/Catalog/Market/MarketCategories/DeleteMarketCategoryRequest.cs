using TD.CitizenAPI.Application.Catalog.MarketProducts;

namespace TD.CitizenAPI.Application.Catalog.MarketCategories;

public class DeleteMarketCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteMarketCategoryRequest(Guid id) => Id = id;
}

public class DeleteMarketCategoryRequestHandler : IRequestHandler<DeleteMarketCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MarketCategory> _marketCategoryRepo;
    private readonly IReadRepository<MarketProduct> _marketProductRepo;
    private readonly IStringLocalizer<DeleteMarketCategoryRequestHandler> _localizer;

    public DeleteMarketCategoryRequestHandler(IRepositoryWithEvents<MarketCategory> marketCategoryRepo, IReadRepository<MarketProduct> marketProductRepo, IStringLocalizer<DeleteMarketCategoryRequestHandler> localizer) =>
        (_marketCategoryRepo, _marketProductRepo, _localizer) = (marketCategoryRepo, marketProductRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteMarketCategoryRequest request, CancellationToken cancellationToken)
    {
        if (await _marketProductRepo.AnyAsync(new MarketProductByMarketCategorySpec(request.Id), cancellationToken))
        {
            throw new ConflictException(_localizer["marketcategory.cannotbedeleted"]);
        }

        var item = await _marketCategoryRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["marketcategory.notfound"]);

        await _marketCategoryRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}