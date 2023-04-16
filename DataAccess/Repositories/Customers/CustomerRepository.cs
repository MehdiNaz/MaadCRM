﻿namespace DataAccess.Repositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly MaadContext _context;

    public CustomerRepository(MaadContext aadContext)
    {
        _context = aadContext;
    }

    public async ValueTask<ICollection<CustomerResponse>> GetAllCustomersAsync(string userId)
    {
        return await _context.Customers.Where(x => x.CustomerStatus == Status.Show && x.UserId == userId).Select(x => new CustomerResponse
        {
            BirthDayDate = x.BirthDayDate,
            CustomerId = x.Id,
            From = x.DateCreated,
            CustomerState = x.CustomerState,
            CustomerCategoryId = x.CustomerCategoryId,
            EmailAddress = x.EmailAddresses.FirstOrDefault().CustomersEmailAddrs,
            PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
            FirstName = x.FirstName,
            LastName = x.LastName,
            MoshtaryMoAref = x.CustomerMoarefId,
            Address = x.CustomersAddresses.FirstOrDefault().Address,
            CityId = x.CityId,
            Gender = x.Gender
        }).ToListAsync();
    }

    public async ValueTask<CustomerResponse> GetCustomerByIdAsync(Ulid customerId)
    {
        return await _context.Customers.FirstOrDefaultAsync(x => x.Id == customerId && x.CustomerStatus == Status.Show)
            .Select(x => new CustomerResponse
            {
                BirthDayDate = x.BirthDayDate,
                CustomerId = x.Id,
                From = x.DateCreated,
                CustomerState = x.CustomerState,
                CustomerCategoryId = x.CustomerCategoryId,
                EmailAddress = x.EmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MoshtaryMoAref = x.CustomerMoarefId,
                Address = x.CustomersAddresses.FirstOrDefault().Address,
                CityId = x.CityId,
                Gender = x.Gender
            });
    }

    public async ValueTask<ICollection<CustomerResponse>?> SearchByItemsAsync(CustomerBySearchItemsQuery request)
    {
        var resultsListCustomer = _context.Customers
            .Include(x => x.FavoritesLists)
            .Include(x => x.City)
            .ThenInclude(x => x.Province)
            .Select(customers => new CustomerResponse
            {
                CustomerId = customers.Id,
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                PhoneNumber = customers.PhoneNumbers.FirstOrDefault().PhoneNo,
                EmailAddress = customers.EmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                Address = customers.CustomersAddresses.FirstOrDefault().Address,
                CustomerState = customers.CustomerState,
                MoshtaryMoAref = customers.CustomerMoarefId,
                CustomerCategoryId = customers.CustomerCategoryId,
                From = customers.DateCreated,
                UpTo = DateTime.UtcNow,
                BirthDayDate = customers.BirthDayDate,
                CityId = customers.CityId,
                Gender = customers.Gender,
                DateCreated = customers.DateCreated,
            }).AsQueryable();

        var test = resultsListCustomer.ToList();

        if (request.From != null && request.UpTo != null)
        {
            resultsListCustomer =
                resultsListCustomer.Where(x => x.DateCreated < request.UpTo && x.DateCreated > request.From);
        }
        else if (request is { From: { } })
        {
            resultsListCustomer = resultsListCustomer.Where(x => x.DateCreated > request.From);
        }else if (request is { UpTo: { } })
        {
            resultsListCustomer = resultsListCustomer.Where(x => x.DateCreated < request.UpTo);
        }

        if (!request.CustomerId.ToString().IsNullOrEmpty())
            resultsListCustomer = resultsListCustomer.Where(x => x.CustomerId == request.CustomerId);

        

        if (request is { CustomerState: { } })
            resultsListCustomer = resultsListCustomer.Where(x => x.CustomerState == request.CustomerState);

        if (request is { MoshtaryMoAref: { } })
            resultsListCustomer = resultsListCustomer.Where(x => x.MoshtaryMoAref == request.MoshtaryMoAref);

        if (request is { BirthDayDate: { } })
            resultsListCustomer = resultsListCustomer.Where(x => x.BirthDayDate == request.BirthDayDate);

        if (request is { Gender: { } })
            resultsListCustomer = resultsListCustomer.Where(x => x.Gender == request.Gender);

        if (request is { ProvinceId: { } })
            resultsListCustomer = resultsListCustomer.Where(x => x.ProvinceId == request.ProvinceId);

        if (request is { CityId: { } })
            resultsListCustomer = resultsListCustomer.Where(x => x.CityId == request.CityId);

        if (request is { ProductId: { } })
            resultsListCustomer = resultsListCustomer.Where(x => x.ProductId == request.ProductId);

        return await resultsListCustomer.ToListAsync();
    }

    public async Task<CustomerResponse?> ChangeStatusCustomerByIdAsync(Status status, Ulid customerId)
    {
        try
        {
            var item = await _context.Customers.FindAsync(customerId);
            if (item is null) return null;
            item.CustomerStatus = status;
            await _context.SaveChangesAsync();
            return await _context.Customers.FindAsync(customerId)
                .Select(x => new CustomerResponse
                {
                    BirthDayDate = x.BirthDayDate,
                    CustomerId = x.Id,
                    From = x.DateCreated,
                    CustomerState = x.CustomerState,
                    CustomerCategoryId = x.CustomerCategoryId,
                    EmailAddress = x.EmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                    PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MoshtaryMoAref = x.CustomerMoarefId,
                    Address = x.CustomersAddresses.FirstOrDefault().Address,
                    CityId = x.CityId,
                    Gender = x.Gender
                });
        }
        catch
        {
            return null;
        }
    }

    public async Task<CustomerResponse?> CreateCustomerAsync(CreateCustomerCommand entity)
    {
        try
        {
            var entityEntry = new Customer
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BirthDayDate = entity.BirthDayDate!,
                CustomerPic = entity.CustomerPic,
                // CreatedBy = request.CreatedBy!,
                // UpdatedBy = request.UpdatedBy,
                CustomerCategoryId = entity.CustomerCategoryId,
                UserId = entity.UserId,
                Gender = entity.Gender,
                CustomerMoarefId = entity.CustomerMoarefId,
                // PhoneNumbers = entity.PhoneNumbers,
                // EmailAddresses = entity.EmailAddresses,
                // FavoritesLists = entity.FavoritesLists,
                // CustomersAddresses = entity.CustomersAddresses,
                // CustomerNotes = entity.CustomerNotes,
                // CustomerPeyGiries = entity.CustomerPeyGiries,
                CityId = entity.CityId
            };
            await _context.Customers!.AddAsync(entityEntry);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
                return null;

            if (entity.PhoneNumbers != null)
                foreach (string PhoneNumbers in entity.PhoneNumbers)
                {
                    CustomersPhoneNumber newPhone = new()
                    {
                        CustomerId = entityEntry.Id,
                        PhoneNo = PhoneNumbers
                    };

                    await _context.CustomersPhoneNumbers.AddAsync(newPhone);
                }

            if (entity.CustomersAddresses != null)
                foreach (string address in entity.CustomersAddresses)
                {
                    CustomersAddress newAddress = new()
                    {
                        CustomerId = entityEntry.Id,
                        Address = address
                    };

                    await _context.CustomersAddresses.AddAsync(newAddress);
                }

            if (entity.CustomerPeyGiries != null)
                foreach (string peyGiry in entity.CustomerPeyGiries)
                {
                    CustomerPeyGiry newPeyGiry = new()
                    {
                        CustomerId = entityEntry.Id,
                        Description = peyGiry
                    };

                    await _context.CustomerPeyGiries.AddAsync(newPeyGiry);
                }

            if (entity.CustomerNotes != null)
                foreach (string note in entity.CustomerNotes)
                {
                    CustomerNote newNote = new()
                    {
                        CustomerId = entityEntry.Id,
                        Description = note
                    };

                    await _context.CustomerNotes.AddAsync(newNote);
                }

            if (entity.EmailAddresses != null)
                foreach (string emailAddress in entity.EmailAddresses)
                {
                    CustomersEmailAddress newEmailAddress = new()
                    {
                        CustomerId = entityEntry.Id,
                        CustomersEmailAddrs = emailAddress
                    };

                    await _context.CustomersEmailAddresses.AddAsync(newEmailAddress);
                }

            if (entity.FavoritesLists != null)
                foreach (var entityFavoritesList in entity.FavoritesLists)
                {
                    ProductCustomerFavoritesList newFavoritesList = new()
                    {
                        CustomerId = entityEntry.Id,
                        ProductId = entityFavoritesList
                    };

                    await _context.ProductCustomerFavoritesLists.AddAsync(newFavoritesList);
                }

            await _context.SaveChangesAsync();

            CustomerResponse returnItem = new()
            {
                BirthDayDate = entityEntry.BirthDayDate,
                CustomerId = entityEntry.Id,
                From = entityEntry.DateCreated,
                CustomerState = entityEntry.CustomerState,
                CustomerCategoryId = entityEntry.CustomerCategoryId,
                EmailAddress = entityEntry.EmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                PhoneNumber = entityEntry.PhoneNumbers.FirstOrDefault().PhoneNo,
                FirstName = entityEntry.FirstName,
                LastName = entityEntry.LastName,
                MoshtaryMoAref = entityEntry.CustomerMoarefId,
                Address = entityEntry.CustomersAddresses.FirstOrDefault().Address,
                CityId = entityEntry.CityId,
                Gender = entityEntry.Gender
            };
            return returnItem;
        }
        catch
        {
            return null;
        }
    }

    public async Task<CustomerResponse?> UpdateCustomerAsync(UpdateCustomerCommand entity)
    {
        try
        {
            CustomerResponse customer = await GetCustomerByIdAsync(entity.Id);

            customer.CustomerId = entity.Id;
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.BirthDayDate = entity.BirthDayDate!;
            customer.CustomerCategoryId = entity.CustomerCategoryId;
            customer.BirthDayDate = entity.BirthDayDate;
            customer.CustomerCategoryId = entity.CustomerCategoryId;
            customer.EmailAddress = entity.EmailAddresses.FirstOrDefault();
            customer.PhoneNumber = entity.PhoneNumbers.FirstOrDefault();
            customer.MoshtaryMoAref = entity.CustomerMoarefId;
            customer.Address = entity.CustomersAddresses.FirstOrDefault();
            customer.CityId = entity.CityId;
            customer.Gender= entity.Gender;


            await _context.SaveChangesAsync();

            if (entity.PhoneNumbers != null)
                foreach (string PhoneNumbers in entity.PhoneNumbers)
                {
                    CustomersPhoneNumber newPhone = new()
                    {
                        CustomerId = entity.Id,
                        PhoneNo = PhoneNumbers
                    };

                    await _context.CustomersPhoneNumbers.AddAsync(newPhone);
                }

            if (entity.CustomersAddresses != null)
                foreach (string address in entity.CustomersAddresses)
                {
                    CustomersAddress newAddress = new()
                    {
                        CustomerId = entity.Id,
                        Address = address
                    };

                    await _context.CustomersAddresses.AddAsync(newAddress);
                }

            if (entity.CustomerPeyGiries != null)
                foreach (string peyGiry in entity.CustomerPeyGiries)
                {
                    CustomerPeyGiry newPeyGiry = new()
                    {
                        CustomerId = entity.Id,
                        Description = peyGiry
                    };

                    await _context.CustomerPeyGiries.AddAsync(newPeyGiry);
                }

            if (entity.CustomerNotes != null)
                foreach (string note in entity.CustomerNotes)
                {
                    CustomerNote newNote = new()
                    {
                        CustomerId = entity.Id,
                        Description = note
                    };

                    await _context.CustomerNotes.AddAsync(newNote);
                }

            if (entity.EmailAddresses != null)
                foreach (string emailAddress in entity.EmailAddresses)
                {
                    CustomersEmailAddress newEmailAddress = new()
                    {
                        CustomerId = entity.Id,
                        CustomersEmailAddrs = emailAddress
                    };

                    await _context.CustomersEmailAddresses.AddAsync(newEmailAddress);
                }

            //if (entity.FavoritesLists != null)
            //    foreach (var entityFavoritesList in entity.FavoritesLists)
            //    {
            //        ProductCustomerFavoritesList newFavoritesList = new()
            //        {
            //            CustomerId = entity.Id,
            //            ProductId = Ulid.Parse(entityFavoritesList)
            //        };

            //        await _context.ProductCustomerFavoritesLists.AddAsync(newFavoritesList);
            //    }

            await _context.SaveChangesAsync();

            //CustomerResponse returnItem = new()
            //{
            //    BirthDayDate = customer.BirthDayDate,
            //    CustomerId = customer.Id,
            //    From = customer.DateCreated,
            //    CustomerState = customer.CustomerState,
            //    CustomerCategoryId = customer.CustomerCategoryId,
            //    EmailAddress = customer.EmailAddresses.FirstOrDefault().CustomersEmailAddrs,
            //    PhoneNumber = customer.PhoneNumbers.FirstOrDefault().PhoneNo,
            //    FirstName = customer.FirstName,
            //    LastName = customer.LastName,
            //    MoshtaryMoAref = customer.CustomerMoarefId,
            //    Address = customer.CustomersAddresses.FirstOrDefault().Address
            //};
            return customer;
        }
        catch
        {
            return null;
        }
    }

    public async Task<CustomerResponse?> DeleteCustomerAsync(Ulid customerId)
    {
        try
        {
            var customer = await _context.Customers.FindAsync(customerId);
            customer!.CustomerStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            CustomerResponse returnItem = new()
            {
                BirthDayDate = customer.BirthDayDate,
                CustomerId = customer.Id,
                From = customer.DateCreated,
                CustomerState = customer.CustomerState,
                CustomerCategoryId = customer.CustomerCategoryId,
                EmailAddress = customer.EmailAddresses.FirstOrDefault().CustomersEmailAddrs,
                PhoneNumber = customer.PhoneNumbers.FirstOrDefault().PhoneNo,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MoshtaryMoAref = customer.CustomerMoarefId,
                Address = customer.CustomersAddresses.FirstOrDefault().Address,
                CityId = customer.CityId,
                Gender = customer.Gender
            };
            return returnItem;
        }
        catch
        {
            return null;
        }
    }
}