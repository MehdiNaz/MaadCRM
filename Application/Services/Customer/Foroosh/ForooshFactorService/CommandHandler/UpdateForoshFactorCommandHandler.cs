namespace Application.Services.Customer.Foroosh.ForooshFactorService.CommandHandler;

public readonly struct UpdateForooshFactorCommandHandler : IRequestHandler<UpdateForooshFactorCommand, Result<ForooshFactor>>
{
    private readonly IForooshFactorRepository _repository;

    public UpdateForooshFactorCommandHandler(IForooshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshFactor>> Handle(UpdateForooshFactorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateForooshFactorCommand item = new()
            {
                Id = request.Id,
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
            };

            return (await _repository.UpdateForooshFactorAsync(item))
                .Match(result => new Result<ForooshFactor>(result),
                    exception => new Result<ForooshFactor>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new Exception(e.Message));
        }
    }
}