using Application.Responses.Customer.Foroosh;

namespace DataAccess.Repositories.Customers.Foroosh;

public class ForooshFactorRepository : IForooshFactorRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    // TODO: user id should be passed
    public ForooshFactorRepository(MaadContext context, ILogRepository log)
    {
        _context = context;
        _log = log;
    }

    public async ValueTask<Result<ICollection<ForooshFactor>>> GetAllForooshFactorsAsync()
    {
        try
        {
            return new Result<ICollection<ForooshFactor>>(await _context.ForooshFactors
                .Where(x => x.StatusTypeForooshFactor == StatusType.Show)
                .OrderBy(x => x.DatePayed)
                .ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<ForooshFactor>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshFactor>> GetForooshFactorByIdAsync(Ulid ForooshFactorId)
    {
        try
        {
            return new Result<ForooshFactor>(await _context.ForooshFactors
                .OrderBy(x => x.DatePayed)
                .SingleOrDefaultAsync(x => x.Id == ForooshFactorId && x.StatusTypeForooshFactor == StatusType.Show));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<FactorInformationResponse>>> ShowAllFactorInformationByForooshFactorIdAsync(Ulid ForooshFactorId)
    {
        try
        {
            var result = _context.ForooshFactors
                .Include(x => x.Payments)
                .Include(x => x.ForooshOrders)
                .ThenInclude(x => x.IdProductNavigation)
                .Include(x => x.IdCustomerNavigation)
                .Include(x => x.IdCustomerAddressNavigation)
                .Where(x => x.Id == ForooshFactorId && x.StatusTypeForooshFactor == StatusType.Show)
                .Select(x => new FactorInformationResponse
                {
                    IdProduct = x.ForooshOrders.FirstOrDefault().IdProduct,
                    PaymentStatusType = x.Payments.FirstOrDefault().PaymentStatusType,
                    ShippingMethodType = x.ShippingMethodType.Value,
                    AmountTax = x.AmountTax,
                    PaymentMethod = x.PaymentMethod,
                    PaymentAmount = x.Payments.FirstOrDefault().PaymentAmount,
                    Amount = x.Amount,
                    AmountTotal = x.AmountTotal,
                    TedadeAghsat = x.TedadeAghsat,
                    PishPardakht = x.PishPardakht,
                    IdCustomer = x.IdCustomerNavigation.Id,
                    CustomerFullName = x.IdCustomerNavigation.FirstName + " " + x.IdCustomerNavigation.LastName,
                    IdCustomerAddress = x.IdCustomerAddressNavigation.Id,
                    CustomerAddress = x.IdCustomerAddressNavigation.Address,
                    ShoroAghsat = x.ShoroAghsat,
                    BazeyeZamany = x.BazeyeZamany,
                    DarSadeSoud = x.DarSadeSoud,
                    DatePayed = x.DatePayed,
                    IdFactorForoosh = x.Id,
                    MablagheKoleSoud = x.MablagheKoleSoud,
                    Price = x.ForooshOrders.FirstOrDefault().Price,
                    PriceDiscount = x.ForooshOrders.FirstOrDefault().PriceDiscount,
                    PriceShipping = x.ForooshOrders.FirstOrDefault().PriceShipping,
                    PriceTotal = x.ForooshOrders.FirstOrDefault().PriceTotal,
                    StatusTypeForooshFactor = x.StatusTypeForooshFactor,
                    Tedad = x.ForooshOrders.FirstOrDefault().Tedad,
                })
                .AsQueryable();
            return await result.OrderBy(x => x.DatePayed).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<FactorInformationResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshFactor>> ChangeStatusForooshFactorByIdAsync(ChangeStatusForooshFactorCommand request)
    {
        try
        {
            var item = await _context.ForooshFactors.FindAsync(request.Id);
            if (item is null) return new Result<ForooshFactor>(new ValidationException(ResultErrorMessage.NotFound));
            item.StatusTypeForooshFactor = request.ForooshFactorStatusType;
            await _context.SaveChangesAsync();

            return item;
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<FactorInformationResponse>> CreateForooshFactorAsync(CreateForooshFactorCommand request)
    {
        try
        {
            ForooshFactor item = new()
            {
                Amount = request.Amount,
                AmountTax = request.AmountTax,
                PaymentMethod = request.PaymentMethod,
                ShippingMethodType = request.ShippingMethodType,
                IdCustomer = request.CustomerId,
                IdCustomerAddress = request.CustomersAddressId,
                IdUserAdded = request.UserIdAdded,
                IdUserUpdated = request.UserIdUpdated,
                AmountTotal = request.Amount + request.AmountTax,
                DatePayed = DateTime.UtcNow
            };

            // if (request.PaymentMethod is PaymentMethodTypes.OnCredit)
            // {
            //     item.TedadeAghsat = request.TedadeAghsat;
            //     item.BazeyeZamany = request.BazeyeZamany;
            //     item.DarSadeSoud = request.DarSadeSoud;
            //     item.PishPardakht = request.PishPardakht;
            //     item.MablagheKoleSoud = request.MablagheKoleSoud;
            //     item.ShoroAghsat = request.ShoroAghsat;
            // }

            await _context.ForooshFactors.AddAsync(item);
            await _context.SaveChangesAsync();

            // if (request.PaymentMethod is PaymentMethodTypes.OnCredit)
            // {
            //     Payment payment = new()
            //     {
            //         PaymentAmount = request.PishPardakht.Value,
            //         IdForooshFactor = item.Id,
            //         DatePay = DateTime.UtcNow
            //     };
            //
            //     await _context.Payments.AddAsync(payment);
            //
            //     var paymentAmount = (request.AmountTotal + request.MablagheKoleSoud - request.PishPardakht) /
            //                         request.TedadeAghsat;
            //     var paymentDate = request.ShoroAghsat;
            //     // ToDo : Payment
            //     for (var i = 0; i < request.TedadeAghsat; i++)
            //     {
            //         payment = new Payment
            //         {
            //             PaymentAmount = paymentAmount.Value,
            //             IdForooshFactor = item.Id,
            //             DatePay = paymentDate.Value
            //         };
            //         await _context.Payments.AddAsync(payment);
            //
            //         paymentDate = paymentDate.Value.AddDays(request.BazeyeZamany.Value);
            //     }
            // }
            // else
            // {
            //     Payment payment = new()
            //     {
            //         PaymentAmount = request.AmountTotal,
            //         IdForooshFactor = item.Id,
            //         DatePay = DateTime.UtcNow
            //     };
            //
            //     await _context.Payments.AddAsync(payment);
            // }
            //
            // await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = item.Id,
                Type = LogTypes.InsertForoosh,
                UserId = request.UserIdAdded,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            var result = await _context.ForooshFactors
                .Select(x => new FactorInformationResponse
                {
                    // ShippingMethodType = x.ShippingMethodType.Value,
                    AmountTax = x.AmountTax,
                    PaymentMethod = x.PaymentMethod,
                    //PaymentAmount = x.Payments.FirstOrDefault().PaymentAmount,
                    Amount = x.Amount,
                    AmountTotal = x.AmountTotal,
                    TedadeAghsat = x.TedadeAghsat,
                    PishPardakht = x.PishPardakht,
                    //CustomerFullName = x.IdCustomerNavigation.FirstName + " " + x.IdCustomerNavigation.LastName,
                    //CustomerAddress = x.IdCustomerAddressNavigation.Address,
                    ShoroAghsat = x.ShoroAghsat,
                    BazeyeZamany = x.BazeyeZamany,
                    DarSadeSoud = x.DarSadeSoud,
                    DatePayed = x.DatePayed,
                    IdFactorForoosh = x.Id,
                    MablagheKoleSoud = x.MablagheKoleSoud,
                    StatusTypeForooshFactor = x.StatusTypeForooshFactor,
                    //Price = x.ForooshOrders.FirstOrDefault().Price,
                    //PriceDiscount = x.ForooshOrders.FirstOrDefault().PriceDiscount,
                    //PriceShipping = x.ForooshOrders.FirstOrDefault().PriceShipping,
                    //PriceTotal = x.ForooshOrders.FirstOrDefault().PriceTotal,
                    //Tedad = x.ForooshOrders.FirstOrDefault().Tedad,
                }).OrderBy(x => x.DatePayed).SingleOrDefaultAsync(x => x.IdFactorForoosh == item.Id);

            return new Result<FactorInformationResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<FactorInformationResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshFactor>> UpdateForooshFactorAsync(UpdateForooshFactorCommand request)
    {
        try
        {
            ForooshFactor item = await _context.ForooshFactors.FindAsync(request.Id);

            item.Amount = request.Amount;
            item.AmountTax = request.AmountTax;
            item.AmountTotal = request.AmountTotal;
            item.PaymentMethod = request.PaymentMethod;
            item.ShippingMethodType = request.ShippingMethodType;

            if (request.PaymentMethod == PaymentMethodTypes.OnCredit)
            {
                item.TedadeAghsat = request.TedadeAghsat;
                item.BazeyeZamany = request.BazeyeZamany;
                item.DarSadeSoud = request.DarSadeSoud;
                item.PishPardakht = request.PishPardakht;
                item.MablagheKoleSoud = request.MablagheKoleSoud;
                item.ShoroAghsat = request.ShoroAghsat;
            }

            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = request.Id,
                Type = LogTypes.UpdateForoosh,
                UserId = "IdUser",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            return item;
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshFactor>> DeleteForooshFactorAsync(Ulid id)
    {
        try
        {
            var ForooshFactor = await _context.ForooshFactors.FindAsync(id);
            ForooshFactor!.StatusTypeForooshFactor = StatusType.Deleted;
            await _context.SaveChangesAsync();

            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = id,
                Type = LogTypes.DeleteForoosh,
                UserId = "IdUser",
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            return ForooshFactor;
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new ValidationException(e.Message));
        }
    }
}