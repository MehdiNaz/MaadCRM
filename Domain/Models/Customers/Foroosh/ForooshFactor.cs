namespace Domain.Models.Customers.Foroosh;

public sealed class ForooshFactor : BaseEntityWithUserUpdate
{
    public ForooshFactor()
    {
        Id = Ulid.NewUlid();
        StatusTypeForooshFactor = StatusType.Show;
        ForooshOrders = new HashSet<ForooshOrder>();
        Logs = new HashSet<Log>();
    }

    public Ulid Id { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountTax { get; set; }
    public decimal AmountTotal { get; set; }
    public StatusType StatusTypeForooshFactor { get; set; }
    public DateTime DatePayed { get; set; }
    public PaymentMethodTypes PaymentMethod { get; set; }
    public ShippingMethodTypes? ShippingMethodType { get; set; }

    // در صورت غیر نقدی : 
    public uint? TedadeAghsat { get; set; }
    public uint? BazeyeZamany { get; set; }
    public decimal? DarSadeSoud { get; set; }
    public decimal? PishPardakht { get; set; }
    public decimal? MablagheKoleSoud { get; set; }
    public DateTime? ShoroAghsat { get; set; }

    public required Ulid IdCustomer { get; set; }
    public Customer IdCustomerNavigation { get; set; }

    public required Ulid? IdCustomerAddress { get; set; }
    public CustomerAddress? IdCustomerAddressNavigation { get; set; }

    public ICollection<ForooshOrder>? ForooshOrders { get; set; }
    public ICollection<Payment>? Payments { get; set; }
    public ICollection<Log>? Logs { get; set; }
}