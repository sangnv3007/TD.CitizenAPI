using Mapster;
using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.Places;

public class CreatePlaceRequest : IRequest<Result<Guid>>
{
    public string? PlaceName { get; set; }
    public string? Title { get; set; }
    public string? AddressDetail { get; set; }
    public string? Source { get; set; }
    public string? ExtraInfo { get; set; }
    public string? PhoneContact { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? Content { get; set; }
    public string? ContentHtml { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public string? Tags { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Status { get; set; }

    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public DateTime? TimeStart { get; set; }
    public DateTime? TimeEnd { get; set; }

    public Guid? PlaceTypeId { get; set; }

    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
}

public class CreatePlaceRequestValidator : CustomValidator<CreatePlaceRequest>
{
    public CreatePlaceRequestValidator(IReadRepository<Place> repository, IStringLocalizer<CreatePlaceRequestValidator> localizer) =>
        RuleFor(p => p.PlaceName)
            .NotEmpty()
            .MaximumLength(256);
}

public class CreatePlaceRequestHandler : IRequestHandler<CreatePlaceRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Place> _repository;

    public CreatePlaceRequestHandler(IRepositoryWithEvents<Place> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreatePlaceRequest request, CancellationToken cancellationToken)
    {
        var item = new Place(request.PlaceName, request.Title, request.AddressDetail, request.Source, request.ExtraInfo, request.PhoneContact, request.Website, request.Email, request.Content, request.ContentHtml, request.Latitude, request.Longitude, request.Tags, request.Image, request.Images, request.Status, request.DateStart, request.DateEnd, request.TimeStart, request.TimeEnd, request.PlaceTypeId, request.ProvinceId, request.DistrictId, request.CommuneId);
        item.DomainEvents.Add(EntityCreatedEvent.WithEntity(item));

        await _repository.AddAsync(item, cancellationToken);

        return Result<Guid>.Success(item.Id);
    }
}