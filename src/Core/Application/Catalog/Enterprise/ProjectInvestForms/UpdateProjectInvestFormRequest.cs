namespace TD.CitizenAPI.Application.Catalog.ProjectInvestForms;

public class UpdateProjectInvestFormRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? Description { get; set; }
}

public class UpdateProjectInvestFormRequestValidator : CustomValidator<UpdateProjectInvestFormRequest>
{
    public UpdateProjectInvestFormRequestValidator(IRepository<ProjectInvestForm> repository, IStringLocalizer<UpdateProjectInvestFormRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateProjectInvestFormRequestHandler : IRequestHandler<UpdateProjectInvestFormRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProjectInvestForm> _repository;
    private readonly IStringLocalizer<UpdateProjectInvestFormRequestHandler> _localizer;

    public UpdateProjectInvestFormRequestHandler(IRepositoryWithEvents<ProjectInvestForm> repository, IStringLocalizer<UpdateProjectInvestFormRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateProjectInvestFormRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["ProjectInvestForm.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.Image, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}