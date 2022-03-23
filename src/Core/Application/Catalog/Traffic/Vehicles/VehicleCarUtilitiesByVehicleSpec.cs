namespace TD.CitizenAPI.Application.Catalog.Vehicles;

public class VehicleCarUtilitiesByVehicleSpec : Specification<VehicleCarUtility>, ISingleResultSpecification
{
    public VehicleCarUtilitiesByVehicleSpec(Guid id) =>
        Query.Where(p => p.VehicleId == id);

}