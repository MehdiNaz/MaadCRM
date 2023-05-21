namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result<ForooshPayment>>
{
    private readonly IForooshPaymentRepository _repository;

    public CreatePaymentCommandHandler(IForooshPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshPayment>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreatePaymentCommand item = new()
            {
                DatePay = request.DatePay,
                PaymentAmount = request.PaymentAmount,
                IdForooshFactor = request.IdForooshFactor
            };

            return (await _repository.CreatePaymentAsync(item))
                .Match(result => new Result<ForooshPayment>(result),
                    exception => new Result<ForooshPayment>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshPayment>(new Exception(e.Message));
        }
    }
}