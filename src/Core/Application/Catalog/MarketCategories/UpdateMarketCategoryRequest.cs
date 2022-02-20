namespace TD.CitizenAPI.Application.Catalog.MarketCategories;

public class UpdateMarketCategoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class UpdateMarketCategoryRequestValidator : CustomValidator<UpdateMarketCategoryRequest>
{
    public UpdateMarketCategoryRequestValidator(IRepository<MarketCategory> repository, IStringLocalizer<UpdateMarketCategoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateMarketCategoryRequestHandler : IRequestHandler<UpdateMarketCategoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MarketCategory> _repository;
    private readonly IStringLocalizer<UpdateMarketCategoryRequestHandler> _localizer;

    public UpdateMarketCategoryRequestHandler(IRepositoryWithEvents<MarketCategory> repository, IStringLocalizer<UpdateMarketCategoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateMarketCategoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["marketcategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Image, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}