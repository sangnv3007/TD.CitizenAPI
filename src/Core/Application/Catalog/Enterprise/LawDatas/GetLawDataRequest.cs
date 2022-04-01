namespace TD.CitizenAPI.Application.Catalog.LawDatas;

public class GetLawDataRequest : IRequest<Result<LawDataDetailsDto>>
{
    public Guid Id { get; set; }

    public GetLawDataRequest(Guid id) => Id = id;
}

public class LawDataByIdSpec : Specification<LawData, LawDataDetailsDto>, ISingleResultSpecification
{
    public LawDataByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetLawDataRequestHandler : IRequestHandler<GetLawDataRequest, Result<LawDataDetailsDto>>
{
    private readonly IRepository<LawData> _repository;
    private readonly IStringLocalizer<GetLawDataRequestHandler> _localizer;

    public GetLawDataRequestHandler(IRepository<LawData> repository, IStringLocalizer<GetLawDataRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<LawDataDetailsDto>> Handle(GetLawDataRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<LawData, LawDataDetailsDto>)new LawDataByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["LawData.notfound"], request.Id));
        return Result<LawDataDetailsDto>.Success(item);

    }
}