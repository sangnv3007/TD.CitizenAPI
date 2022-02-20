using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class UpdatePlaceTypeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
    public Guid? CategoryId { get; set; }
}

public class UpdatePlaceTypeRequestValidator : CustomValidator<UpdatePlaceTypeRequest>
{
    public UpdatePlaceTypeRequestValidator(IRepository<PlaceType> repository, IStringLocalizer<UpdatePlaceTypeRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (category, name, ct) =>
                    await repository.GetBySpecAsync(new PlaceTypeByNameSpec(name), ct)
                        is not PlaceType existingCategory || existingCategory.Id == category.Id)
                .WithMessage((_, name) => string.Format(localizer["placetype.alreadyexists"], name));
}

public class UpdatePlaceTypeRequestHandler : IRequestHandler<UpdatePlaceTypeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<PlaceType> _repository;
    private readonly IStringLocalizer<UpdatePlaceTypeRequestHandler> _localizer;

    public UpdatePlaceTypeRequestHandler(IRepositoryWithEvents<PlaceType> repository, IStringLocalizer<UpdatePlaceTypeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdatePlaceTypeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["placetype.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.Image, request.CoverImage, request.Description, request.CategoryId);
        item.DomainEvents.Add(EntityUpdatedEvent.WithEntity(item));

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}