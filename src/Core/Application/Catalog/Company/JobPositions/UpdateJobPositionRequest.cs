namespace TD.CitizenAPI.Application.Catalog.JobPositions;

public class UpdateJobPositionRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UpdateJobPositionRequestValidator : CustomValidator<UpdateJobPositionRequest>
{
    public UpdateJobPositionRequestValidator(IRepository<JobPosition> repository, IStringLocalizer<UpdateJobPositionRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateJobPositionRequestHandler : IRequestHandler<UpdateJobPositionRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobPosition> _repository;
    private readonly IStringLocalizer<UpdateJobPositionRequestHandler> _localizer;

    public UpdateJobPositionRequestHandler(IRepositoryWithEvents<JobPosition> repository, IStringLocalizer<UpdateJobPositionRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateJobPositionRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["JobPosition.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}