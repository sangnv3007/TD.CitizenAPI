namespace TD.CitizenAPI.Application.Catalog.JobNames;

public class UpdateJobNameRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UpdateJobNameRequestValidator : CustomValidator<UpdateJobNameRequest>
{
    public UpdateJobNameRequestValidator(IRepository<JobName> repository, IStringLocalizer<UpdateJobNameRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateJobNameRequestHandler : IRequestHandler<UpdateJobNameRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobName> _repository;
    private readonly IStringLocalizer<UpdateJobNameRequestHandler> _localizer;

    public UpdateJobNameRequestHandler(IRepositoryWithEvents<JobName> repository, IStringLocalizer<UpdateJobNameRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateJobNameRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["JobName.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}