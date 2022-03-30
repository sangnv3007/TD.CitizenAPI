namespace TD.CitizenAPI.Application.Catalog.JobApplications;

public class JobApplicationsBySearchRequestSpec : EntitiesByPaginationFilterSpec<JobApplication, JobApplicationDto>
{
    public JobApplicationsBySearchRequestSpec(SearchJobApplicationsRequest request)
        : base(request) =>
        Query
         .Include(p => p.CurrentPosition)
        .Include(p => p.JobName)
        .Include(p => p.Position)
        .Include(p => p.Experience)
        .Include(p => p.Degree)
        .Include(p => p.JobType)
        .Where(p => p.UserName == request.UserName, !string.IsNullOrWhiteSpace(request.UserName))
        .Where(p => p.CurrentPositionId.Equals(request.CurrentPositionId!.Value), request.CurrentPositionId.HasValue)
        .Where(p => p.PositionId.Equals(request.PositionId!.Value), request.PositionId.HasValue)
        .Where(p => p.JobNameId.Equals(request.JobNameId!.Value), request.JobNameId.HasValue)
        .Where(p => p.DegreeId.Equals(request.DegreeId!.Value), request.DegreeId.HasValue)
        .Where(p => p.ExperienceId.Equals(request.ExperienceId!.Value), request.ExperienceId.HasValue)
        .Where(p => p.JobTypeId.Equals(request.JobTypeId!.Value), request.JobTypeId.HasValue)
        .Where(p => p.MinExpectedSalary >= request.MinExpectedSalaryFrom!.Value, request.MinExpectedSalaryFrom.HasValue)
        .Where(p => p.MinExpectedSalary <= request.MinExpectedSalaryTo!.Value, request.MinExpectedSalaryTo.HasValue);
}