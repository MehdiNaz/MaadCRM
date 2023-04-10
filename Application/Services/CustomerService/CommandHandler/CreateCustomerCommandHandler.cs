﻿namespace Application.Services.CustomerService.CommandHandler;

public readonly struct CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var item = new CreateCustomerCommand()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDayDate = request.BirthDayDate!,
            CustomerPic = request.CustomerPic,
            // CreatedBy = request.CreatedBy!,
            // UpdatedBy = request.UpdatedBy,
            CustomerCategoryId = request.CustomerCategoryId,
            // UserId = request.UserId,
            Gender = request.Gender,
            CustomerMoarefId = request.CustomerMoarefId,
            PhoneNumbers = request.PhoneNumbers,
            EmailAddresses = request.EmailAddresses,
            FavoritesLists = request.FavoritesLists!,
            CustomersAddresses = request.CustomersAddresses,
            CustomerNotes = request.CustomerNotes,
            CustomerPeyGiries = request.CustomerPeyGiries,
            CityId = request.CityId
        };
        var result = await _repository.CreateCustomerAsync(item);
        return result;
    }
}
