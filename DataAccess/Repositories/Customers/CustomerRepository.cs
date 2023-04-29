namespace DataAccess.Repositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly MaadContext _context;

    public CustomerRepository(MaadContext aadContext)
    {
        _context = aadContext;
    }

    public async ValueTask<Result<ICollection<CustomerResponse>>> GetAllCustomersAsync(string userId)
    {
        try
        {
            return await _context.Customers.Where(x => x.CustomerStatus == Status.Show && x.IdUser == userId)
                .Select(x => new CustomerResponse
                {
                    BirthDayDate = x.BirthDayDate,
                    CustomerId = x.Id,
                    From = x.DateCreated,
                    CustomerState = x.CustomerState,
                    // CustomerCategoryId = x.CustomerCategoryId,
                    EmailAddress = x.EmailAddresses.FirstOrDefault().CustomerEmailAddress,
                    PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    // MoshtaryMoAref = x.IdUserAdded,
                    Address = x.CustomerAddresses.FirstOrDefault().Address,
                    CityId = x.IdCity,
                    Gender = x.Gender
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerResponse>> GetCustomerByIdAsync(Ulid customerId)
    {
        try
        {
            var result = await _context.Customers.FirstOrDefaultAsync(x => x.Id == customerId && x.CustomerStatus == Status.Show)
                .Select(x => new CustomerResponse
                {
                    CustomerId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                });
            return result;
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<CustomerResponse>>> FilterByItemsAsync(CustomerByFilterItemsQuery request)
    {
        var resultsListCustomer = _context.Customers
            .Include(x => x.FavoritesLists)
            .Select(customers => new CustomerResponse
            {
                CustomerId = customers.Id,
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                PhoneNumber = customers.PhoneNumbers.FirstOrDefault().PhoneNo,
                EmailAddress = customers.EmailAddresses.FirstOrDefault().CustomerEmailAddress,
                Address = customers.CustomerAddresses.FirstOrDefault().Address,
                CustomerState = customers.CustomerState,
                From = customers.DateCreated,
                UpTo = DateTime.UtcNow,
                BirthDayDate = customers.BirthDayDate,
                CityId = customers.IdCity,
                Gender = customers.Gender,
                DateCreated = customers.DateCreated,
            }).AsQueryable();

        var test = resultsListCustomer.ToList();

        if (request is { From: { }, UpTo: { } })
        {
            resultsListCustomer =
                resultsListCustomer.Where(x => x.DateCreated < request.UpTo && x.DateCreated > request.From);
        }
        else if (request is { From: { } })
        {
            resultsListCustomer = resultsListCustomer.Where(x => x.DateCreated > request.From);
        }
        else if (request is { UpTo: { } })
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

        // if (request is { ProvinceId: { } })
        //     resultsListCustomer = resultsListCustomer.Where(x => x.ProvinceId == request.ProvinceId);

        if (request is { CityId: { } })
            resultsListCustomer = resultsListCustomer.Where(x => x.CityId == request.CityId);

        // if (request is { Id: { } })
        //     resultsListCustomer = resultsListCustomer.Where(x => x.Id == request.Id);
        //
        return await resultsListCustomer.ToListAsync();
    }

    public async ValueTask<Result<ICollection<CustomerResponse>>> SearchByItemsAsync(string request)
    {
        var resultsListCustomer = _context.Customers
            .Include(x => x.FavoritesLists)
            // .Include(x => x.City)
            // .ThenInclude(x => x.Province)
            .Select(customers => new CustomerResponse
            {
                CustomerId = customers.Id,
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                PhoneNumber = customers.PhoneNumbers.FirstOrDefault().PhoneNo,
                EmailAddress = customers.EmailAddresses.FirstOrDefault().CustomerEmailAddress,
                Address = customers.CustomerAddresses.FirstOrDefault().Address,
                CustomerState = customers.CustomerState,
                // MoshtaryMoAref = customers.IdUserAdded,
                // CustomerCategoryId = customers.CustomerCategoryId,
                From = customers.DateCreated,
                UpTo = DateTime.UtcNow,
                BirthDayDate = customers.BirthDayDate,
                CityId = customers.IdCity,
                Gender = customers.Gender,
                DateCreated = customers.DateCreated
            }).AsQueryable();

        var result = await resultsListCustomer.Where(
            x => x.FirstName.ToLower().Contains(request.ToLower())
                 || x.LastName.ToLower().Contains(request.ToLower())
                 || x.PhoneNumber.ToLower().Contains(request.ToLower())
                 || x.EmailAddress.ToLower().Contains(request.ToLower())
            // || x.Address.Contains(request)
        ).ToListAsync();

        return result;
    }

    public async ValueTask<Result<CustomerResponse>> ChangeStatusCustomerByIdAsync(ChangeStatusCustomerCommand request)
    {
        try
        {
            var item = await _context.Customers.FindAsync(request.CustomerId);
            if (item is null) return new Result<CustomerResponse>(new ValidationException());
            item.CustomerStatus = request.CustomerStatus;
            await _context.SaveChangesAsync();
            return new Result<CustomerResponse>(await _context.Customers.FindAsync(request.CustomerId)
                .Select(x => new CustomerResponse
                {
                    BirthDayDate = x.BirthDayDate,
                    CustomerId = x.Id,
                    From = x.DateCreated,
                    CustomerState = x.CustomerState,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CityId = x.IdCity,
                    Gender = x.Gender
                }));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerResponse>> CreateCustomerAsync(CreateCustomerCommand request)
    {
        try
        {
            var entityEntry = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDayDate = request.BirthDayDate!,
                CustomerPic = request.CustomerPic,
                IdUser = request.UserId,
                Gender = request.Gender,
                IdCity = request.CityId,
                IdUserUpdated = request.IdUserAdded,
                IdUserAdded = request.IdUserAdded
            };
            await _context.Customers!.AddAsync(entityEntry);
            var result = await _context.SaveChangesAsync();
            if (result == 0) return new Result<CustomerResponse>(new ValidationException());

            if (request.PhoneNumbers != null)
                foreach (string PhoneNumbers in request.PhoneNumbers)
                {
                    CustomersPhoneNumber newPhone = new()
                    {
                        IdCustomer = entityEntry.Id,
                        PhoneNo = PhoneNumbers,
                        PhoneType = PhoneTypes.Phone
                    };

                    await _context.CustomersPhoneNumbers.AddAsync(newPhone);
                }

            if (request.CustomersAddresses != null)
                foreach (string address in request.CustomersAddresses)
                {
                    CustomerAddress newAddress = new()
                    {
                        IdCustomer = entityEntry.Id,
                        Address = address
                    };

                    await _context.CustomersAddresses.AddAsync(newAddress);
                }

            if (request.CustomerPeyGiries != null)
                foreach (string peyGiry in request.CustomerPeyGiries)
                {
                    CustomerPeyGiry newPeyGiry = new()
                    {
                        IdCustomer = entityEntry.Id,
                        Description = peyGiry
                    };

                    await _context.CustomerPeyGiries.AddAsync(newPeyGiry);
                }

            if (request.CustomerNotes != null)
                foreach (string note in request.CustomerNotes)
                {
                    CustomerNote newNote = new()
                    {
                        IdCustomer = entityEntry.Id,
                        Description = note,
                        IdUserAdded = request.IdUserAdded,
                        IdUserUpdated = request.UserId
                    };

                    await _context.CustomerNotes.AddAsync(newNote);
                }

            if (request.EmailAddresses != null)
                foreach (var emailAddress in request.EmailAddresses)
                {
                    CustomersEmailAddress newEmailAddress = new()
                    {
                        IdCustomer = entityEntry.Id,
                        CustomerEmailAddress = emailAddress
                    };

                    await _context.CustomersEmailAddresses.AddAsync(newEmailAddress);
                }

            if (request.FavoritesLists != null)
                foreach (var entityFavoritesList in request.FavoritesLists)
                {
                    ProductCustomerFavoritesList newFavoritesList = new()
                    {
                        IdCustomer = entityEntry.Id,
                        IdProduct = entityFavoritesList
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
                // CustomerCategoryId = entityEntry.CustomerCategoryId,
                EmailAddress = entityEntry.EmailAddresses.FirstOrDefault()!.CustomerEmailAddress,
                PhoneNumber = entityEntry.PhoneNumbers.FirstOrDefault()!.PhoneNo,
                FirstName = entityEntry.FirstName,
                LastName = entityEntry.LastName,
                Address = entityEntry.CustomerAddresses.FirstOrDefault()!.Address,
                CityId = entityEntry.IdCity,
                Gender = entityEntry.Gender
            };
            //return returnItem;
            return new Result<CustomerResponse>(await _context.Customers.FindAsync(entityEntry.Id)
                .Select(x => new CustomerResponse
                {
                    BirthDayDate = x.BirthDayDate,
                    CustomerId = x.Id,
                    From = x.DateCreated,
                    CustomerState = x.CustomerState,
                    EmailAddress = x.EmailAddresses.FirstOrDefault().CustomerEmailAddress,
                    PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.CustomerAddresses.FirstOrDefault().Address,
                    CityId = x.IdCity,
                    Gender = x.Gender
                }));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new ValidationException(e.Message + e.InnerException));
        }
    }

    public async ValueTask<Result<CustomerResponse>> UpdateCustomerAsync(UpdateCustomerCommand request)
    {
        try
        {
            var customer = await _context.Customers.FindAsync(request.Id);

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.BirthDayDate = request.BirthDayDate!;
            customer.CustomerMoarefId = request.CustomerMoarefId;
            customer.IdCity = request.CityId;
            customer.Gender = request.Gender;

            if (request.CustomersAddresses != null)
            {
                var resultAddress =
                    await _context.CustomersAddresses.FirstOrDefaultAsync(x => x.IdCustomer == request.Id);
                resultAddress.Address = request.CustomersAddresses.FirstOrDefault();
            }


            if (request.PhoneNumbers != null)
            {
                var phoneNumber =
                    await _context.CustomersPhoneNumbers.FirstOrDefaultAsync(x => x.IdCustomer == request.Id);
                phoneNumber.PhoneNo = request.PhoneNumbers.FirstOrDefault();
            }

            if (request.EmailAddresses != null)
            {
                var emailAddress =
                    await _context.CustomersEmailAddresses.FirstOrDefaultAsync(x => x.IdCustomer == request.Id);
                emailAddress.CustomerEmailAddress = request.EmailAddresses.FirstOrDefault();
            }

            await _context.SaveChangesAsync();

            return new Result<CustomerResponse>(new CustomerResponse
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumbers.FirstOrDefault().ToString(),
                EmailAddress = customer.EmailAddresses.FirstOrDefault().ToString(),
                CityId = customer.IdCity,
                MoshtaryMoAref = customer.CustomerMoarefId,
                BirthDayDate = customer.BirthDayDate,
                CustomerState = customer.CustomerState,
                Address = customer.CustomerAddresses.FirstOrDefault().Address,
                Gender = customer.Gender
            });
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message + "\t\t" + e.InnerException));
        }
    }

    public async ValueTask<Result<CustomerResponse>> DeleteCustomerAsync(Ulid customerId)
    {
        try
        {
            var customer = await _context.Customers.FindAsync(customerId);
            customer!.CustomerStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return new Result<CustomerResponse>(await _context.Customers.FindAsync(customerId)
                .Select(x => new CustomerResponse
                {
                    BirthDayDate = x.BirthDayDate,
                    CustomerId = x.Id,
                    From = x.DateCreated,
                    CustomerState = x.CustomerState,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CityId = x.IdCity,
                    Gender = x.Gender
                }));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new ValidationException(e.Message));
        }
    }
}