namespace Application.Services.CustomerActivityService.CommandHandlers;

public readonly struct DeleteCustomerActivityCommandHandler : IRequestHandler<DeleteCustomerActivityCommand, CustomerActivity>
{
    private readonly ICustomerActivityRepository _repository;

    public DeleteCustomerActivityCommandHandler(ICustomerActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerActivity> Handle(DeleteCustomerActivityCommand request, CancellationToken cancellationToken)
        => await _repository.DeleteCustomerActivityAsync(request);
}