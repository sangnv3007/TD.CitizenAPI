namespace TD.CitizenAPI.Application.Catalog.FoodWarnings;

public class UpdateFoodWarningRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
}

public class UpdateFoodWarningRequestValidator : CustomValidator<UpdateFoodWarningRequest>
{
    public UpdateFoodWarningRequestValidator(IRepository<FoodWarning> repository, IStringLocalizer<UpdateFoodWarningRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateFoodWarningRequestHandler : IRequestHandler<UpdateFoodWarningRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FoodWarning> _repository;
    private readonly IStringLocalizer<UpdateFoodWarningRequestHandler> _localizer;

    public UpdateFoodWarningRequestHandler(IRepositoryWithEvents<FoodWarning> repository, IStringLocalizer<UpdateFoodWarningRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateFoodWarningRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["FoodWarning.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Image, request.Images, request.Description, request.Content);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}