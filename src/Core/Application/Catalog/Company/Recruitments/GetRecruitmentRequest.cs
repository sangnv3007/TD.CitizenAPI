namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class GetRecruitmentRequest : IRequest<Result<RecruitmentDetailsDto>>
{
    public Guid Id { get; set; }

    public GetRecruitmentRequest(Guid id) => Id = id;
}

public class RecruitmentByIdSpec : Specification<Recruitment, RecruitmentDetailsDto>, ISingleResultSpecification
{
    public RecruitmentByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.Company)
        .Include(p => p.JobPosition)
        .Include(p => p.JobType)
        .Include(p => p.JobName)
        .Include(p => p.JobAge)
        .Include(p => p.Degree)
        .Include(p => p.Salary)
        .Include(p => p.Experience)
        .Include(p => p.Province)
        .Include(p => p.District)
        .Include(p => p.Commune)
        .Include(p => p.RecruitmentBenefits)
        ;
}

public class GetRecruitmentRequestHandler : IRequestHandler<GetRecruitmentRequest, Result<RecruitmentDetailsDto>>
{
    private readonly IRepository<Recruitment> _repository;
    private readonly IStringLocalizer<GetRecruitmentRequestHandler> _localizer;

    public GetRecruitmentRequestHandler(IRepository<Recruitment> repository, IStringLocalizer<GetRecruitmentRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<RecruitmentDetailsDto>> Handle(GetRecruitmentRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<Recruitment, RecruitmentDetailsDto>)new RecruitmentByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["Recruitment.notfound"], request.Id));
        return Result<RecruitmentDetailsDto>.Success(item);

    }
}