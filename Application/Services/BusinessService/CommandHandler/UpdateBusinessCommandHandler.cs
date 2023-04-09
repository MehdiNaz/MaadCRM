namespace Application.Services.BusinessService.CommandHandler;

public class UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand, Business>
{
    private readonly IBusinessRepository _repository;

    public UpdateBusinessCommandHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Business> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
    {
        Business item = new()
        {
            BusinessId = request.BusinessId,
            Url = request.Url,
            Hosts = request.Hosts,
            CompanyName = request.CompanyName,
            CompanyAddress = request.CompanyAddress,
            DisplayOrder = request.DisplayOrder,
            //UserId = request.UserId!
        };
        await _repository.UpdateBusinessAsync(item);
        return item;
    }
}