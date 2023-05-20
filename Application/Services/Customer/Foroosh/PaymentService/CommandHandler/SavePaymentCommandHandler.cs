namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct SavePaymentCommandHandler : IRequestHandler<SavePaymentCommand, Result<SavePaymentResponse>>
{
    private readonly IPaymentRepository _repository;

    public SavePaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<SavePaymentResponse>> Handle(SavePaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var item = new SavePaymentCommand()
            {
                IdFactor = request.IdFactor,
                Amount = request.Amount,
                AmountTax = request.AmountTax,
                AmountTotal = request.AmountTotal,
                PaymentMethod = request.PaymentMethod,
                ShippingMethodType = request.ShippingMethodType,
                TedadeAghsat = request.TedadeAghsat,
                BazeyeZamany = request.BazeyeZamany,
                DarSadeSoud = request.DarSadeSoud,
                PishPardakht = request.PishPardakht,
                MablagheKoleSoud = request.MablagheKoleSoud,
                ShoroAghsat = request.ShoroAghsat,
                PaymentAmount = request.PaymentAmount,
                DatePay = request.DatePay,
                CustomerId = request.CustomerId,
                CustomersAddressId = request.CustomersAddressId,
                UserIdAdded = request.UserIdAdded,
                UserIdUpdated = request.UserIdUpdated
            };
            return (await _repository.SavePaymentsAsync(item))
                .Match(result => new Result<SavePaymentResponse>(result),
                    exception => new Result<SavePaymentResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<SavePaymentResponse>(new Exception(e.Message));
        }
    }
}
