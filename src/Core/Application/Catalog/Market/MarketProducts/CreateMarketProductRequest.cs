using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class CreateMarketProductRequest : IRequest<Result<Guid>>
{
    public Guid? MarketCategoryId { get; set; }
    public string Name { get; set; } = default!;
    public string? Packaging { get; set; }
    public int Price { get; set; }
    public string? Brand { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Unit { get; set; }
    public string? Origin { get; set; }
    public string? Description { get; set; }
    public string? DisplayUnit { get; set; }
    public string? DisplayFactor { get; set; }
}

public class CreateMarketProductRequestValidator : CustomValidator<CreateMarketProductRequest>
{
    public CreateMarketProductRequestValidator(IReadRepository<MarketProduct> repository, IStringLocalizer<CreateMarketProductRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(256);
}

public class CreateMarketProductRequestHandler : IRequestHandler<CreateMarketProductRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MarketProduct> _repository;

    public CreateMarketProductRequestHandler(IRepositoryWithEvents<MarketProduct> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateMarketProductRequest request, CancellationToken cancellationToken)
    {
        var item = new MarketProduct(request.MarketCategoryId, request.Name, request.Packaging, request.Price, request.Brand, request.Code, request.Image, request.Unit, request.Origin, request.Description, request.DisplayUnit, request.DisplayFactor);
        item.DomainEvents.Add(EntityCreatedEvent.WithEntity(item));

        await _repository.AddAsync(item, cancellationToken);

        return Result<Guid>.Success(item.Id);
    }
}