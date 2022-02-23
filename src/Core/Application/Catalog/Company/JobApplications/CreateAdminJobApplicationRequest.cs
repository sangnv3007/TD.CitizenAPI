namespace TD.CitizenAPI.Application.Catalog.JobApplications;

public class CreateAdminJobApplicationRequest : IRequest<Result<Guid>>
{
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? CVFile { get; set; }
    public string? Image { get; set; }
    //Vi tri hien tai
    public Guid? CurrentPositionId { get; set; }
    //Vi tri mong muon
    public Guid? PositionId { get; set; }
    public Guid? JobNameId { get; set; }

    //Trinh do hoc van
    public Guid? DegreeId { get; set; }
    //Tong so nam Kinh nghiem
    public Guid? ExperienceId { get; set; }

    //Mong muon muc luong toi thieu
    public int? MinExpectedSalary { get; set; }
    //Dia diem lam viec
    public string? Address { get; set; }
    //Hinh thuc lam viec
    public Guid? JobTypeId { get; set; }
    //Cho phep nguoi khac tim kiem thong tin
    public int? IsSearchAllowed { get; set; }
}

public class CreateAdminJobApplicationRequestValidator : CustomValidator<CreateJobApplicationRequest>
{
    public CreateAdminJobApplicationRequestValidator(IReadRepository<JobApplication> repository, IStringLocalizer<CreateAdminJobApplicationRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateAdminJobApplicationRequestHandler : IRequestHandler<CreateAdminJobApplicationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobApplication> _repository;

    public CreateAdminJobApplicationRequestHandler(IRepositoryWithEvents<JobApplication> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateAdminJobApplicationRequest request, CancellationToken cancellationToken)
    {
        var item = new JobApplication(request.UserName, request.Name, request.CVFile, request.Image, request.CurrentPositionId, request.PositionId, request.JobTypeId, request.DegreeId, request.ExperienceId, request.MinExpectedSalary, request.Address, request.JobTypeId, request.IsSearchAllowed);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}