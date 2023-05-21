namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Result<ForooshPayment>>
{
    private readonly IForooshPaymentRepository _repository;

    public DeletePaymentCommandHandler(IForooshPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshPayment>> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeletePaymentAsync(request.Id))
                .Match(result => new Result<ForooshPayment>(result),
                    exception => new Result<ForooshPayment>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshPayment>(new Exception(e.Message));
        }
    }
}