using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.MedicalHotlines;

public class CreateMedicalHotlineRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Address { get; set; }
    public string? Code { get; set; }
    public string? Detail { get; set; }
    public string? OtherDetail { get; set; }
    public string? Phone { get; set; }
    public string? Image { get; set; }
    public int? Order { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
}

public class CreateHotlineRequestValidator : CustomValidator<CreateMedicalHotlineRequest>
{
    public CreateHotlineRequestValidator(IReadRepository<MedicalHotline> repository, IStringLocalizer<CreateHotlineRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(256);
}

public class CreateMarketProductRequestHandler : IRequestHandler<CreateMedicalHotlineRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MedicalHotline> _repository;

    public CreateMarketProductRequestHandler(IRepositoryWithEvents<MedicalHotline> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateMedicalHotlineRequest request, CancellationToken cancellationToken)
    {
        var item = new MedicalHotline(request.Name, request.Address, request.Code, request.Detail, request.OtherDetail, request.Phone, request.Image, true, request.Order,request.Latitude, request.Longitude);
        item.DomainEvents.Add(EntityCreatedEvent.WithEntity(item));

        await _repository.AddAsync(item, cancellationToken);

        return Result<Guid>.Success(item.Id);
    }
}