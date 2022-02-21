namespace TD.CitizenAPI.Application.Catalog.Industries;

public class UpdateIndustryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UpdateIndustryRequestValidator : CustomValidator<UpdateIndustryRequest>
{
    public UpdateIndustryRequestValidator(IRepository<Industry> repository, IStringLocalizer<UpdateIndustryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateIndustryRequestHandler : IRequestHandler<UpdateIndustryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Industry> _repository;
    private readonly IStringLocalizer<UpdateIndustryRequestHandler> _localizer;

    public UpdateIndustryRequestHandler(IRepositoryWithEvents<Industry> repository, IStringLocalizer<UpdateIndustryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateIndustryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["Industry.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}