namespace DataAccess.Repositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly MaadContext _context;

    public CustomerRepository(MaadContext aadContext)
    {
        _context = aadContext;
    }

    public async ValueTask<ICollection<Customer?>> GetAllCustomersAsync(string userId)
        => await _context.Customers.Where(x => x.CustomerStatus == Status.Show && x.UserId == userId).ToListAsync();

    public async ValueTask<Customer?> GetCustomerByIdAsync(Ulid customerId)
        => await _context.Customers.FirstOrDefaultAsync(x => x.Id == customerId && x.CustomerStatus == Status.Show);

    public async ValueTask<Customer?> ChangeStatusCustomerByIdAsync(Status status, Ulid customerId)
    {
        try
        {
            var item = await _context.Customers.FindAsync(customerId);
            if (item is null) return null;
            item.CustomerStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Customer?> CreateCustomerAsync(CreateCustomerCommand entity)
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

            return entityEntry;

        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Customer?> UpdateCustomerAsync(UpdateCustomerCommand entity)
    {
        try
        {
            Customer customer = await GetCustomerByIdAsync(entity.Id);

            customer.Id = entity.Id;
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.BirthDayDate = entity.BirthDayDate!;
            customer.CustomerPic = entity.CustomerPic;
            customer.CustomerCategoryId = entity.CustomerCategoryId;
            customer.Gender = entity.Gender;
            customer.CustomerMoarefId = entity.CustomerMoarefId;
            customer.CityId = entity.CityId;


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

            return customer;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Customer?> DeleteCustomerAsync(Ulid customerId)
    {
        try
        {
            var customer = await GetCustomerByIdAsync(customerId);
            customer!.CustomerStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}