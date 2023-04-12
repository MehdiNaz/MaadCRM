namespace Application.Services.CustomerActivityService.CommandHandlers;

public readonly struct ChangeStatusCustomerActivityCommandHandler : IRequestHandler<ChangeStatusCustomerActivityCommand, CustomerActivity?>
{
    private readonly ICustomerActivityRepository _repository;

    public ChangeStatusCustomerActivityCommandHandler(ICustomerActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerActivity?> Handle(ChangeStatusCustomerActivityCommand request,
        CancellationToken cancellationToken)
        => await _repository.ChangeStatusCustomerActivityByIdAsync(request.CustomerActivityStatus, request.CustomerActivityId);
}