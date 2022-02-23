namespace TD.CitizenAPI.Application.Catalog.CarPolicies;

public class UpdateCarPolicyRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
}

public class UpdateCarPolicyRequestValidator : CustomValidator<UpdateCarPolicyRequest>
{
    public UpdateCarPolicyRequestValidator(IRepository<CarPolicy> repository, IStringLocalizer<UpdateCarPolicyRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateCarPolicyRequestHandler : IRequestHandler<UpdateCarPolicyRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<CarPolicy> _repository;
    private readonly IStringLocalizer<UpdateCarPolicyRequestHandler> _localizer;

    public UpdateCarPolicyRequestHandler(IRepositoryWithEvents<CarPolicy> repository, IStringLocalizer<UpdateCarPolicyRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateCarPolicyRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["marketcategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}