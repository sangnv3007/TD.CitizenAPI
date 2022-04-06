using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineerings;

public class UpdateAgriculturalEngineeringRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid? AgriculturalEngineeringCategoryId { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
}

public class UpdateAgriculturalEngineeringRequestValidator : CustomValidator<UpdateAgriculturalEngineeringRequest>
{
    public UpdateAgriculturalEngineeringRequestValidator(IRepository<AgriculturalEngineering> repository, IStringLocalizer<UpdateAgriculturalEngineeringRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(256);
}

public class UpdateAgriculturalEngineeringRequestHandler : IRequestHandler<UpdateAgriculturalEngineeringRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AgriculturalEngineering> _repository;
    private readonly IStringLocalizer<UpdateAgriculturalEngineeringRequestHandler> _localizer;

    public UpdateAgriculturalEngineeringRequestHandler(IRepositoryWithEvents<AgriculturalEngineering> repository, IStringLocalizer<UpdateAgriculturalEngineeringRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateAgriculturalEngineeringRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["AgriculturalEngineering.notfound"], request.Id));

        item.Update(request.Name, request.AgriculturalEngineeringCategoryId, request.Code, request.Image, request.Content, request.Description);
        item.DomainEvents.Add(EntityUpdatedEvent.WithEntity(item));

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}