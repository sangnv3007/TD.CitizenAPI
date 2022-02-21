namespace TD.CitizenAPI.Domain.Catalog;

public class Carpool : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string? Description { get; set; }
    //Diem khoi hanh
    public Guid? PlaceDepartureId { get; set; }
    public virtual Place? PlaceDeparture { get; set; }
    //Diem den
    public Guid? PlaceArrivalId { get; set; }
    public virtual Place? PlaceArrival { get; set; }

    public DateTime? DepartureDate { get; set; }
    public TimeSpan? DepartureTime { get; set; }
    public string DepartureTimeText { get; set; }
    //Loai phuong tien
    public Guid? VehicleTypeId { get; set; }
    public virtual VehicleType? VehicleType { get; set; }
    //Vai tro
    public string Role { get; set; }
    //Gia
    public decimal Price { get; set; }
    //So ghe
    public int SeatCount { get; set; }
    //Trang thai
    public int Status { get; set; }

    public Carpool(string name, string? phoneNumber, string userName, string? description, Guid? placeDepartureId, Guid? placeArrivalId, DateTime? departureDate, TimeSpan? departureTime, string departureTimeText, Guid? vehicleTypeId, string role, decimal price, int seatCount, int status)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        UserName = userName;
        Description = description;
        PlaceDepartureId = placeDepartureId;
        PlaceArrivalId = placeArrivalId;
        DepartureDate = departureDate;
        DepartureTime = departureTime;
        DepartureTimeText = departureTimeText;
        VehicleTypeId = vehicleTypeId;
        Role = role;
        Price = price;
        SeatCount = seatCount;
        Status = status;
    }

    public Carpool Update(string? name, string? phoneNumber, string? userName, string? description, Guid? placeDepartureId, Guid? placeArrivalId, DateTime? departureDate, TimeSpan? departureTime, string? departureTimeText, Guid? vehicleTypeId, string? role, decimal? price, int? seatCount, int? status)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (phoneNumber is not null && PhoneNumber?.Equals(phoneNumber) is not true) PhoneNumber = phoneNumber;
        if (userName is not null && UserName?.Equals(userName) is not true) UserName = userName;
        if (role is not null && Role?.Equals(role) is not true) Role = role;
        if (departureTimeText is not null && DepartureTimeText?.Equals(departureTimeText) is not true) DepartureTimeText = departureTimeText;
        if (description is not null && Description?.Equals(description) is not true) Description = description;

        if (placeDepartureId.HasValue && placeDepartureId.Value != Guid.Empty && !PlaceDepartureId.Equals(placeDepartureId.Value)) PlaceDepartureId = placeDepartureId.Value;
        if (placeArrivalId.HasValue && placeArrivalId.Value != Guid.Empty && !PlaceArrivalId.Equals(placeArrivalId.Value)) PlaceArrivalId = placeArrivalId.Value;
        if (vehicleTypeId.HasValue && vehicleTypeId.Value != Guid.Empty && !VehicleTypeId.Equals(vehicleTypeId.Value)) VehicleTypeId = vehicleTypeId.Value;

        if (departureDate.HasValue && !DepartureDate.Equals(departureDate.Value)) DepartureDate = departureDate.Value;
        if (departureTime.HasValue && !DepartureTime.Equals(departureTime.Value)) DepartureTime = departureTime.Value;
        if (seatCount.HasValue && !SeatCount.Equals(seatCount.Value)) SeatCount = seatCount.Value;
        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;
        if (price.HasValue && !Price.Equals(price.Value)) Price = price.Value;

        return this;
    }

    public Carpool Update( int? status)
    {
  
        if (status.HasValue && !Status.Equals(status.Value)) Status = status.Value;

        return this;
    }
}