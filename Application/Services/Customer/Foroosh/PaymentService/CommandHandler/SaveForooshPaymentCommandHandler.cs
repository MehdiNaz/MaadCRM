namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct SaveForooshPaymentCommandHandler : IRequestHandler<SaveForooshPaymentCommand, Result<SaveForooshPaymentResponse>>
{
    private readonly IPaymentRepository _repository;

    public SaveForooshPaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<SaveForooshPaymentResponse>> Handle(SaveForooshPaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var item = new SaveForooshPaymentCommand()
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
                // CustomersAddressId = request.CustomersAddressId,
                UserIdAdded = request.UserIdAdded,
                UserIdUpdated = request.UserIdUpdated
            };
            return (await _repository.SavePaymentsAsync(item))
                .Match(result => new Result<SaveForooshPaymentResponse>(result),
                    exception => new Result<SaveForooshPaymentResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<SaveForooshPaymentResponse>(new Exception(e.Message));
        }
    }
}
