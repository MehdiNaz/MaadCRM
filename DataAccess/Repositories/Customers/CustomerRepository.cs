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

    public async ValueTask<Customer?> GetCustomerByIdAsync(Ulid customerId) => await _context.Customers!.FindAsync(customerId);

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

            var entityEntry = new Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                BirthDayDate = customer.BirthDayDate!,
                CustomerPic = customer.CustomerPic,
                CustomerCategoryId = customer.CustomerCategoryId,
                Gender = customer.Gender,
                CustomerMoarefId = customer.CustomerMoarefId,
                CityId = customer.CityId
            };



            // TODO: Update customer

            //if (entity.PhoneNumbers != null)
            //    foreach (string PhoneNumbers in entity.PhoneNumbers)
            //    {
            //        CustomersPhoneNumber newPhone = new()
            //        {
            //            CustomerId = entityEntry.Id,
            //            PhoneNo = PhoneNumbers
            //        };

            //        await _context.CustomersPhoneNumbers.AddAsync(newPhone);
            //    }

            // if (entity.CustomersAddresses != null)
            //     foreach (string address in entity.CustomersAddresses)
            //     {
            //         CustomersAddress newAddress = new()
            //         {
            //             CustomerId = entityEntry.Id,
            //             Address = address
            //         };
            //
            //         await _context.CustomersAddresses.AddAsync(newAddress);
            //     }

            //if (entity.CustomerPeyGiries != null)
            //    foreach (string peyGiry in entity.CustomerPeyGiries)
            //    {
            //        CustomerPeyGiry newPeyGiry = new()
            //        {
            //            CustomerId = entityEntry.Id,
            //            Description = peyGiry
            //        };

            //        await _context.CustomerPeyGiries.AddAsync(newPeyGiry);
            //    }

            //if (entity.CustomerNotes != null)
            //    foreach (string note in entity.CustomerNotes)
            //    {
            //        CustomerNote newNote = new()
            //        {
            //            CustomerId = entityEntry.Id,
            //            Description = note
            //        };

            //        await _context.CustomerNotes.AddAsync(newNote);
            //    }

            //if (entity.EmailAddresses != null)
            //    foreach (string emailAddress in entity.EmailAddresses)
            //    {
            //        CustomersEmailAddress newEmailAddress = new()
            //        {
            //            CustomerId = entityEntry.Id,
            //            CustomersEmailAddrs = emailAddress
            //        };

            //        await _context.CustomersEmailAddresses.AddAsync(newEmailAddress);
            //    }

            // if (entity.FavoritesLists != null)
            //     foreach (var entityFavoritesList in entity.FavoritesLists)
            //     {
            //         ProductCustomerFavoritesList newFavoritesList = new()
            //         {
            //             CustomerId = entityEntry.Id,
            //             // ProductId =Ulid.Parse(entityFavoritesList)
            //         };
            //
            //         await _context.ProductCustomerFavoritesLists.AddAsync(newFavoritesList);
            //     }


            _context.Update(entityEntry);
            await _context.SaveChangesAsync();
            return entityEntry;
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