using Mapster;
using TD.CitizenAPI.Application.Catalog.AreaInforValues;
using TD.CitizenAPI.Application.Catalog.Areas;

namespace TD.CitizenAPI.Application.Catalog.AreaInfors;

public class GetAreaInforRequest : IRequest<Result<AreaInforDetailsDto>>
{
    public string Code { get; set; }

    public GetAreaInforRequest(string code) => Code = code;
}

public class GetAreaInforRequestHandler : IRequestHandler<GetAreaInforRequest, Result<AreaInforDetailsDto>>
{
    private readonly IRepository<AreaInfor> _repository;
    private readonly IReadRepository<Area> _areaRepository;
    private readonly IRepository<AreaInforValue> _areaInforValueRepository;
    private readonly IStringLocalizer<GetAreaInforRequestHandler> _localizer;
    private readonly ICurrentUser _currentUser;

    public GetAreaInforRequestHandler(IRepository<AreaInfor> repository, IReadRepository<Area> areaRepository, IRepository<AreaInforValue> areaInforValueRepository, IStringLocalizer<GetAreaInforRequestHandler> localizer, ICurrentUser currentUser) => (_repository, _areaRepository, _areaInforValueRepository, _localizer, _currentUser) = (repository, areaRepository, areaInforValueRepository, localizer, currentUser);

    public async Task<Result<AreaInforDetailsDto>> Handle(GetAreaInforRequest request, CancellationToken cancellationToken)
    {

        var area = await _areaRepository.GetBySpecAsync(new AreaByCodeSpec(request.Code), cancellationToken) ?? throw new NotFoundException(string.Format(_localizer["area.notfound"], request.Code));

        var areaInfor = await _repository.GetBySpecAsync(new AreaInforByAreaCodeSpec(request.Code), cancellationToken) ?? throw new NotFoundException(string.Format(_localizer["areainfor.notfound"], request.Code));

        var lstAreas = await _areaRepository.ListAsync(new AreasByParentCodeSpec(request.Code), cancellationToken);

        List<AreaInforChildResponse> children = new List<AreaInforChildResponse>();

        if (lstAreas != null)
        {
            foreach (var areaItem in lstAreas)
            {
                var child = await _repository.GetBySpecAsync(new AreaInforByAreaCodeSpec(areaItem.Code), cancellationToken);
                if (child != null)
                {
                    var chl = new AreaInforChildResponse() { Id = child.Id, Name = areaItem.Name, NameWithType = areaItem.NameWithType, Type = areaItem.Type, Level = areaItem.Level, Image = child.Image, Code = child.AreaCode };
                    children.Add(chl);
                }

            }
        }

        var mappedArea = areaInfor.Adapt<AreaInforDetailsDto>();
        mappedArea.Children = children.Count > 0 ? children : null;
        mappedArea.Name = area.Name;
        mappedArea.NameWithType = area.NameWithType;
        mappedArea.Type = area.Type;
        mappedArea.Level = area.Level;

        var lstValue = await _areaInforValueRepository.ListAsync(new AreaInforValueByAreaInforSpec(areaInfor.Id), cancellationToken);
        if (lstValue.Any())
        {
            mappedArea.Administrative = lstValue.Where(p => p.Type == "Administrative").ToList().Adapt<List<AreaInforValueDto>>();
            mappedArea.Populations = lstValue.Where(p => p.Type == "Populations").ToList().Adapt<List<AreaInforValueDto>>();
            mappedArea.Topographic = lstValue.Where(p => p.Type == "Topographic").ToList().Adapt<List<AreaInforValueDto>>();
            mappedArea.Weather = lstValue.Where(p => p.Type == "Weather").ToList().Adapt<List<AreaInforValueDto>>();
            mappedArea.Mineral = lstValue.Where(p => p.Type == "Mineral").ToList().Adapt<List<AreaInforValueDto>>();
            mappedArea.History = lstValue.Where(p => p.Type == "History").ToList().Adapt<List<AreaInforValueDto>>();
            mappedArea.Economy = lstValue.Where(p => p.Type == "Economy").ToList().Adapt<List<AreaInforValueDto>>();
        }

        return Result<AreaInforDetailsDto>.Success(mappedArea);

    }
}