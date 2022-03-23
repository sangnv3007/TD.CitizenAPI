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

/*public class CreateAreaInforRequestValidator : CustomValidator<CreateAreaInforRequest>
{
    public CreateAreaInforRequestValidator(IReadRepository<AreaInfor> repository, IStringLocalizer<CreateAreaInforRequestValidator> localizer) =>
        RuleFor(p => p.AreaCode)
            .NotEmpty()
            .MaximumLength(256)
            .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new AreaInforByAreaCodeSpec(name), ct) is null)
                .WithMessage((_, name) => string.Format(localizer["areainfor.alreadyexists"], name));
}*/

public class CreateAreaInforRequestHandler : IRequestHandler<CreateAreaInforRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AreaInfor> _repository;
    private readonly IRepositoryWithEvents<AreaInforValue> _areaInforValuerepository;

    public CreateAreaInforRequestHandler(IRepositoryWithEvents<AreaInfor> repository, IRepositoryWithEvents<AreaInforValue> areaInforValuerepository) => (_repository, _areaInforValuerepository) = (repository, areaInforValuerepository);

    public async Task<Result<Guid>> Handle(CreateAreaInforRequest request, CancellationToken cancellationToken)
    {

        var areaInfor = await _repository.GetBySpecAsync(new AreaInforByAreaCodeSpec(request.AreaCode), cancellationToken);

        if (areaInfor != null)
        {
            var lstValue = await _areaInforValuerepository.ListAsync(new AreaInforValuesByCodeSpec(areaInfor.Id), cancellationToken);
            await _repository.DeleteAsync(areaInfor);
            if (lstValue != null && lstValue.Count>0)
            await _areaInforValuerepository.DeleteRangeAsync(lstValue);
        }

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
                    AreaInforValue itemValue_ = new AreaInforValue(itemValue.Key, itemValue.Value, "Administrative", itemValue.Order ?? 1, item.Id);

                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Populations != null)
            {
                foreach (var itemValue in request.Populations)
                {
                    AreaInforValue itemValue_ = new AreaInforValue(itemValue.Key, itemValue.Value, "Populations", itemValue.Order ?? 1, item.Id);
                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Topographic != null)
            {
                foreach (var itemValue in request.Topographic)
                {
                    AreaInforValue itemValue_ = new AreaInforValue(itemValue.Key, itemValue.Value, "Topographic", itemValue.Order ?? 1, item.Id);

                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Weather != null)
            {
                foreach (var itemValue in request.Weather)
                {

                    AreaInforValue itemValue_ = new AreaInforValue(itemValue.Key, itemValue.Value, "Weather", itemValue.Order ?? 1, item.Id);

                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Mineral != null)
            {
                foreach (var itemValue in request.Mineral)
                {
                    AreaInforValue itemValue_ = new AreaInforValue(itemValue.Key, itemValue.Value, "Mineral", itemValue.Order ?? 1, item.Id);

                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.History != null)
            {
                foreach (var itemValue in request.History)
                {
                    AreaInforValue itemValue_ = new AreaInforValue(itemValue.Key, itemValue.Value, "History", itemValue.Order ?? 1, item.Id);

                    await _areaInforValuerepository.AddAsync(itemValue_, cancellationToken);
                }
            }

            if (request.Economy != null)
            {
                foreach (var itemValue in request.Economy)
                {
                    AreaInforValue itemValue_ = new AreaInforValue(itemValue.Key, itemValue.Value, "Economy", itemValue.Order ?? 1, item.Id);

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