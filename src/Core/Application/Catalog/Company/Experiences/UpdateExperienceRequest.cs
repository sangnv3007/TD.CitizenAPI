namespace TD.CitizenAPI.Application.Catalog.Experiences;

public class UpdateExperienceRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class UpdateExperienceRequestValidator : CustomValidator<UpdateExperienceRequest>
{
    public UpdateExperienceRequestValidator(IRepository<Experience> repository, IStringLocalizer<UpdateExperienceRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateExperienceRequestHandler : IRequestHandler<UpdateExperienceRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Experience> _repository;
    private readonly IStringLocalizer<UpdateExperienceRequestHandler> _localizer;

    public UpdateExperienceRequestHandler(IRepositoryWithEvents<Experience> repository, IStringLocalizer<UpdateExperienceRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateExperienceRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["Experience.notfound"], request.Id));

        item.Update(request.Name, request.Code,  request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}