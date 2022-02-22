namespace TD.CitizenAPI.Application.Catalog.Areas;

public class GetAreaRequest : IRequest<Result<AreaDetailsDto>>
{
    public Guid Id { get; set; }

    public GetAreaRequest(Guid id) => Id = id;
}

public class AreaByIdSpec : Specification<Area, AreaDetailsDto>, ISingleResultSpecification
{
    public AreaByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetAreaRequestHandler : IRequestHandler<GetAreaRequest, Result<AreaDetailsDto>>
{
    private readonly IRepository<Area> _repository;
    private readonly IStringLocalizer<GetAreaRequestHandler> _localizer;

    public GetAreaRequestHandler(IRepository<Area> repository, IStringLocalizer<GetAreaRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<AreaDetailsDto>> Handle(GetAreaRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Area, AreaDetailsDto>)new AreaByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["area.notfound"], request.Id));
        return Result<AreaDetailsDto>.Success(item);

    }
}