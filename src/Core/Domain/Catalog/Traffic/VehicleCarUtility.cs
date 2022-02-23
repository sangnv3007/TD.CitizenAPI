namespace TD.CitizenAPI.Domain.Catalog;

public class VehicleCarUtility : AuditableEntity, IAggregateRoot
{
    public Guid? VehicleId { get; set; }
    public Guid? CarUtilityId { get; set; }
    public virtual Vehicle? Vehicle { get; set; }
    public virtual CarUtility? CarUtility { get; set; }

    public VehicleCarUtility(Guid? vehicleId, Guid? carUtilityId)
    {
        VehicleId = vehicleId;
        CarUtilityId = carUtilityId;
    }

    public VehicleCarUtility Update(Guid? vehicleId, Guid? carUtilityId)
    {
        if (vehicleId.HasValue && vehicleId.Value != Guid.Empty && !VehicleId.Equals(vehicleId.Value)) VehicleId = vehicleId.Value;
        if (carUtilityId.HasValue && carUtilityId.Value != Guid.Empty && !CarUtilityId.Equals(carUtilityId.Value)) CarUtilityId = carUtilityId.Value;

        return this;
    }
}