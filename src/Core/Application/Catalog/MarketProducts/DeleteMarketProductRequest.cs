namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class DeleteMarketProductRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteMarketProductRequest(Guid id) => Id = id;
}

public class DeleteMarketProductRequestHandler : IRequestHandler<DeleteMarketProductRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MarketProduct> _repository;
    private readonly IStringLocalizer<DeleteMarketProductRequestHandler> _localizer;

    public DeleteMarketProductRequestHandler(IRepositoryWithEvents<MarketProduct> repository, IStringLocalizer<DeleteMarketProductRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteMarketProductRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["marketproduct.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}