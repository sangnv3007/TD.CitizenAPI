namespace TD.CitizenAPI.Application.Catalog.Companies;

public class ValidateCompanyRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    

    public int? Status { get; set; }

    public virtual ICollection<Guid>? Industries { get; set; }
}

public class ValidateCompanyRequestValidator : CustomValidator<ValidateCompanyRequest>
{
    public ValidateCompanyRequestValidator(IRepository<Company> repository, IStringLocalizer<ValidateCompanyRequestValidator> localizer) =>
        RuleFor(p => p.Status)
            .NotEmpty();
}

public class ValidateCompanyRequestHandler : IRequestHandler<ValidateCompanyRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Company> _repository;
    private readonly IRepositoryWithEvents<CompanyIndustry> _companyIndustryRepository;

    private readonly IStringLocalizer<UpdateCompanyRequestHandler> _localizer;

    public ValidateCompanyRequestHandler(IRepositoryWithEvents<Company> repository, IRepositoryWithEvents<CompanyIndustry> companyIndustryRepository, IStringLocalizer<UpdateCompanyRequestHandler> localizer) =>
        (_repository, _companyIndustryRepository, _localizer) = (repository, companyIndustryRepository, localizer);

    public async Task<Result<Guid>> Handle(ValidateCompanyRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["company.notfound"], request.Id));

        item.Update(request.Status);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}