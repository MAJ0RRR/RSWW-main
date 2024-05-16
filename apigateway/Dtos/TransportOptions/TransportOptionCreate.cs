﻿using System.ComponentModel.DataAnnotations;

namespace apigateway.Dtos.TransportOptions;

public class TransportOptionCreate
{
    [Required]
    public TypeOfTransport Type { get; set; }
    
    [Required]
    public DateTime Start { get; set; }
    
    [Required]
    public DateTime End { get; set; }
    
    [Required]
    public int SeatsAvailable { get; set; }
    
    [Required]
    public string FromCountry { get; set; }
    
    [Required]
    public string FromCity { get; set; }
    
    [Required]
    public string FromStreet { get; set; }
    
    [Required]
    public string FromShowName { get; set; }
    
    [Required]
    public string ToCountry { get; set; }
    
    [Required]
    public string ToCity { get; set; }
    
    [Required]
    public string ToStreet { get; set; }
    
    [Required]
    public string ToShowName { get; set; }
    
    [Required]
    public decimal PriceAdult { get; set; }
    
    [Required]
    public decimal PriceUnder3 { get; set; }
    
    [Required]
    public decimal PriceUnder10 { get; set; }
    
    [Required]
    public decimal PriceUnder18 { get; set; }
}