using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.Places;

public class UpdatePlaceRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
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

public class UpdatePlaceRequestValidator : CustomValidator<UpdatePlaceRequest>
{
    public UpdatePlaceRequestValidator(IRepository<Place> repository, IStringLocalizer<UpdatePlaceRequestValidator> localizer) =>
        RuleFor(p => p.PlaceName)
            .NotEmpty()
            .MaximumLength(256);
}

public class UpdatePlaceRequestHandler : IRequestHandler<UpdatePlaceRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Place> _repository;
    private readonly IStringLocalizer<UpdatePlaceRequestHandler> _localizer;

    public UpdatePlaceRequestHandler(IRepositoryWithEvents<Place> repository, IStringLocalizer<UpdatePlaceRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdatePlaceRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["place.notfound"], request.Id));

        item.Update(request.PlaceName, request.Title, request.AddressDetail, request.Source, request.ExtraInfo, request.PhoneContact, request.Website, request.Email, request.Content, request.ContentHtml, request.Latitude, request.Longitude, request.Tags, request.Image, request.Images, request.Status, request.DateStart, request.DateEnd, request.TimeStart, request.TimeEnd, request.PlaceTypeId, request.ProvinceId, request.DistrictId, request.CommuneId);
        item.DomainEvents.Add(EntityUpdatedEvent.WithEntity(item));

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}