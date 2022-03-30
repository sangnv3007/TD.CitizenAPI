namespace TD.CitizenAPI.Application.Catalog.JobApplications;

public class UpdateJobApplicationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
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



public class UpdateJobApplicationRequestHandler : IRequestHandler<UpdateJobApplicationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<JobApplication> _repository;
    private readonly IStringLocalizer<UpdateJobApplicationRequestHandler> _localizer;

    public UpdateJobApplicationRequestHandler(IRepositoryWithEvents<JobApplication> repository, IStringLocalizer<UpdateJobApplicationRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateJobApplicationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["JobApplication.notfound"], request.Id));

        item.Update(request.UserName, request.Name, request.CVFile, request.Image, request.CurrentPositionId, request.PositionId, request.JobNameId, request.DegreeId, request.ExperienceId, request.MinExpectedSalary, request.Address, request.JobTypeId, request.IsSearchAllowed);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}