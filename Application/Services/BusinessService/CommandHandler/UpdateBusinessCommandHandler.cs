namespace Application.Services.BusinessService.CommandHandler;

public readonly struct UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand, Result<Business>>
{
    private readonly IBusinessRepository _repository;

    public UpdateBusinessCommandHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Business>> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateBusinessCommand item = new()
            {
                BusinessId = request.BusinessId,
                Url = request.Url,
                Hosts = request.Hosts,
                CompanyName = request.CompanyName,
                CompanyAddress = request.CompanyAddress,
                DisplayOrder = request.DisplayOrder,
                BusinessName = request.BusinessName
                //IdUser = request.IdUser!
            };
            return (await _repository.UpdateBusinessAsync(item)).Match(result => new Result<Business>(result), exception => new Result<Business>(exception));
        }
        catch (Exception e)
        {
            return new Result<Business>(new Exception(e.Message));
        }
    }
}