namespace TD.CitizenAPI.Application.Catalog.Recruitments;

public class RecruitmentBenefitByRecruitmentSpec : Specification<RecruitmentBenefit>, ISingleResultSpecification
{
    public RecruitmentBenefitByRecruitmentSpec(Guid recruitmentId) =>
        Query.Where(p => p.RecruitmentId == recruitmentId);

}