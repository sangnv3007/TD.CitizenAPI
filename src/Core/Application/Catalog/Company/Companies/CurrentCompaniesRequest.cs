namespace TD.CitizenAPI.Application.Catalog.Companies;

public class CurrentCompaniesRequest : IRequest<Result<CompanyDetailsDto>>
{
    public CurrentCompaniesRequest()
    {
    }
}

public class CompanyByUserNameSpec : Specification<Company, CompanyDetailsDto>, ISingleResultSpecification
{
    public CompanyByUserNameSpec(string userName) =>
        Query.Where(p => p.UserName == userName).Include(p => p.Province).Include(p => p.District).Include(p => p.Commune).Include(p => p.CompanyIndustries).ThenInclude(p => p.Industry);
}

public class GetCurrentCompanyRequestHandler : IRequestHandler<CurrentCompaniesRequest, Result<CompanyDetailsDto>>
{
    private readonly IRepository<Company> _repository;
    private readonly IStringLocalizer<GetCurrentCompanyRequestHandler> _localizer;
    private readonly ICurrentUser _currentUser;

    public GetCurrentCompanyRequestHandler(IRepository<Company> repository, ICurrentUser currentUser, IStringLocalizer<GetCurrentCompanyRequestHandler> localizer) => (_repository, _currentUser, _localizer) = (repository, currentUser, localizer);

    public async Task<Result<CompanyDetailsDto>> Handle(CurrentCompaniesRequest request, CancellationToken cancellationToken)
    {
        string? userName = _currentUser.GetUserName();

        var item = await _repository.GetBySpecAsync(
            (ISpecification<Company, CompanyDetailsDto>)new CompanyByUserNameSpec(userName), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Company.notfound"], userName));
        return Result<CompanyDetailsDto>.Success(item);

    }
}