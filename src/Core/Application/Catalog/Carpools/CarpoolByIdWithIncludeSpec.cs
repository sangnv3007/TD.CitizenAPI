namespace TD.CitizenAPI.Application.Catalog.Carpools;

public class CarpoolByIdWithIncludeSpec : Specification<Carpool, CarpoolDetailsDto>, ISingleResultSpecification
{
    public CarpoolByIdWithIncludeSpec(Guid id) =>
        Query
            .Where(p => p.Id == id)
            .Include(p => p.VehicleType)
        .Include(p => p.DepartureProvince)
        .Include(p => p.DepartureDistrict)
        .Include(p => p.DepartureCommune)
        .Include(p => p.ArrivalProvince)
        .Include(p => p.ArrivalCommune)
        .Include(p => p.ArrivalDistrict);
}