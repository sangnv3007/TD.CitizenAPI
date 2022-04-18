namespace TD.CitizenAPI.Application.Catalog.Drugs;

public class GetDrugRequest : IRequest<Result<DrugDetailsDto>>
{
    public Guid Id { get; set; }

    public GetDrugRequest(Guid id) => Id = id;
}

public class DrugByIdSpec : Specification<Drug, DrugDetailsDto>, ISingleResultSpecification
{
    public DrugByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetDrugRequestHandler : IRequestHandler<GetDrugRequest, Result<DrugDetailsDto>>
{
    private readonly IRepository<Drug> _repository;
    private readonly IStringLocalizer<GetDrugRequestHandler> _localizer;

    public GetDrugRequestHandler(IRepository<Drug> repository, IStringLocalizer<GetDrugRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<DrugDetailsDto>> Handle(GetDrugRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Drug, DrugDetailsDto>)new DrugByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Drug.notfound"], request.Id));
        return Result<DrugDetailsDto>.Success(item);

    }
}