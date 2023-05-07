﻿namespace Application.Services.ForoshFactorService.Commands;

public struct CreateForoshFactorCommand : IRequest<Result<ForooshFactor>>
{
    public decimal Amount { get; set; }
    public decimal AmountTax { get; set; }
    public decimal AmountTotal { get; set; }
    public PaymentMethodTypes PaymentMethod { get; set; }
    public ShippingMethodTypes ShippingMethodType { get; set; }

    // در صورت غیر نقدی : 
    public uint TedadeAghsat { get; set; }
    public uint BazeyeZamany { get; set; }
    public decimal DarSadeSoud { get; set; }
    public decimal PishPardakht { get; set; }
    public decimal MablagheKoleSoud { get; set; }
    public DateTime ShoroAghsat { get; set; }

    public Ulid CustomerId { get; set; }
    public Ulid CustomersAddressId { get; set; }
}