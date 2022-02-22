namespace TD.CitizenAPI.Application.Catalog.JobAges;

public class UpdateJobAgeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UpdateJobAgeRequestValidator : CustomValidator<UpdateJobAgeRequest>
{
    public UpdateJobAgeRequestValidator(IRepository<JobAge> repository, IStringLocalizer<UpdateJobAgeRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateJobAgeRequestHandler : IRequestHandler<UpdateJobAgeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobAge> _repository;
    private readonly IStringLocalizer<UpdateJobAgeRequestHandler> _localizer;

    public UpdateJobAgeRequestHandler(IRepositoryWithEvents<JobAge> repository, IStringLocalizer<UpdateJobAgeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateJobAgeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["JobAge.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}