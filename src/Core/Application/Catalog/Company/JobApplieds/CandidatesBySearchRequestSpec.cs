namespace TD.CitizenAPI.Application.Catalog.JobApplieds;

public class CandidatesBySearchRequestSpec : EntitiesByPaginationFilterSpec<JobApplied, JobAppliedDto>
{
    public CandidatesBySearchRequestSpec(SearchCandidatesRequest request)
        : base(request) =>
        Query
        .Include(p => p.Recruitment)
        .Include(p => p.Recruitment).ThenInclude(p => p.Company)
        .Include(p => p.JobApplication)
        .Where(p => p.RecruitmentId == request.RecruitmentId, request.RecruitmentId.HasValue)
        .Where(p => p.Recruitment.CompanyId.Equals(request.CompanyId!.Value), request.CompanyId.HasValue)
        .Where(p => p.JobApplication.CurrentPositionId.Equals(request.CurrentPositionId!.Value), request.CurrentPositionId.HasValue)
        .Where(p => p.JobApplication.PositionId.Equals(request.PositionId!.Value), request.PositionId.HasValue)
        .Where(p => p.JobApplication.JobNameId.Equals(request.JobNameId!.Value), request.JobNameId.HasValue)
        .Where(p => p.JobApplication.DegreeId.Equals(request.DegreeId!.Value), request.DegreeId.HasValue)
        .Where(p => p.JobApplication.ExperienceId.Equals(request.ExperienceId!.Value), request.ExperienceId.HasValue)
        .Where(p => p.JobApplication.JobTypeId.Equals(request.JobTypeId!.Value), request.JobTypeId.HasValue)
        ;
}