namespace Application.Services.Customer.Foroosh.ForoshOrderService.CommandHandler;

public readonly struct ChangeStatusForooshOrderCommandHandler : IRequestHandler<ChangeStatusForooshOrderCommand, Result<ForooshOrder>>
{
    private readonly IForooshOrderRepository _repository;

    public ChangeStatusForooshOrderCommandHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshOrder>> Handle(ChangeStatusForooshOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusForooshOrderByIdAsync(request))
                .Match(result => new Result<ForooshOrder>(result),
                    exception => new Result<ForooshOrder>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new Exception(e.Message));
        }
    }
}