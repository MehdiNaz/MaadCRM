namespace Application.Services.BusinessService.QueryHandler;

public class BusinessByIdHandler : IRequestHandler<BusinessByIdQuery, Business?>
{
    private readonly IBusinessRepository _repository;

    public BusinessByIdHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Business?> Handle(BusinessByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetBusinessByIdAsync(request.BusinessId);
}