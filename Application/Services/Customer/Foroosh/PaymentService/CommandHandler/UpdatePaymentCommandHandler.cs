namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Result<Payment>>
{
    private readonly IPaymentRepository _repository;

    public UpdatePaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Payment>> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
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
                .Match(result => new Result<Payment>(result),
                    exception => new Result<Payment>(exception));
        }
        catch (Exception e)
        {
            return new Result<Payment>(new Exception(e.Message));
        }
    }
}