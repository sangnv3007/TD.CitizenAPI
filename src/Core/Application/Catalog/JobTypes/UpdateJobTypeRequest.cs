namespace TD.CitizenAPI.Application.Catalog.JobTypes;

public class UpdateJobTypeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UpdateJobTypeRequestValidator : CustomValidator<UpdateJobTypeRequest>
{
    public UpdateJobTypeRequestValidator(IRepository<JobType> repository, IStringLocalizer<UpdateJobTypeRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateJobTypeRequestHandler : IRequestHandler<UpdateJobTypeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobType> _repository;
    private readonly IStringLocalizer<UpdateJobTypeRequestHandler> _localizer;

    public UpdateJobTypeRequestHandler(IRepositoryWithEvents<JobType> repository, IStringLocalizer<UpdateJobTypeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateJobTypeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["JobType.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}