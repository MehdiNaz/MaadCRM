namespace Application.Services.BusinessService.CommandHandler;

public readonly struct CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, Business>
{
    private readonly IBusinessRepository _repository;

    public CreateBusinessCommandHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Business> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
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
        return await _repository.CreateBusinessAsync(item);
    }
}
