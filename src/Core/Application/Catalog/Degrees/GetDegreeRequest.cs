namespace TD.CitizenAPI.Application.Catalog.Degrees;

public class GetDegreeRequest : IRequest<Result<DegreeDetailsDto>>
{
    public Guid Id { get; set; }

    public GetDegreeRequest(Guid id) => Id = id;
}

public class DegreeByIdSpec : Specification<Degree, DegreeDetailsDto>, ISingleResultSpecification
{
    public DegreeByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetDegreeRequestHandler : IRequestHandler<GetDegreeRequest, Result<DegreeDetailsDto>>
{
    private readonly IRepository<Degree> _repository;
    private readonly IStringLocalizer<GetDegreeRequestHandler> _localizer;

    public GetDegreeRequestHandler(IRepository<Degree> repository, IStringLocalizer<GetDegreeRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<DegreeDetailsDto>> Handle(GetDegreeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Degree, DegreeDetailsDto>)new DegreeByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["degree.notfound"], request.Id));
        return Result<DegreeDetailsDto>.Success(item);

    }
}