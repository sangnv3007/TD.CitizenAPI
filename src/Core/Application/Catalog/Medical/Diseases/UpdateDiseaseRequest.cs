namespace TD.CitizenAPI.Application.Catalog.Diseases;

public class UpdateDiseaseRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }
}

public class UpdateDiseaseRequestValidator : CustomValidator<UpdateDiseaseRequest>
{
    public UpdateDiseaseRequestValidator(IRepository<Disease> repository, IStringLocalizer<UpdateDiseaseRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateDiseaseRequestHandler : IRequestHandler<UpdateDiseaseRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Disease> _repository;
    private readonly IStringLocalizer<UpdateDiseaseRequestHandler> _localizer;

    public UpdateDiseaseRequestHandler(IRepositoryWithEvents<Disease> repository, IStringLocalizer<UpdateDiseaseRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateDiseaseRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["Disease.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Image, request.Images, request.Description, request.Content);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}