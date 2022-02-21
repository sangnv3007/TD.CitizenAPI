namespace TD.CitizenAPI.Application.Catalog.Benefits;

public class UpdateBenefitRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
}

public class UpdateBenefitRequestValidator : CustomValidator<UpdateBenefitRequest>
{
    public UpdateBenefitRequestValidator(IRepository<Benefit> repository, IStringLocalizer<UpdateBenefitRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateBenefitRequestHandler : IRequestHandler<UpdateBenefitRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Benefit> _repository;
    private readonly IStringLocalizer<UpdateBenefitRequestHandler> _localizer;

    public UpdateBenefitRequestHandler(IRepositoryWithEvents<Benefit> repository, IStringLocalizer<UpdateBenefitRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateBenefitRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["hotlinecategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}