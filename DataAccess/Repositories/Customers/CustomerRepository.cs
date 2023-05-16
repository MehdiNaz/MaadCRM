namespace DataAccess.Repositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    public CustomerRepository(MaadContext maadContext, ILogRepository log)
    {
        _context = maadContext;
        _log = log;
    }

    public async ValueTask<Result<ICollection<CustomerResponse>>> GetAllCustomersAsync(string userId)
    {
        try
        {
            var result = await _context.Customers.Where(x => x.CustomerStatusType == StatusType.Show && x.IdUser == userId)
                .Include(x => x.IdCityNavigation)
                .Include(x => x.CustomerMoaref)
                .Select(x => new CustomerResponse
                {
                    BirthDayDate = x.BirthDayDate,
                    IdCustomer = x.Id,
                    From = x.DateCreated,
                    CustomerStateType = x.CustomerState,
                    CustomerStatusType = x.CustomerStatusType,
                    EmailAddress = x.EmailAddresses.FirstOrDefault().CustomerEmailAddress,
                    PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
                    Name = x.FirstName + " " + x.LastName,
                    MoshtaryMoAref = x.CustomerMoarefId,
                    Address = x.CustomerAddresses.FirstOrDefault().Address,
                    IdCity = x.IdCity,
                    Gender = x.Gender,
                    CityName = x.IdCityNavigation.CityName,
                    MoarefFullName = x.CustomerMoaref.FirstName + " " + x.CustomerMoaref.LastName
                }).ToListAsync();
            return result;
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
            var result = await _context.Customers
                .Include(x => x.PhoneNumbers)
                .Include(x => x.EmailAddresses)
                .Include(x => x.CustomerAddresses)
                .Include(x => x.IdCityNavigation)
                .FirstOrDefaultAsync(x => x.Id == customerId && x.CustomerStatusType == StatusType.Show)
                .Select(x => new CustomerResponse
                {
                    IdCustomer = x.Id,
                    Name = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
                    EmailAddress = x.EmailAddresses.FirstOrDefault().CustomerEmailAddress,
                    Address = x.CustomerAddresses.FirstOrDefault().Address,
                    CustomerStateType = x.CustomerState,
                    CustomerStatusType = x.CustomerStatusType,
                    From = x.DateCreated,
                    UpTo = DateTime.UtcNow,
                    BirthDayDate = x.BirthDayDate,
                    IdCity = x.IdCity,
                    Gender = x.Gender,
                    DateCreated = x.DateCreated,
                    MoarefFullName = x.FirstName + " " + x.LastName,
                    CityName = x.IdCityNavigation.CityName
                });
            return result;
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<int>> ShowBelghovehCustomersCountAsync()
    {
        try
        {
            return await _context.Customers.Where(x => x.CustomerState == CustomerStateTypes.Belghoveh && x.CustomerStatusType == StatusType.Show).CountAsync();
        }
        catch (Exception e)
        {
            return new Result<int>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<int>> ShowBelFelCustomersCountAsync()
    {
        try
        {
            return await _context.Customers.Where(x => x.CustomerState == CustomerStateTypes.BelFel && x.CustomerStatusType == StatusType.Show).CountAsync();
        }
        catch (Exception e)
        {
            return new Result<int>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<int>> ShowRazyCustomersCountAsync()
    {
        try
        {
            return await _context.Customers.Where(x => x.CustomerState == CustomerStateTypes.Razy && x.CustomerStatusType == StatusType.Show).CountAsync();
        }
        catch (Exception e)
        {
            return new Result<int>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<int>> ShowNaRazyCustomersCountAsync()
    {
        try
        {
            return await _context.Customers.Where(x => x.CustomerState == CustomerStateTypes.NaRazy && x.CustomerStatusType == StatusType.Show).CountAsync();
        }
        catch (Exception e)
        {
            return new Result<int>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<int>> ShowDarHalePeyGiryCustomersCountAsync()
    {
        try
        {
            return await _context.Customers.Where(x => x.CustomerState == CustomerStateTypes.DarHalePeyGiry && x.CustomerStatusType == StatusType.Show).CountAsync();
        }
        catch (Exception e)
        {
            return new Result<int>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<int>> ShowVafadarCustomersCountAsync()
    {
        try
        {
            return await _context.Customers.Where(x => x.CustomerState == CustomerStateTypes.Vafadar && x.CustomerStatusType == StatusType.Show).CountAsync();
        }
        catch (Exception e)
        {
            return new Result<int>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<int>> ShowAllCustomersCountAsync()
    {
        try
        {
            return await _context.Customers.Where(x => x.CustomerStatusType == StatusType.Show && x.CustomerStatusType == StatusType.Show).CountAsync();
        }
        catch (Exception e)
        {
            return new Result<int>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerDashboardResponse>> FilterByItemsAsync(CustomerByFilterItemsQuery request)
    {
        try
        {
            var resultsListCustomer = _context.Customers
                .Include(x => x.CustomerMoaref)
                .Include(x => x.PhoneNumbers)
                .Include(x => x.FavoritesLists)
                .Include(x => x.IdCityNavigation)
                .Select(x => new CustomerResponse
                {
                    IdCustomer = x.Id,
                    Name = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
                    EmailAddress = x.EmailAddresses.FirstOrDefault().CustomerEmailAddress,
                    Address = x.CustomerAddresses.FirstOrDefault().Address,
                    CustomerStateType = x.CustomerState,
                    CustomerStatusType = x.CustomerStatusType,
                    From = x.DateCreated,
                    UpTo = DateTime.UtcNow,
                    BirthDayDate = x.BirthDayDate,
                    IdCity = x.IdCity,
                    Gender = x.Gender,
                    DateCreated = x.DateCreated,
                    MoshtaryMoAref = x.CustomerMoaref.Id,
                    MoarefFullName = x.CustomerMoaref.FirstName + " " + x.CustomerMoaref.LastName,
                    IdUser = x.IdUserAdded,
                    CityName = x.IdCityNavigation.CityName
                }).AsQueryable();

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
                resultsListCustomer = resultsListCustomer.Where(x => x.IdCustomer == request.CustomerId);


            if (request is { CustomerState: { } })
                resultsListCustomer = resultsListCustomer.Where(x => x.CustomerStateType == request.CustomerState);

            if (request is { MoshtaryMoAref: { } })
                resultsListCustomer = resultsListCustomer.Where(x => x.MoshtaryMoAref == request.MoshtaryMoAref);

            if (request is { BirthDayDate: { } })
                resultsListCustomer = resultsListCustomer.Where(x => x.BirthDayDate == request.BirthDayDate);

            if (request is { Gender: { } })
                resultsListCustomer = resultsListCustomer.Where(x => x.Gender == request.Gender);

            if (request is { CityId: { } })
                resultsListCustomer = resultsListCustomer.Where(x => x.IdCity == request.CityId);

            //if (request is { ProductCustomerFavorite: { } })
            //{
            //    resultsListCustomer= resultsListCustomer.Where(x=>x.IdProduct=;
            //}
            // TODO: Add Favirout List

            var finalResult = await resultsListCustomer.Where(x => x.IdUser == request.UserId).ToListAsync();

            CustomerDashboardResponse result = new()
            {
                AllCustomersInfo = finalResult,
                AllCount = finalResult.Count,
                BelghovehCount = finalResult.Count(c => c.CustomerStateType == CustomerStateTypes.Belghoveh),
                BelFelCount = finalResult.Count(c => c.CustomerStateType == CustomerStateTypes.BelFel),
                RazyCount = finalResult.Count(c => c.CustomerStateType == CustomerStateTypes.Razy),
                NaRazyCount = finalResult.Count(c => c.CustomerStateType == CustomerStateTypes.NaRazy),
                DarHalePeyGiryCount = finalResult.Count(c => c.CustomerStateType == CustomerStateTypes.DarHalePeyGiry),
                VafadarCount = finalResult.Count(c => c.CustomerStateType == CustomerStateTypes.Vafadar)
            };

            return result;
        }
        catch (Exception e)
        {
            return new Result<CustomerDashboardResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerDashboardResponse>> SearchByItemsAsync(string request, string userId)
    {
        var resultsListCustomer = _context.Customers
            .Include(x => x.IdCityNavigation)
            .Where(x => x.IdUser == userId)
            .Select(x => new CustomerResponse
            {
                IdUser = x.IdUser,
                IdCustomer = x.Id,
                Name = x.FirstName + " " + x.LastName,
                PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
                EmailAddress = x.EmailAddresses.FirstOrDefault().CustomerEmailAddress,
                Address = x.CustomerAddresses.FirstOrDefault().Address,
                CityName = x.IdCityNavigation.CityName
            }).ToList();

        var result = resultsListCustomer.Where(x => x.Name.ToLower().Contains(request.ToLower())
                                                    || x.PhoneNumber.ToLower().Contains(request.ToLower())
                                                    || x.EmailAddress.ToLower().Contains(request.ToLower()));

        return new CustomerDashboardResponse
        {
            AllCustomersInfo = result.ToList(),
            AllCount = resultsListCustomer.Count,
            BelghovehCount = resultsListCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.Belghoveh),
            BelFelCount = resultsListCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.BelFel),
            RazyCount = resultsListCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.Razy),
            NaRazyCount = resultsListCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.NaRazy),
            DarHalePeyGiryCount = resultsListCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.DarHalePeyGiry),
            VafadarCount = resultsListCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.Vafadar)
        };
    }

    public async ValueTask<Result<CustomerResponse>> ChangeStatusCustomerByIdAsync(ChangeStatusCustomerCommand request)
    {
        try
        {
            var item = await _context.Customers.FindAsync(request.CustomerId);
            if (item is null) return new Result<CustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerStatusType = request.CustomerStatusType;
            await _context.SaveChangesAsync();
            return new Result<CustomerResponse>(
                await _context.Customers
                .Include(x => x.IdCityNavigation)
                .FirstOrDefaultAsync(x => x.Id == request.CustomerId)
                .Select(x => new CustomerResponse
                {
                    BirthDayDate = x.BirthDayDate,
                    IdCustomer = x.Id,
                    From = x.DateCreated,
                    CustomerStateType = x.CustomerState,
                    CustomerStatusType = x.CustomerStatusType,
                    Name = x.FirstName + " " + x.LastName,
                    IdCity = x.IdCity,
                    Gender = x.Gender,
                    CityName = x.IdCityNavigation.CityName
                }));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerResponse>> ChangeStateCustomerByIdAsync(ChangeStateCustomerCommand request)
    {
        try
        {
            var item = await _context.Customers.FindAsync(request.CustomerId);
            if (item is null) return new Result<CustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerState = request.CustomerStateType;
            await _context.SaveChangesAsync();
            return new Result<CustomerResponse>(
                await _context.Customers
                    .Include(x => x.IdCityNavigation)
                    .FirstOrDefaultAsync(x => x.Id == request.CustomerId)
                    .Select(x => new CustomerResponse
                    {
                        BirthDayDate = x.BirthDayDate,
                        IdCustomer = x.Id,
                        From = x.DateCreated,
                        CustomerStateType = x.CustomerState,
                        CustomerStatusType = x.CustomerStatusType,
                        Name = x.FirstName + " " + x.LastName,
                        IdCity = x.IdCity,
                        Gender = x.Gender,
                        CityName = x.IdCityNavigation.CityName
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
            if (await _context.Customers.AnyAsync(x => x.PhoneNumbers.Any(p => request.PhoneNumbers != null && p.PhoneNo == request.PhoneNumbers.FirstOrDefault())))
            {
                return new Result<CustomerResponse>(new ValidationException("کابری با این شماره تلفن قبلا ثبت شده است"));
            }

            var entityEntry = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDayDate = request.BirthDayDate!,
                CustomerPic = request.CustomerPic,
                CustomerMoarefId = request.CustomerMoarefId,
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

            //CustomerResponse returnItem = new()
            //{
            //    BirthDayDate = entityEntry.BirthDayDate,
            //    IdCustomer = entityEntry.Id,
            //    From = entityEntry.DateCreated,
            //    CustomerStateType = entityEntry.CustomerState,
            //    CustomerStatusType = entityEntry.CustomerStatusType,
            //    MoshtaryMoAref = entityEntry.CustomerMoarefId,
            //    // CustomerCategoryId = entityEntry.CustomerCategoryId,
            //    EmailAddress = entityEntry.EmailAddresses.FirstOrDefault()!.CustomerEmailAddress,
            //    PhoneNumber = entityEntry.PhoneNumbers.FirstOrDefault()!.PhoneNo,
            //    FirstName = entityEntry.FirstName,
            //    LastName = entityEntry.LastName,
            //    Address = entityEntry.CustomerAddresses.FirstOrDefault()!.Address,
            //    IdCity = entityEntry.IdCity,
            //    Gender = entityEntry.Gender
            //};

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = entityEntry.Id,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.InsertCustomer,
                UserId = request.IdUserAdded,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            return new Result<CustomerResponse>(
                await _context.Customers
                    .Include(x => x.IdCityNavigation)
                    .FirstOrDefaultAsync(x => x.Id == entityEntry.Id)
                .Select(x => new CustomerResponse
                {
                    BirthDayDate = x.BirthDayDate,
                    IdCustomer = x.Id,
                    From = x.DateCreated,
                    CustomerStateType = x.CustomerState,
                    CustomerStatusType = x.CustomerStatusType,
                    EmailAddress = x.EmailAddresses.FirstOrDefault().CustomerEmailAddress,
                    PhoneNumber = x.PhoneNumbers.FirstOrDefault().PhoneNo,
                    Name = x.FirstName + " " + x.LastName,
                    Address = x.CustomerAddresses.FirstOrDefault().Address,
                    IdCity = x.IdCity,
                    Gender = x.Gender,
                    CityName = x.IdCityNavigation.CityName
                }));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new ValidationException(e.Message));
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

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = request.Id,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.UpdateCustomer,
                UserId = request.UserId,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);



            return new Result<CustomerResponse>(new CustomerResponse
            {
                IdCustomer = customer.Id,
                Name = customer.FirstName + " " + customer.LastName,
                PhoneNumber = customer.PhoneNumbers.FirstOrDefault().ToString(),
                EmailAddress = customer.EmailAddresses.FirstOrDefault().ToString(),
                IdCity = customer.IdCity,
                MoshtaryMoAref = customer.CustomerMoarefId,
                BirthDayDate = customer.BirthDayDate,
                CustomerStateType = customer.CustomerState,
                CustomerStatusType = customer.CustomerStatusType,
                Address = customer.CustomerAddresses.FirstOrDefault().Address,
                Gender = customer.Gender,
                CityName = customer.IdCityNavigation.CityName
            });
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }

    public async ValueTask<Result<CustomerResponse>> DeleteCustomerAsync(Ulid customerId)
    {
        try
        {
            var customer = await _context.Customers.FindAsync(customerId);
            customer!.CustomerStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = customerId,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = null,
                Type = LogTypes.DeleteCustomer,
                UserId = "request.IdUserAdded",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            return new Result<CustomerResponse>(
                await _context.Customers
                    .Include(x => x.IdCityNavigation)
                    .FirstOrDefaultAsync(x => x.Id == customerId)
                    .Select(x => new CustomerResponse
                    {
                        BirthDayDate = x.BirthDayDate,
                        IdCustomer = x.Id,
                        From = x.DateCreated,
                        CustomerStateType = x.CustomerState,
                        CustomerStatusType = x.CustomerStatusType,
                        Name = x.FirstName + " " + x.LastName,
                        IdCity = x.IdCity,
                        Gender = x.Gender,
                        CityName = x.IdCityNavigation.CityName
                    }));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new ValidationException(e.Message));
        }
    }
}