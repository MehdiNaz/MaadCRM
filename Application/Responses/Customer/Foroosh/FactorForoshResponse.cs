namespace Application.Responses.Customer.Foroosh;

public struct FactorInformationResponse
{
    public Ulid IdFactorForoosh { get; set; }
    public string CustomerFullName { get; set; }
    public string CustomerAddress { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountTax { get; set; }
    public decimal AmountTotal { get; set; }
    public StatusType StatusTypeForooshFactor { get; set; }
    public DateTime DatePayed { get; set; }
    public PaymentMethodTypes PaymentMethod { get; set; }
    public ShippingMethodTypes ShippingMethodType { get; set; }

    // در صورت غیر نقدی : 
    public uint? TedadeAghsat { get; set; }
    public uint? BazeyeZamany { get; set; }
    public decimal? DarSadeSoud { get; set; }
    public decimal? PishPardakht { get; set; }
    public decimal? MablagheKoleSoud { get; set; }
    public DateTime? ShoroAghsat { get; set; }

    public decimal Price { get; set; }
    public decimal PriceTotal { get; set; }
    public uint Tedad { get; set; }
    public decimal PriceDiscount { get; set; }
    public decimal PriceShipping { get; set; }
    public decimal PaymentAmount { get; set; }
    public StatusType PaymentStatusType { get; set; }
    public Ulid IdProduct { get; set; }
    public  Ulid IdCustomer { get; set; }
    public  Ulid? IdCustomerAddress { get; set; }
}