namespace TD.CitizenAPI.Application.Catalog.JobSaveds;

public class JobSavedByUserNameRecruitmentIdSpec : Specification<JobSaved>, ISingleResultSpecification
{
    public JobSavedByUserNameRecruitmentIdSpec(string? userName, Guid recruitmentId) =>
        Query
            .Where(p => p.UserName == userName && p.RecruitmentId == recruitmentId);
           
}