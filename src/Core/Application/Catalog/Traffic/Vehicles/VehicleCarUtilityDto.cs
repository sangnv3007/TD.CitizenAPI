
namespace TD.CitizenAPI.Application.Catalog.Vehicles;

public class VehicleCarUtilityDto : IDto
{
    public Guid Id { get; set; }
    public Guid? CarUtilityId { get; set; }
    public virtual CarUtility? CarUtility { get; set; }


}