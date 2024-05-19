namespace contracts.Dtos;
public class RoomsCount
{
    public decimal Price { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
}
public class HotelDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<RoomsCount> Rooms { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public decimal FoodPricePerPerson { get; set; }
}