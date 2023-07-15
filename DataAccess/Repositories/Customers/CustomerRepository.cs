using Application.Responses.SpecialFields;

namespace DataAccess.Repositories.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;
    private readonly UserManager<User> _userManager;

    public CustomerRepository(MaadContext maadContext, ILogRepository log, UserManager<User> userManager)
    {
        _context = maadContext;
        _log = log;
        _userManager = userManager;
    }

    public async ValueTask<Result<ICollection<CustomerResponse>>> GetAllCustomersAsync(string userId)
    {
        try
        {
            return new Result<ICollection<CustomerResponse>>(
                await _context.Customers
                    .Where(x => x.CustomerStatusType == StatusType.Show && x.IdUser == userId)
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
                        MoshtaryMoAref = x.IdMoaref,
                        Address = x.CustomerAddresses.FirstOrDefault().Address,
                        IdCity = x.IdCity,
                        CityName = x.IdCityNavigation != null ? x.IdCityNavigation!.CityName : null,
                        IdProvince = x.IdCityNavigation != null ? x.IdCityNavigation.IdProvince : new Ulid(),
                        ProvinceName = x.IdCityNavigation != null
                            ? x.IdCityNavigation.IdProvinceNavigation.ProvinceName
                            : null,
                        Gender = x.Gender,
                        MoarefFullName = x.IdMoarefNavigation.FirstName + " " + x.IdMoarefNavigation.LastName,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        MoarefPhoneNumber = x.IdMoarefNavigation.PhoneNumbers.FirstOrDefault().PhoneNo,
                        ProductName = x.IdCityNavigation.IdProvinceNavigation.ProvinceName
                    }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerResponse>> GetCustomerByIdAsync(Ulid customerId, string userId)
    {
        try
        {
            var resultUser = await _userManager.FindByIdAsync(userId);
            if (resultUser == null)
                return new Result<CustomerResponse>(new ValidationException("کاربری با این مشخصات یافت نشد"));
            
            var resultBusiness = await _context.Businesses.FindAsync(resultUser.IdBusiness);
            if (resultBusiness == null)
                return new Result<CustomerResponse>(new ValidationException("کسب و کاری با این مشخصات یافت نشد"));
            
            var resultCustomer = await _context.Customers
                .Where(x => x.CustomerStatusType == StatusType.Show && x.Id == customerId && x.IdUser == userId)
                .Select(x =>
                    new CustomerResponse
                    {
                        IdCustomer = x.Id,
                        Name = x.FirstName + " " + x.LastName,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        PhoneNumber = x.PhoneNumbers!.FirstOrDefault()!.PhoneNo,
                        EmailAddress = x.EmailAddresses!.FirstOrDefault()!.CustomerEmailAddress,
                        Address = x.CustomerAddresses!.FirstOrDefault()!.Address,
                        CustomerStateType = x.CustomerState,
                        CustomerStatusType = x.CustomerStatusType,
                        From = x.DateCreated,
                        UpTo = DateTime.UtcNow,
                        BirthDayDate = x.BirthDayDate,
                        IdCity = x.IdCity,
                        CityName = x.IdCityNavigation != null ? x.IdCityNavigation!.CityName : null,
                        IdProvince = x.IdCityNavigation != null ? x.IdCityNavigation.IdProvince : new Ulid(),
                        ProvinceName = x.IdCityNavigation != null
                            ? x.IdCityNavigation.IdProvinceNavigation.ProvinceName
                            : null,
                        Gender = x.Gender,
                        DateCreated = x.DateCreated,
                        MoshtaryMoAref = x.IdMoaref,
                        MoarefFullName = x.IdMoarefNavigation!.FirstName + " " + x.IdMoarefNavigation!.LastName,
                        IdUser = x.IdUser
                    }).FirstOrDefaultAsync();
            
            resultCustomer.Attributes = await _context
                .Attributes
                .Where(w => w.Status == StatusType.Show && w.AttributeTypeId == AttributeType.Customer && w.IdBusiness == resultBusiness!.Id )
                .Select(x => new AttributeCustomerResponse
                {
                    Id = x.Id,
                    Label = x.Label,
                    DisplayOrder = x.DisplayOrder,
                    IsRequired = x.IsRequired,
                    InputType = x.AttributeInputTypeId,
                    Type = x.AttributeTypeId,
                    ValidationMinLength = x.ValidationMinLength,
                    ValidationMaxLength = x.ValidationMaxLength,
                    ValidationFileAllowExtension = x.ValidationFileAllowExtension,
                    ValidationFileMaximumSize = x.ValidationFileMaximumSize,
                    DefaultValue = x.DefaultValue,
                    IdBusiness = x.IdBusiness,
                    AttributeOptions = x.AttributeOptions!.Select(s => new AttributeCustomerOptionsResponse
                    {
                        Id = s.Id,
                        Title = s.Title,
                        ColorSquaresRgb = s.ColorSquaresRgb,
                        DisplayOrder = s.DisplayOrder,
                        Status = s.Status,
                        Value = s.CustomerAttributes!
                            .Where(w => w.Status == StatusType.Show && w.IdCustomer == resultCustomer.IdCustomer && w.IdAttributeOption == s.Id).Select(v =>
                                new AttributeCustomerValueResponse
                                {
                                    Id = v.Id,
                                    Status = v.Status,
                                    ValueString = v.ValueString,
                                    FilePath = v.FilePath,
                                    ValueNumber = v.ValueNumber,
                                    ValueBool = v.ValueBool,
                                    ValueDate = v.ValueDate,
                                    IdCustomer = v.IdCustomer
                                }).ToList()
                    }).ToList()
                }).ToListAsync();

            return new Result<CustomerResponse>(resultCustomer);
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new ValidationException(e.Message));
        }
    }
    
    private async ValueTask<int> ShowAllCustomersCountAsync(string userId)
    {
        try
        {
            return await _context.Customers
                .Where(x => x.CustomerStatusType == StatusType.Show)
                .CountAsync();
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public async ValueTask<Result<CustomerDashboardResponse>> FilterByItemsAsync(CustomerByFilterItemsQuery request)
    {
        try
        {
            var resultsListCustomer = _context.Customers
                .Where(x => x.CustomerStatusType == StatusType.Show && x.IdUser == request.UserId)
                .Select(x => new CustomerResponse
                {
                    IdCustomer = x.Id,
                    Name = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    EmailAddress = x.EmailAddresses!.FirstOrDefault()!.CustomerEmailAddress,
                    Address = x.CustomerAddresses!.FirstOrDefault()!.Address,
                    CustomerStateType = x.CustomerState,
                    CustomerStatusType = x.CustomerStatusType,
                    From = x.DateCreated,
                    UpTo = DateTime.UtcNow,
                    BirthDayDate = x.BirthDayDate,
                    IdCity = x.IdCity,
                    CityName = x.IdCityNavigation != null ? x.IdCityNavigation!.CityName : null,
                    IdProvince = x.IdCityNavigation != null ? x.IdCityNavigation.IdProvince : new Ulid(),
                    ProvinceName = x.IdCityNavigation != null
                        ? x.IdCityNavigation.IdProvinceNavigation.ProvinceName
                        : null,
                    Gender = x.Gender,
                    DateCreated = x.DateCreated,
                    MoshtaryMoAref = x.IdMoaref,
                    MoarefFullName = x.IdMoarefNavigation!.FirstName + " " + x.IdMoarefNavigation.LastName,
                    IdUser = x.IdUser,
                }).AsQueryable();

            resultsListCustomer = request switch
            {
                { From: not null, UpTo: not null } => resultsListCustomer.Where(x =>
                    x.DateCreated < request.UpTo && x.DateCreated > request.From),
                { From: not null } => resultsListCustomer.Where(x => x.DateCreated > request.From),
                { UpTo: not null } => resultsListCustomer.Where(x => x.DateCreated < request.UpTo),
                _ => resultsListCustomer
            };

            if (!request.CustomerId.ToString().IsNullOrEmpty())
                resultsListCustomer = resultsListCustomer.Where(x => x.IdCustomer == request.CustomerId);


            if (request is { CustomerState: not null })
                resultsListCustomer = resultsListCustomer.Where(x => x.CustomerStateType == request.CustomerState);

            if (request is { MoshtaryMoAref: not null })
                resultsListCustomer = resultsListCustomer.Where(x => x.MoshtaryMoAref == request.MoshtaryMoAref);

            if (request is { BirthDayDate: not null })
                resultsListCustomer = resultsListCustomer.Where(x => x.BirthDayDate == request.BirthDayDate);

            if (request is { Gender: not null })
                resultsListCustomer = resultsListCustomer.Where(x => x.Gender == request.Gender);

            if (request is { CityId: not null })
                resultsListCustomer = resultsListCustomer.Where(x => x.IdCity == request.CityId);

            // //if (request is { ProductCustomerFavorite: { } })
            // //{
            // //    resultsListCustomer= resultsListCustomer.Where(x=>x.IdProduct=;
            // //}
            // // TODO: Add Favirout List

            var finalResult = await resultsListCustomer.Where(x => x.IdUser == request.UserId).ToListAsync();

            var resultsCountCustomer = await _context.Customers
                .Where(x => x.CustomerStatusType == StatusType.Show && x.IdUser == request.UserId)
                .Select(x => new CustomerResponse
                {
                    IdCustomer = x.Id,
                    CustomerStateType = x.CustomerState,
                    CustomerStatusType = x.CustomerStatusType,
                }).ToListAsync();

            CustomerDashboardResponse result = new()
            {
                AllCustomersInfo = finalResult,
                AllCount = resultsCountCustomer.Count,
                BelghovehCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.Belghoveh),
                BelFelCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.BelFel),
                RazyCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.Razy),
                NaRazyCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.NaRazy),
                DarHalePeyGiryCount =
                    resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.DarHalePeyGiry),
                VafadarCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.Vafadar)
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
        try
        {
            var resultsListCustomer = await _context.Customers
                .Where(x => x.CustomerStatusType == StatusType.Show && x.IdUser == userId)
                .Where(x =>
                    (x.FirstName + " " + x.LastName).ToLower().Contains(request.ToLower()) ||
                    x.PhoneNumbers!.FirstOrDefault()!.PhoneNo.ToLower().Contains(request.ToLower()) ||
                    x.EmailAddresses!.FirstOrDefault()!.CustomerEmailAddress.ToLower().Contains(request.ToLower()))
                .Select(x => new CustomerResponse
                {
                    IdCustomer = x.Id,
                    Name = x.FirstName + " " + x.LastName,
                    PhoneNumber = x.PhoneNumbers!.FirstOrDefault()!.PhoneNo,
                    EmailAddress = x.EmailAddresses!.FirstOrDefault()!.CustomerEmailAddress,
                    Address = x.CustomerAddresses!.FirstOrDefault()!.Address,
                    CustomerStateType = x.CustomerState,
                    CustomerStatusType = x.CustomerStatusType,
                    From = x.DateCreated,
                    UpTo = DateTime.UtcNow,
                    BirthDayDate = x.BirthDayDate,
                    IdCity = x.IdCity,
                    CityName = x.IdCityNavigation != null ? x.IdCityNavigation!.CityName : null,
                    IdProvince = x.IdCityNavigation != null ? x.IdCityNavigation.IdProvince : new Ulid(),
                    ProvinceName = x.IdCityNavigation != null
                        ? x.IdCityNavigation.IdProvinceNavigation.ProvinceName
                        : null,
                    Gender = x.Gender,
                    DateCreated = x.DateCreated,
                    MoshtaryMoAref = x.IdMoaref,
                    MoarefFullName = x.IdMoarefNavigation!.FirstName + " " + x.IdMoarefNavigation.LastName,
                    IdUser = x.IdUser,
                }).ToListAsync();

            var resultAll = await ShowAllCustomersCountAsync(userId);

            var resultsCountCustomer = await _context.Customers
                .Where(x => x.CustomerStatusType == StatusType.Show && x.IdUser == userId)
                .Select(x => new CustomerResponse
                {
                    IdCustomer = x.Id,
                    CustomerStateType = x.CustomerState,
                    CustomerStatusType = x.CustomerStatusType,
                }).ToListAsync();

            return new Result<CustomerDashboardResponse>(new CustomerDashboardResponse
            {
                AllCustomersInfo = resultsListCustomer,
                AllCount = resultsCountCustomer.Count,
                BelghovehCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.Belghoveh),
                BelFelCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.BelFel),
                RazyCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.Razy),
                NaRazyCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.NaRazy),
                DarHalePeyGiryCount =
                    resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.DarHalePeyGiry),
                VafadarCount = resultsCountCustomer.Count(c => c.CustomerStateType == CustomerStateTypes.Vafadar)
            });
        }
        catch (Exception e)
        {
            return new Result<CustomerDashboardResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerResponse>> ChangeStatusCustomerByIdAsync(ChangeStatusCustomerCommand request)
    {
        try
        {
            var item = await _context.Customers.FindAsync(request.CustomerId);
            if (item is null) return new Result<CustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerStatusType = request.CustomerStatusType;
            await _context.SaveChangesAsync();

            return await GetCustomerByIdAsync(request.CustomerId, request.UserId);
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

            return await GetCustomerByIdAsync(request.CustomerId, request.UserId);
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
            var user = await _context.Users.FindAsync(request.UserId);
            if (user is null) return new Result<CustomerResponse>(new ValidationException(ResultErrorMessage.NotFound));

            if (await _context.Customers.AnyAsync(x => x.IdUserNavigation.IdBusiness == user.IdBusiness &&
                                                       x.PhoneNumbers.Any(p =>
                                                           request.PhoneNumbers != null && p.PhoneNo ==
                                                           request.PhoneNumbers.FirstOrDefault())))
                return new Result<CustomerResponse>(
                    new ValidationException("کابری با این شماره تلفن قبلا ثبت شده است"));

            var entityEntry = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDayDate = request.BirthDayDate!,
                CustomerPic = request.CustomerPic,
                IdMoaref = request.CustomerMoarefId,
                IdUser = request.UserId,
                Gender = request.Gender,
                IdCity = request.CityId,
                IdUserUpdated = request.IdUserAdded,
                IdUserAdded = request.IdUserAdded
            };

            await _context.Customers!.AddAsync(entityEntry);
            var result = await _context.SaveChangesAsync();
            if (result == 0) return new Result<CustomerResponse>(new ValidationException());

            if (request.AttributesValue is not null)
            {
                foreach (var attribute in request.AttributesValue)
                {
                    var item = new AttributeCustomer
                    {
                        IdAttributeOption = attribute.IdAttributeOption,
                        IdCustomer = entityEntry.Id,
                        Status = StatusType.Show,
                        ValueString = attribute.ValueString,
                        ValueNumber = attribute.ValueNumber,
                        ValueBool = attribute.ValueBool,
                        ValueDate = attribute.ValueDate,
                        FilePath = attribute.FilePath
                    };
                    await _context.AttributesCustomer.AddAsync(item);
                }
            }
            
            
            if (request.PhoneNumbers != null)
                foreach (var phoneNumbers in request.PhoneNumbers)
                {
                    CustomersPhoneNumber newPhone = new()
                    {
                        IdCustomer = entityEntry.Id,
                        PhoneNo = phoneNumbers,
                        PhoneType = PhoneTypes.Phone
                    };

                    await _context.CustomersPhoneNumbers.AddAsync(newPhone);
                }

            if (request.CustomersAddresses != null)
                foreach (var address in request.CustomersAddresses)
                {
                    CustomerAddress newAddress = new()
                    {
                        IdCustomer = entityEntry.Id,
                        Address = address
                    };

                    await _context.CustomersAddresses.AddAsync(newAddress);
                }

            if (request.CustomerPeyGiries != null)
                foreach (var peyGiry in request.CustomerPeyGiries)
                {
                    CustomerPeyGiry newPeyGiry = new()
                    {
                        IdCustomer = entityEntry.Id,
                        Description = peyGiry
                    };

                    await _context.CustomerPeyGiries.AddAsync(newPeyGiry);
                }

            if (request.CustomerNotes != null)
                foreach (var note in request.CustomerNotes)
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

            return await GetCustomerByIdAsync(entityEntry.Id, request.UserId);
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
            var user = await _context.Users.FindAsync(request.UserId);
            if (user is null) return new Result<CustomerResponse>(new Exception("کاربری با این مشخصات یافت نشد"));

            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.IdUserNavigation.IdBusiness == user.IdBusiness &&
                                                                            x.PhoneNumbers.Any(p =>
                                                                                request.PhoneNumbers != null && p.PhoneNo ==
                                                                                request.PhoneNumbers.FirstOrDefault()));
                
            if (customer == null)
                return new Result<CustomerResponse>(new Exception("مشتری با این شماره تلفن یافت نشد"));

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.BirthDayDate = request.BirthDayDate!;
            customer.IdMoaref = request.CustomerMoarefId;
            customer.IdCity = request.CityId;
            customer.Gender = request.Gender;
            customer.IdUserUpdated = request.UserId;

            if (request.CustomersAddresses != null)
            {
                var resultAddress =
                    await _context.CustomersAddresses.FirstOrDefaultAsync(x => x.IdCustomer == request.Id);
                if (resultAddress != null) resultAddress.Address = request.CustomersAddresses.FirstOrDefault();
            }


            if (request.PhoneNumbers != null)
            {
                var phoneNumber =
                    await _context.CustomersPhoneNumbers.FirstOrDefaultAsync(x => x.IdCustomer == request.Id);
                if (phoneNumber != null) phoneNumber.PhoneNo = request.PhoneNumbers.FirstOrDefault();
            }

            if (request.EmailAddresses != null)
            {
                var emailAddress =
                    await _context.CustomersEmailAddresses.FirstOrDefaultAsync(x => x.IdCustomer == request.Id);
                if (emailAddress != null) emailAddress.CustomerEmailAddress = request.EmailAddresses.FirstOrDefault();
            }

            if (request.AttributesValue is not null)
            {
                foreach (var attribute in request.AttributesValue)
                {
                    var find = await _context.AttributesCustomer.FirstOrDefaultAsync(w => w.IdCustomer == customer.Id && w.IdAttributeOption == attribute.IdAttributeOption);
                    if (find is not null)
                    {
                        find.ValueDate = attribute.ValueDate;
                        find.ValueBool = attribute.ValueBool;
                        find.ValueNumber = attribute.ValueNumber;
                        find.ValueString = attribute.ValueString;
                        find.FilePath = attribute.FilePath;
                    }
                    else
                    {
                        var item = new AttributeCustomer
                        {
                            IdAttributeOption = attribute.IdAttributeOption,
                            IdCustomer = customer.Id,
                            Status = StatusType.Show,
                            ValueString = attribute.ValueString,
                            ValueNumber = attribute.ValueNumber,
                            ValueBool = attribute.ValueBool,
                            ValueDate = attribute.ValueDate,
                            FilePath = attribute.FilePath
                        };
                        await _context.AttributesCustomer.AddAsync(item);
                    }
                }
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

            return await GetCustomerByIdAsync(customer.Id, request.UserId);
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }

    public async ValueTask<string> DeleteCustomerAsync(Ulid customerId)
    {
        try
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
                return "Error.";

            customer.CustomerStatusType = StatusType.Deleted;
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

            return "Customer Deleted.";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}