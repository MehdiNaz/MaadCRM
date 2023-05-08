namespace Application.Services.Customer.Foroosh.PaymentService.QueryHandler;

public readonly struct AllPaymentsHandler : IRequestHandler<AllPaymentsQuery, Result<ICollection<Payment>>>
{
    private readonly IPaymentRepository _repository;

    public AllPaymentsHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<Payment>>> Handle(AllPaymentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllPaymentsAsync())
                .Match(result => new Result<ICollection<Payment>>(result),
                    exception => new Result<ICollection<Payment>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<Payment>>(new Exception(e.Message));
        }
    }
}