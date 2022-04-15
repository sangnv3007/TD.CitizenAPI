namespace TD.CitizenAPI.Application.Catalog.Diseases;

public class GetTravelHandbookRequest : IRequest<Result<DiseaseDetailsDto>>
{
    public Guid Id { get; set; }

    public GetTravelHandbookRequest(Guid id) => Id = id;
}

public class DiseaseByIdSpec : Specification<Disease, DiseaseDetailsDto>, ISingleResultSpecification
{
    public DiseaseByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetDiseaseRequestHandler : IRequestHandler<GetTravelHandbookRequest, Result<DiseaseDetailsDto>>
{
    private readonly IRepository<Disease> _repository;
    private readonly IStringLocalizer<GetDiseaseRequestHandler> _localizer;

    public GetDiseaseRequestHandler(IRepository<Disease> repository, IStringLocalizer<GetDiseaseRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<DiseaseDetailsDto>> Handle(GetTravelHandbookRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Disease, DiseaseDetailsDto>)new DiseaseByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Disease.notfound"], request.Id));
        return Result<DiseaseDetailsDto>.Success(item);

    }
}