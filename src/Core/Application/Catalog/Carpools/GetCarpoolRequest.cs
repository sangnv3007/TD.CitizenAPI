namespace TD.CitizenAPI.Application.Catalog.Carpools;

public class GetCarpoolRequest : IRequest<Result<CarpoolDetailsDto>>
{
    public Guid Id { get; set; }

    public GetCarpoolRequest(Guid id) => Id = id;
}

public class GetCarpoolRequestHandler : IRequestHandler<GetCarpoolRequest, Result<CarpoolDetailsDto>>
{
    private readonly IRepository<Carpool> _repository;
    private readonly IStringLocalizer<GetCarpoolRequestHandler> _localizer;

    public GetCarpoolRequestHandler(IRepository<Carpool> repository, IStringLocalizer<GetCarpoolRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<CarpoolDetailsDto>> Handle(GetCarpoolRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Carpool, CarpoolDetailsDto>)new CarpoolByIdWithIncludeSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["carpool.notfound"], request.Id));
        return Result<CarpoolDetailsDto>.Success(item);

    }
}