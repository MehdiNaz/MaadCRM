namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct ChangeStatusPaymentCommandHandler : IRequestHandler<ChangeStatusPaymentCommand, Result<ForooshPayment>>
{
    private readonly IForooshPaymentRepository _repository;

    public ChangeStatusPaymentCommandHandler(IForooshPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshPayment>> Handle(ChangeStatusPaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusPaymentByIdAsync(request))
                .Match(result => new Result<ForooshPayment>(result),
                    exception => new Result<ForooshPayment>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshPayment>(new Exception(e.Message));
        }
    }
}