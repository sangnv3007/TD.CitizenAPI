namespace TD.CitizenAPI.Application.Catalog.CarUtilities;

public class UpdateCarUtilityRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
}

public class UpdateCarUtilityRequestValidator : CustomValidator<UpdateCarUtilityRequest>
{
    public UpdateCarUtilityRequestValidator(IRepository<CarUtility> repository, IStringLocalizer<UpdateCarUtilityRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateCarUtilityRequestHandler : IRequestHandler<UpdateCarUtilityRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<CarUtility> _repository;
    private readonly IStringLocalizer<UpdateCarUtilityRequestHandler> _localizer;

    public UpdateCarUtilityRequestHandler(IRepositoryWithEvents<CarUtility> repository, IStringLocalizer<UpdateCarUtilityRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateCarUtilityRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["marketcategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}