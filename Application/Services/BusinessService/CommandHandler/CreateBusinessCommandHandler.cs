namespace Application.Services.BusinessService.CommandHandler;

public readonly struct CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, Result<Business>>
{
    private readonly IBusinessRepository _repository;

    public CreateBusinessCommandHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Business>> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateBusinessCommand item = new()
            {
                BusinessName = request.BusinessName,
                Url = request.Url,
                Hosts = request.Hosts,
                CompanyName = request.CompanyName,
                CompanyAddress = request.CompanyAddress,
                DisplayOrder = request.DisplayOrder
            };
            return (await _repository.CreateBusinessAsync(item)).Match(result => new Result<Business>(result), exception => new Result<Business>(exception));
        }
        catch (Exception e)
        {
            return new Result<Business>(new Exception(e.Message));
        }
    }
}
