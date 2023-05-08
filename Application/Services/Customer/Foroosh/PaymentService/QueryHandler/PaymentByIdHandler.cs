namespace Application.Services.Customer.Foroosh.PaymentService.QueryHandler;

public readonly struct PaymentByIdHandler : IRequestHandler<PaymentByIdQuery, Result<Payment>>
{
    private readonly IPaymentRepository _repository;

    public PaymentByIdHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Payment>> Handle(PaymentByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetPaymentByIdAsync(request.Id))
                .Match(result => new Result<Payment>(result),
                    exception => new Result<Payment>(exception));
        }
        catch (Exception e)
        {
            return new Result<Payment>(new Exception(e.Message));
        }
    }
}