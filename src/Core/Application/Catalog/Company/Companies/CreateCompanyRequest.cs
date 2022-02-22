namespace TD.CitizenAPI.Application.Catalog.Companies;

public class CreateCompanyRequest : IRequest<Result<Guid>>
{
    public string? UserName { get; set; }
    public string Name { get; set; } = default!;
    public string? InternationalName { get; set; }
    public string? ShortName { get; set; }
    public string? TaxCode { get; set; }
    //Dia chi cong ty
    public string? Address { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public Guid? ProvinceId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? CommuneId { get; set; }
    //Dai dien
    public string? Representative { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? ProfileVideo { get; set; }
    public string? Fax { get; set; }
    //Ngay cap
    public DateTime? DateOfIssue { get; set; }
    //Linh vuc kinh doanh
    public string? BusinessSector { get; set; }
    public string? Images { get; set; }
    public string? Image { get; set; }
    public string? Logo { get; set; }
    public string? Description { get; set; }
    //Quy mo cong ty
    public string? CompanySize { get; set; }

    public virtual ICollection<Guid>? Industries { get; set; }

}

public class CreateCompanyRequestValidator : CustomValidator<CreateCompanyRequest>
{
    public CreateCompanyRequestValidator(IReadRepository<Company> repository, IStringLocalizer<CreateCompanyRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateCompanyRequestHandler : IRequestHandler<CreateCompanyRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Company> _repository;
    private readonly IRepositoryWithEvents<CompanyIndustry> _companyIndustryRepository;

    public CreateCompanyRequestHandler(IRepositoryWithEvents<Company> repository, IRepositoryWithEvents<CompanyIndustry> companyIndustryRepository) => (_repository, _companyIndustryRepository) = (repository, companyIndustryRepository);

    public async Task<Result<Guid>> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var item = new Company(request.UserName, request.Name, request.InternationalName, request.ShortName, request.TaxCode, request.Address, request.Latitude, request.Longitude, request.ProvinceId, request.DistrictId, request.CommuneId, request.Representative, request.PhoneNumber, request.Website, request.Email, request.ProfileVideo, request.Fax, request.DateOfIssue, request.BusinessSector, request.Images, request.Image, request.Logo, request.Description, request.CompanySize);
        await _repository.AddAsync(item, cancellationToken);


        if (request.Industries != null)
        {
            foreach (var industryId in request.Industries)
            {
                try
                {
                    var companyIndustry = new CompanyIndustry(item.Id, industryId);
                    await _companyIndustryRepository.AddAsync(companyIndustry, cancellationToken);
                }
                catch
                {

                }
            }
        }


        return Result<Guid>.Success(item.Id);
    }
}