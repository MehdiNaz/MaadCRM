﻿namespace Application.Services.CustomerPeyGiryService.CommandHandler;

public readonly struct CreateCustomerPeyGiryCommandHandler : IRequestHandler<CreateCustomerPeyGiryCommand, CustomerPeyGiry>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public CreateCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerPeyGiry> Handle(CreateCustomerPeyGiryCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerPeyGiryCommand item = new()
        {
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        return await _repository.CreateCustomerPeyGiryAsync(item);
    }
}