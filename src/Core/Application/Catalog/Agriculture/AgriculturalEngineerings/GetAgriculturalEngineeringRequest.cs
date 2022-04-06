namespace TD.CitizenAPI.Application.Catalog.AgriculturalEngineerings;

public class GetAgriculturalEngineeringRequest : IRequest<Result<AgriculturalEngineeringDetailsDto>>
{
    public Guid Id { get; set; }

    public GetAgriculturalEngineeringRequest(Guid id) => Id = id;
}

public class GetAgriculturalEngineeringRequestHandler : IRequestHandler<GetAgriculturalEngineeringRequest, Result<AgriculturalEngineeringDetailsDto>>
{
    private readonly IRepository<AgriculturalEngineering> _repository;
    private readonly IStringLocalizer<GetAgriculturalEngineeringRequestHandler> _localizer;

    public GetAgriculturalEngineeringRequestHandler(IRepository<AgriculturalEngineering> repository, IStringLocalizer<GetAgriculturalEngineeringRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<AgriculturalEngineeringDetailsDto>> Handle(GetAgriculturalEngineeringRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<AgriculturalEngineering, AgriculturalEngineeringDetailsDto>)new AgriculturalEngineeringByIdWithIncludeSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["AgriculturalEngineering.notfound"], request.Id));
        return Result<AgriculturalEngineeringDetailsDto>.Success(item);

    }
}