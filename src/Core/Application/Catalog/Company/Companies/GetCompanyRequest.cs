namespace TD.CitizenAPI.Application.Catalog.Companies;

public class GetCompanyRequest : IRequest<Result<CompanyDetailsDto>>
{
    public Guid Id { get; set; }

    public GetCompanyRequest(Guid id) => Id = id;
}

public class CompanyByIdSpec : Specification<Company, CompanyDetailsDto>, ISingleResultSpecification
{
    public CompanyByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id).Include(p => p.Province).Include(p => p.District).Include(p => p.Commune).Include(p => p.CompanyIndustries).ThenInclude(p => p.Industry);
}

public class GetCompanyRequestHandler : IRequestHandler<GetCompanyRequest, Result<CompanyDetailsDto>>
{
    private readonly IRepository<Company> _repository;
    private readonly IStringLocalizer<GetCompanyRequestHandler> _localizer;

    public GetCompanyRequestHandler(IRepository<Company> repository, IStringLocalizer<GetCompanyRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<CompanyDetailsDto>> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Company, CompanyDetailsDto>)new CompanyByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Company.notfound"], request.Id));
        return Result<CompanyDetailsDto>.Success(item);

    }
}