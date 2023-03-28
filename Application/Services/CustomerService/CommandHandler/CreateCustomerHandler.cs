﻿namespace Application.Services.CustomerService.CommandHandler;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer item = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDayDate = request.BirthDayDate,
            EmailId = request.EmailId,
            PhoneNumberId = request.PhoneNumberId,
            AddressId = request.AddressId,
            CityId = request.CityId,
            NoteId = request.NoteId,
            ProvinceId = request.ProvinceId,
            CategoryId = request.CategoryId,
            WishProductId = request.WishProductId,
            ProfileImageId = request.ProfileImageId,
            MoarefId = request.MoarefId,
            CustomerStatues = request.CustomerState,
            Gender = request.Gender
        };
        await _repository.CreateCustomerAsync(item);
        return item;
    }
}
