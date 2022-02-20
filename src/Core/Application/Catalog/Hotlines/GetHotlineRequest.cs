namespace TD.CitizenAPI.Application.Catalog.Hotlines;

public class GetHotlineRequest : IRequest<Result<HotlineDetailsDto>>
{
    public Guid Id { get; set; }

    public GetHotlineRequest(Guid id) => Id = id;
}

public class GetHotlineRequestHandler : IRequestHandler<GetHotlineRequest, Result<HotlineDetailsDto>>
{
    private readonly IRepository<Hotline> _repository;
    private readonly IStringLocalizer<GetHotlineRequestHandler> _localizer;

    public GetHotlineRequestHandler(IRepository<Hotline> repository, IStringLocalizer<GetHotlineRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<HotlineDetailsDto>> Handle(GetHotlineRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Hotline, HotlineDetailsDto>)new HotlineByIdWithIncludeSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["hotline.notfound"], request.Id));
        return Result<HotlineDetailsDto>.Success(item);

    }
}