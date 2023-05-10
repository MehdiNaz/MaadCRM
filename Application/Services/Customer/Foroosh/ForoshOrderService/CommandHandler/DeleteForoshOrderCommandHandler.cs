namespace Application.Services.Customer.Foroosh.ForoshOrderService.CommandHandler;

public readonly struct DeleteForooshOrderCommandHandler : IRequestHandler<DeleteForooshOrderCommand, Result<ForooshOrder>>
{
    private readonly IForooshOrderRepository _repository;

    public DeleteForooshOrderCommandHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshOrder>> Handle(DeleteForooshOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteForooshOrderAsync(request.Id))
                .Match(result => new Result<ForooshOrder>(result),
                    exception => new Result<ForooshOrder>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new Exception(e.Message));
        }
    }
}