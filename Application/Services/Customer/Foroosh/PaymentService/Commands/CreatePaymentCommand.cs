﻿namespace Application.Services.Customer.Foroosh.PaymentService.Commands;

public struct CreatePaymentCommand : IRequest<Result<ForooshPayment>>
{
    public DateTime DatePay { get; set; }
    public decimal PaymentAmount { get; set; }
    public required Ulid IdForooshFactor { get; set; }
}