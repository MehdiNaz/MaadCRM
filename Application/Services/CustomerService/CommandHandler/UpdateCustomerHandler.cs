﻿namespace Application.Services.CustomerService.CommandHandler;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer item = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDayDate = request.BirthDayDate,
            Email = request.Email,
            PhoneNumberId = request.PhoneNumberId,
            AddressId = request.AddressId,
            CityId = request.CityId,
            NoteId = request.NoteId,
            ProvinceId = request.ProvinceId,
            CategoryId = request.CategoryId,
            WishProductId = request.WishProductId,
            ProfileImageId = request.ProfileImageId,
            BusinessId = request.BusinessId,
            CustomerRepresentativeHistoryId = request.CustomerRepresentativeHistoryId,
            MoarefId = request.MoarefId,
            CustomerState = request.CustomerState,
            IsDeleted = request.IsDeleted,
            Gender = request.Gender
        };
        await _repository.UpdateCustomerAsync(item, request.CustomerId);
        return item;
    }
}