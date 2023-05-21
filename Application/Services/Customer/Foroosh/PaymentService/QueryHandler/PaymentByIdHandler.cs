namespace Application.Services.Customer.Foroosh.PaymentService.QueryHandler;

public readonly struct PaymentByIdHandler : IRequestHandler<PaymentByIdQuery, Result<ForooshPayment>>
{
    private readonly IForooshPaymentRepository _repository;

    public PaymentByIdHandler(IForooshPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshPayment>> Handle(PaymentByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetPaymentByIdAsync(request.Id))
                .Match(result => new Result<ForooshPayment>(result),
                    exception => new Result<ForooshPayment>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshPayment>(new Exception(e.Message));
        }
    }
}