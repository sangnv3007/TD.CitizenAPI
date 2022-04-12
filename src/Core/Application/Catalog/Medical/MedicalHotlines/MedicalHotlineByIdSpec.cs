namespace TD.CitizenAPI.Application.Catalog.MedicalHotlines;

public class MedicalHotlineByIdSpec : Specification<MedicalHotline, MedicalHotlineDetailsDto>, ISingleResultSpecification
{
    public MedicalHotlineByIdSpec(Guid id) =>
        Query
            .Where(p => p.Id == id)
         ;
}