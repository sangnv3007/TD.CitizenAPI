using System.Globalization;
using System.Linq;

namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class RecruitmentsBySearchRequestSpec : EntitiesByPaginationFilterSpec<Recruitment, RecruitmentDto>
{
    public RecruitmentsBySearchRequestSpec(SearchRecruitmentsRequest request)
        : base(request)
        {
        DateTime? resumeApplyExpiredFrom = null;
        if (!string.IsNullOrWhiteSpace(request.ResumeApplyExpiredFrom))
        {
            try
            {
                resumeApplyExpiredFrom = DateTime.ParseExact(request.ResumeApplyExpiredFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {

            }
        }

        DateTime? resumeApplyExpiredTo = null;
        if (!string.IsNullOrWhiteSpace(request.ResumeApplyExpiredTo))
        {
            try
            {
                resumeApplyExpiredTo = DateTime.ParseExact(request.ResumeApplyExpiredTo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {

            }
        }

        Query
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
        .Where(p => p.UserName == request.UserName, !string.IsNullOrWhiteSpace(request.UserName))
        .Where(p => p.Gender == request.Gender, !string.IsNullOrWhiteSpace(request.Gender))
        .Where(p => p.CompanyId.Equals(request.CompanyId!.Value), request.CompanyId.HasValue)
        .Where(p => p.JobTypeId.Equals(request.JobTypeId!.Value), request.JobTypeId.HasValue)
        .Where(p => p.JobNameId.Equals(request.JobNameId!.Value), request.JobNameId.HasValue)
        .Where(p => p.DegreeId.Equals(request.DegreeId!.Value), request.DegreeId.HasValue)
        .Where(p => p.ExperienceId.Equals(request.ExperienceId!.Value), request.ExperienceId.HasValue)
        .Where(p => p.JobTypeId.Equals(request.JobTypeId!.Value), request.JobTypeId.HasValue)
        .Where(p => p.JobPositionId.Equals(request.JobPositionId!.Value), request.JobPositionId.HasValue)
        .Where(p => p.SalaryId.Equals(request.SalaryId!.Value), request.SalaryId.HasValue)
        .Where(p => p.JobAgeId.Equals(request.JobAgeId!.Value), request.JobAgeId.HasValue)
        .Where(p => p.ProvinceId.Equals(request.ProvinceId!.Value), request.ProvinceId.HasValue)
        .Where(p => p.DistrictId.Equals(request.DistrictId!.Value), request.DistrictId.HasValue)
        .Where(p => p.CommuneId.Equals(request.CommuneId!.Value), request.CommuneId.HasValue)
        .Where(p => p.ResumeApplyExpired >= resumeApplyExpiredFrom, resumeApplyExpiredFrom.HasValue)
        .Where(p => p.ResumeApplyExpired <= resumeApplyExpiredTo, resumeApplyExpiredTo.HasValue)
        ;
    }
}