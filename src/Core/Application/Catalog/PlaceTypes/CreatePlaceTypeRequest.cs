using Mapster;
using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.PlaceTypes;

public class CreatePlaceTypeRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Icon { get; set; }
    public string? Image { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
    public Guid? CategoryId { get; set; }
}

public class CreatePlaceTypeRequestValidator : CustomValidator<CreatePlaceTypeRequest>
{
    public CreatePlaceTypeRequestValidator(IReadRepository<PlaceType> repository, IStringLocalizer<CreatePlaceTypeRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(256)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new PlaceTypeByNameSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["placetype.alreadyexists"], name));
}

public class CreatePlaceTypeRequestHandler : IRequestHandler<CreatePlaceTypeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<PlaceType> _repository;

    public CreatePlaceTypeRequestHandler(IRepositoryWithEvents<PlaceType> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreatePlaceTypeRequest request, CancellationToken cancellationToken)
    {
        //var item = request.Adapt<PlaceType>();
        var item = new PlaceType(request.Name, request.Code, request.Icon, request.Image, request.CoverImage, request.Description, request.CategoryId);
        item.DomainEvents.Add(EntityCreatedEvent.WithEntity(item));

        await _repository.AddAsync(item, cancellationToken);

        return Result<Guid>.Success(item.Id);
    }
}