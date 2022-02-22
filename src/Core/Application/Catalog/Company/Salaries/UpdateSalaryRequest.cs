namespace TD.CitizenAPI.Application.Catalog.Salaries;

public class UpdateSalaryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UpdateSalaryRequestValidator : CustomValidator<UpdateSalaryRequest>
{
    public UpdateSalaryRequestValidator(IRepository<Salary> repository, IStringLocalizer<UpdateSalaryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateSalaryRequestHandler : IRequestHandler<UpdateSalaryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Salary> _repository;
    private readonly IStringLocalizer<UpdateSalaryRequestHandler> _localizer;

    public UpdateSalaryRequestHandler(IRepositoryWithEvents<Salary> repository, IStringLocalizer<UpdateSalaryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateSalaryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["Salary.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}