namespace Application.Services.Customer.Foroosh.PaymentService.CommandHandler;

public readonly struct CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result<Payment>>
{
    private readonly IPaymentRepository _repository;

    public CreatePaymentCommandHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Payment>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
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
                .Match(result => new Result<Payment>(result),
                    exception => new Result<Payment>(exception));
        }
        catch (Exception e)
        {
            return new Result<Payment>(new Exception(e.Message));
        }
    }
}