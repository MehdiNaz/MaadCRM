namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Result<Payment>>
{
    private readonly IPaymentRepository _repository;

    public DeletePaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Payment>> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeletePaymentAsync(request.Id))
                .Match(result => new Result<Payment>(result),
                    exception => new Result<Payment>(exception));
        }
        catch (Exception e)
        {
            return new Result<Payment>(new Exception(e.Message));
        }
    }
}