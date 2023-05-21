using Application.Responses.Customer.Foroosh;

namespace Application.Services.Customer.Foroosh.ForooshFactorService.CommandHandler;

public readonly struct CreateForooshFactorCommandHandler : IRequestHandler<CreateForooshFactorCommand, Result<FactorInformationResponse>>
{
    private readonly IForooshFactorRepository _repository;

    public CreateForooshFactorCommandHandler(IForooshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<FactorInformationResponse>> Handle(CreateForooshFactorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateForooshFactorCommand item = new()
            {
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
            return (await _repository.CreateForooshFactorAsync(item))
                .Match(result => new Result<FactorInformationResponse>(result),
                    exception => new Result<FactorInformationResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<FactorInformationResponse>(new Exception(e.Message));
        }
    }
}
