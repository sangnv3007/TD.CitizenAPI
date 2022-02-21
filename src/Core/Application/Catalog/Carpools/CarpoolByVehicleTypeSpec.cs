namespace TD.CitizenAPI.Application.Catalog.Carpools;

public class CarpoolByVehicleTypeSpec : Specification<Carpool>
{
    public CarpoolByVehicleTypeSpec(Guid vehicleTypeId) =>
        Query.Where(p => p.VehicleTypeId == vehicleTypeId);
}
