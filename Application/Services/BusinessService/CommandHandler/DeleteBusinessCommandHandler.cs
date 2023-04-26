namespace Application.Services.BusinessService.CommandHandler;

public readonly struct DeleteBusinessCommandHandler : IRequestHandler<DeleteBusinessCommand, Result<Business>>
{
    private readonly IBusinessRepository _repository;

    public DeleteBusinessCommandHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Business>> Handle(DeleteBusinessCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteBusinessAsync(request.BusinessId)).Match(result => new Result<Business>(result), exception => new Result<Business>(exception));
        }
        catch (Exception e)
        {
            return new Result<Business>(new Exception(e.Message));
        }
    }
}