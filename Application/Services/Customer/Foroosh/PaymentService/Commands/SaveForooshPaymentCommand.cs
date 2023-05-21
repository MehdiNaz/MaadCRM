using Application.Responses.Customer.Foroosh;

namespace Application.Services.Customer.Foroosh.PaymentService.Commands;

public struct SaveForooshPaymentCommand : IRequest<Result<SaveForooshPaymentResponse>>
{
    public Ulid IdFactor { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountTax { get; set; }
    public decimal AmountDiscount { get; set; }
    public decimal AmountTotal { get; set; }
    public PaymentMethodTypes PaymentMethod { get; set; }
    public ShippingMethodTypes? ShippingMethodType { get; set; }

    // در صورت غیر نقدی : 
    public uint? TedadeAghsat { get; set; }
    public uint? BazeyeZamany { get; set; }
    public decimal? DarSadeSoud { get; set; }
    public decimal? PishPardakht { get; set; }
    public decimal? MablagheKoleSoud { get; set; }
    public DateTime? ShoroAghsat { get; set; }

    //آیتم های پرداخت :
    public decimal PaymentAmount { get; set; }
    public DateTime DatePay { get; set; }

    public Ulid IdCustomer { get; set; }

    public string IdUserAdded { get; set; }
    public string IdUserUpdated { get; set; }
}