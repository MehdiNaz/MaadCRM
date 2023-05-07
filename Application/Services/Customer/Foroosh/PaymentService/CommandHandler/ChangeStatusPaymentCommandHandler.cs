namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct ChangeStatusPaymentCommandHandler : IRequestHandler<ChangeStatusPaymentCommand, Result<Payment>>
{
    private readonly IPaymentRepository _repository;

    public ChangeStatusPaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Payment>> Handle(ChangeStatusPaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusPaymentByIdAsync(request))
                .Match(result => new Result<Payment>(result),
                    exception => new Result<Payment>(exception));
        }
        catch (Exception e)
        {
            return new Result<Payment>(new Exception(e.Message));
        }
    }
}