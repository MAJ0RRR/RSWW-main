namespace contracts.Dtos;

public class TransportOptionDto
{
    public Guid Id { get; set; }
    public int SeatsAvailable { get; set; }
    public string FromCountry { get; set; }
    public string FromCity { get; set; }
    public string FromStreet { get; set; }
    public string FromShowName { get; set; }
    public string ToCountry { get; set; }
    public string ToCity { get; set; }
    public string ToStreet { get; set; }
    public string ToShowName { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public decimal PriceAdult { get; set; }
    public decimal PriceUnder3 { get; set; }
    public decimal PriceUnder10 { get; set; }
    public decimal PriceUnder18 { get; set; }
    public string Type { get; set; } // "Airplane", "Train", "Bus"
}