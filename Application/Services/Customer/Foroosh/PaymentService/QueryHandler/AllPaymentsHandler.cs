namespace Application.Services.Customer.Foroosh.PaymentService.QueryHandler;

public readonly struct AllPaymentsHandler : IRequestHandler<AllPaymentsQuery, Result<ICollection<ForooshPayment>>>
{
    private readonly IForooshPaymentRepository _repository;

    public AllPaymentsHandler(IForooshPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ForooshPayment>>> Handle(AllPaymentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllPaymentsAsync())
                .Match(result => new Result<ICollection<ForooshPayment>>(result),
                    exception => new Result<ICollection<ForooshPayment>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ForooshPayment>>(new Exception(e.Message));
        }
    }
}