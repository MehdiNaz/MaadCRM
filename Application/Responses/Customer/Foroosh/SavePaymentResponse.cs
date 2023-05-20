namespace Application.Responses;

public struct SaveForooshPaymentResponse
{
    public Ulid IdFactor { get; set; }
    public Ulid IdCustomer { get; set; }
    public string CustomerFullName { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountTax { get; set; }
    public decimal AmountTotal { get; set; }
    public StatusType StatusTypeForooshFactor { get; set; }
    public DateTime DatePayed { get; set; }
    public PaymentMethodTypes PaymentMethod { get; set; }
    // public ShippingMethodTypes ShippingMethodType { get; set; }

    // در صورت غیر نقدی : 
    public uint? TedadeAghsat { get; set; }
    public uint? BazeyeZamany { get; set; }
    public decimal? DarSadeSoud { get; set; }
    public decimal? PishPardakht { get; set; }
    public decimal? MablagheKoleSoud { get; set; }
    public DateTime? ShoroAghsat { get; set; }

    public ICollection<ForooshOrderResponse>? Orders { get; set; }
    public ICollection<ForooshPaymentResponse>? Payments { get; set; }
}