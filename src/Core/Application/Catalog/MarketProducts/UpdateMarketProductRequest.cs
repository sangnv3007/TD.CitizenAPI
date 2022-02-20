using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.MarketProducts;

public class UpdateMarketProductRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public Guid? MarketCategoryId { get; set; }
    public string? Name { get; set; }
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

public class UpdateMarketProductRequestValidator : CustomValidator<UpdateMarketProductRequest>
{
    public UpdateMarketProductRequestValidator(IRepository<MarketProduct> repository, IStringLocalizer<UpdateMarketProductRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(256);
}

public class UpdateMarketProductRequestHandler : IRequestHandler<UpdateMarketProductRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MarketProduct> _repository;
    private readonly IStringLocalizer<UpdateMarketProductRequestHandler> _localizer;

    public UpdateMarketProductRequestHandler(IRepositoryWithEvents<MarketProduct> repository, IStringLocalizer<UpdateMarketProductRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateMarketProductRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["marketproduct.notfound"], request.Id));

        item.Update(request.MarketCategoryId, request.Name, request.Packaging, request.Price, request.Brand, request.Code, request.Image, request.Unit, request.Origin, request.Description, request.DisplayUnit, request.DisplayFactor);
        item.DomainEvents.Add(EntityUpdatedEvent.WithEntity(item));

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}