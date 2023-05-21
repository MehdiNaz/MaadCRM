namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Result<ForooshPayment>>
{
    private readonly IForooshPaymentRepository _repository;

    public UpdatePaymentCommandHandler(IForooshPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshPayment>> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdatePaymentCommand item = new()
            {
                Id = request.Id,
                DatePay = request.DatePay,
                PaymentAmount = request.PaymentAmount
            };

            return (await _repository.UpdatePaymentAsync(item))
                .Match(result => new Result<ForooshPayment>(result),
                    exception => new Result<ForooshPayment>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshPayment>(new Exception(e.Message));
        }
    }
}