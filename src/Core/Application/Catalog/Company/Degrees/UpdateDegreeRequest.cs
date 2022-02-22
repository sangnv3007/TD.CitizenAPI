namespace TD.CitizenAPI.Application.Catalog.Degrees;

public class UpdateDegreeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UpdateDegreeRequestValidator : CustomValidator<UpdateDegreeRequest>
{
    public UpdateDegreeRequestValidator(IRepository<Degree> repository, IStringLocalizer<UpdateDegreeRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateDegreeRequestHandler : IRequestHandler<UpdateDegreeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Degree> _repository;
    private readonly IStringLocalizer<UpdateDegreeRequestHandler> _localizer;

    public UpdateDegreeRequestHandler(IRepositoryWithEvents<Degree> repository, IStringLocalizer<UpdateDegreeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateDegreeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["degree.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}