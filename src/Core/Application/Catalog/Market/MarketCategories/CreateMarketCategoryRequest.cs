namespace TD.CitizenAPI.Application.Catalog.MarketCategories;

public partial class CreateMarketCategoryRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class CreateMarketCategoryRequestValidator : CustomValidator<CreateMarketCategoryRequest>
{
    public CreateMarketCategoryRequestValidator(IReadRepository<MarketCategory> repository, IStringLocalizer<CreateMarketCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateMarketCategoryRequestHandler : IRequestHandler<CreateMarketCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MarketCategory> _repository;

    public CreateMarketCategoryRequestHandler(IRepositoryWithEvents<MarketCategory> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateMarketCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = new MarketCategory(request.Name, request.Code, request.Image, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}