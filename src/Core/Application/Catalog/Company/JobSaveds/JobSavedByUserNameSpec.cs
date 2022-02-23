namespace TD.CitizenAPI.Application.Catalog.JobSaveds;

public class JobSavedByUserNameSpec : Specification<JobSaved, JobSavedDto>, ISingleResultSpecification
{
    public JobSavedByUserNameSpec(string? userName) =>
        Query
            .Where(p => p.UserName == userName)
            .Include(p => p.Recruitment);
}