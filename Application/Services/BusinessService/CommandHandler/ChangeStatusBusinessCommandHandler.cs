namespace Application.Services.BusinessService.CommandHandler;

public readonly struct ChangeStatusBusinessCommandHandler : IRequestHandler<ChangeStatusBusinessCommand, Result<Business>>
{
    private readonly IBusinessRepository _repository;

    public ChangeStatusBusinessCommandHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Business>> Handle(ChangeStatusBusinessCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var resultVerifyCode = await _repository.ChangeStatsAsync(request);
            return resultVerifyCode.Match(result => new Result<Business>(result), exception => new Result<Business>(exception));
        }
        catch (Exception e)
        {
            return new Result<Business>(new Exception(e.Message));
        }
    }
}