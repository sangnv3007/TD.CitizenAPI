namespace TD.CitizenAPI.Application.Catalog.LaborMarketInformations;

public class GetLaborMarketInformationRequest : IRequest<Result<LaborMarketInformationDetailsDto>>
{
    public Guid Id { get; set; }

    public GetLaborMarketInformationRequest(Guid id) => Id = id;
}

public class LaborMarketInformationByIdSpec : Specification<LaborMarketInformation, LaborMarketInformationDetailsDto>, ISingleResultSpecification
{
    public LaborMarketInformationByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetLaborMarketInformationRequestHandler : IRequestHandler<GetLaborMarketInformationRequest, Result<LaborMarketInformationDetailsDto>>
{
    private readonly IRepository<LaborMarketInformation> _repository;
    private readonly IStringLocalizer<GetLaborMarketInformationRequestHandler> _localizer;

    public GetLaborMarketInformationRequestHandler(IRepository<LaborMarketInformation> repository, IStringLocalizer<GetLaborMarketInformationRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<LaborMarketInformationDetailsDto>> Handle(GetLaborMarketInformationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<LaborMarketInformation, LaborMarketInformationDetailsDto>)new LaborMarketInformationByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["LaborMarketInformation.notfound"], request.Id));
        return Result<LaborMarketInformationDetailsDto>.Success(item);

    }
}