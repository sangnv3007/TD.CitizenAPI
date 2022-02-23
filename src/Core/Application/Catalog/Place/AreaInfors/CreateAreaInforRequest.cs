using Mapster;
using TD.CitizenAPI.Application.Catalog.AreaInforValues;
using TD.CitizenAPI.Domain.Common.Events;

namespace TD.CitizenAPI.Application.Catalog.AreaInfors;

public class CreateAreaInforRequest : IRequest<Result<Guid>>
{
    public string AreaCode { get; set; } = default!;
    public string? Introduce { get; set; }
    public string? Acreage { get; set; }
    public string? Population { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }

    public List<AreaInforValueRequest>? Administrative { get; set; }
    public List<AreaInforValueRequest>? Populations { get; set; }
    public List<AreaInforValueRequest>? Topographic { get; set; }
    public List<AreaInforValueRequest>? Weather { get; set; }
    public List<AreaInforValueRequest>? Mineral { get; set; }
    public List<AreaInforValueRequest>? History { get; set; }
    public List<AreaInforValueRequest>? Economy { get; set; }
}

public class CreateAreaInforRequestValidator : CustomValidator<CreateAreaInforRequest>
{
    public CreateAreaInforRequestValidator(IReadRepository<AreaInfor> repository, IStringLocalizer<CreateAreaInforRequestValidator> localizer) =>
        RuleFor(p => p.AreaCode)
            .NotEmpty()
            .MaximumLength(256)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new AreaInforByAreaCodeSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["areainfor.alreadyexists"], name));
}

public class CreateAreaInforRequestHandler : IRequestHandler<CreateAreaInforRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AreaInfor> _repository;
    private readonly IRepositoryWithEvents<AreaInforValue> _areaInforValuerepository;

    public CreateAreaInforRequestHandler(IRepositoryWithEvents<AreaInfor> repository, IRepositoryWithEvents<AreaInforValue> areaInforValuerepository) => (_repository, _areaInforValuerepository) = (repository, areaInforValuerepository);

    public async Task<Result<Guid>> Handle(CreateAreaInforRequest request, CancellationToken cancellationToken)
    {
        var item = new AreaInfor(request.AreaCode, request.Introduce, request.Acreage, request.Population, request.Image, request.Images);
        item.DomainEvents.Add(EntityCreatedEvent.WithEntity(item));
        await _repository.AddAsync(item, cancellationToken);

        #region Xu ly them AreaInforValue
        try
        {
            if (request.Administrative != null)
            {
                foreach (var itemValue in request.Administrative)
                {
                    var itemValue_ = itemValue.Adapt<AreaInforValue>();
                    itemValue_.AreaInforId = item.Id;
                    itemValue_.Type = "Administrative";
                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Populations != null)
            {
                foreach (var itemValue in request.Populations)
                {
                    var itemValue_ = itemValue.Adapt<AreaInforValue>();
                    itemValue_.AreaInforId = item.Id;
                    itemValue_.Type = "Populations";
                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Topographic != null)
            {
                foreach (var itemValue in request.Topographic)
                {
                    var itemValue_ = itemValue.Adapt<AreaInforValue>();
                    itemValue_.AreaInforId = item.Id;
                    itemValue_.Type = "Topographic";
                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Weather != null)
            {
                foreach (var itemValue in request.Weather)
                {
                    var itemValue_ = itemValue.Adapt<AreaInforValue>();
                    itemValue_.AreaInforId = item.Id;
                    itemValue_.Type = "Weather";
                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Mineral != null)
            {
                foreach (var itemValue in request.Mineral)
                {
                    var itemValue_ = itemValue.Adapt<AreaInforValue>();
                    itemValue_.AreaInforId = item.Id;
                    itemValue_.Type = "Mineral";
                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.History != null)
            {
                foreach (var itemValue in request.History)
                {
                    var itemValue_ = itemValue.Adapt<AreaInforValue>();
                    itemValue_.AreaInforId = item.Id;
                    itemValue_.Type = "History";
                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Economy != null)
            {
                foreach (var itemValue in request.Economy)
                {
                    var itemValue_ = itemValue.Adapt<AreaInforValue>();
                    itemValue_.AreaInforId = item.Id;
                    itemValue_.Type = "Economy";
                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }
        }
        catch (Exception ex)
        {

        }
        #endregion Xu ly them AreaInforValue

        return Result<Guid>.Success(item.Id);
    }
}