namespace DataAccess.Repositories.Customers.Foroosh;

public class PaymentRepository : IPaymentRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    public PaymentRepository(MaadContext context, ILogRepository log)
    {
        _context = context;
        _log = log;
    }


    public async ValueTask<Result<ICollection<Payment>>> GetAllPaymentsAsync()
    {
        try
        {
            return await _context.Payments.Where(x => x.PaymentStatusType == StatusType.Show).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<Payment>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Payment>> GetPaymentByIdAsync(Ulid paymentId)
    {
        try
        {
            return await _context.Payments.SingleOrDefaultAsync(x => x.Id == paymentId && x.PaymentStatusType == StatusType.Show);
        }
        catch (Exception e)
        {
            return new Result<Payment>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Payment>> ChangeStatusPaymentByIdAsync(ChangeStatusPaymentCommand request)
    {
        try
        {
            var item = await _context.Payments.FindAsync(request.Id);
            if (item is null) return new Result<Payment>(new ValidationException(ResultErrorMessage.NotFound));
            item.PaymentStatusType = request.PaymentStatusType;
            await _context.SaveChangesAsync();

            return item;
        }
        catch (Exception e)
        {
            return new Result<Payment>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Payment>> CreatePaymentAsync(CreatePaymentCommand request)
    {
        try
        {
            Payment item = new()
            {
                DatePay = request.DatePay,
                PaymentAmount = request.PaymentAmount,
                IdForooshFactor = request.IdForooshFactor
            };
            await _context.Payments.AddAsync(item!);
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<Payment>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Payment>> UpdatePaymentAsync(UpdatePaymentCommand request)
    {
        try
        {
            Payment item = await _context.Payments.FindAsync(request.Id);

            item.PaymentAmount = request.PaymentAmount;

            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<Payment>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<Payment>> DeletePaymentAsync(Ulid paymentId)
    {
        try
        {
            var item = await _context.Payments.FindAsync(paymentId);
            item.PaymentStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<Payment>(new ValidationException(e.Message));
        }
    }
    
    public async ValueTask<Result<SavePaymentResponse>> SavePaymentsAsync(SavePaymentCommand request)
    {
        try
        {
            var item = await _context.ForooshFactors.FindAsync(request.IdFactor);
            if (item is null) return new Result<SavePaymentResponse>(new ValidationException("شماره فاکتور اشتباه است")); ;

            item.Amount = request.Amount;
            item.AmountTax = request.AmountTax;
            item.PaymentMethod = request.PaymentMethod;
            item.ShippingMethodType = request.ShippingMethodType;
            item.IdCustomer = request.CustomerId;
            item.IdCustomerAddress = request.CustomersAddressId;
            item.IdUserAdded = request.UserIdAdded;
            item.IdUserUpdated = request.UserIdUpdated;
            item.AmountTotal = request.Amount + request.AmountTax;
            item.DatePayed = DateTime.UtcNow;

            if (request.PaymentMethod is PaymentMethodTypes.OnCredit)
            {
                item.TedadeAghsat = request.TedadeAghsat;
                item.BazeyeZamany = request.BazeyeZamany;
                item.DarSadeSoud = request.DarSadeSoud;
                item.PishPardakht = request.PishPardakht;
                item.MablagheKoleSoud = request.MablagheKoleSoud;
                item.ShoroAghsat = request.ShoroAghsat;
            }

            await _context.ForooshFactors.AddAsync(item);
            await _context.SaveChangesAsync();

            if (request.PaymentMethod is PaymentMethodTypes.OnCredit)
            {
                Payment payment = new()
                {
                    PaymentAmount = request.PishPardakht!.Value,
                    IdForooshFactor = item.Id,
                    DatePay = DateTime.UtcNow
                };
            
                await _context.Payments.AddAsync(payment);
            
                var paymentAmount = (request.AmountTotal + request.MablagheKoleSoud - request.PishPardakht) /
                                    request.TedadeAghsat;
                var paymentDate = request.ShoroAghsat;
                // ToDo : Payment
                for (var i = 0; i < request.TedadeAghsat; i++)
                {
                    payment = new Payment
                    {
                        PaymentAmount = paymentAmount!.Value,
                        IdForooshFactor = item.Id,
                        DatePay = paymentDate!.Value
                    };
                    await _context.Payments.AddAsync(payment);
            
                    paymentDate = paymentDate.Value.AddDays(request.BazeyeZamany!.Value);
                }
            }
            else
            {
                Payment payment = new()
                {
                    PaymentAmount = request.AmountTotal,
                    IdForooshFactor = item.Id,
                    DatePay = DateTime.UtcNow
                };
            
                await _context.Payments.AddAsync(payment);
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
                ForooshId = item.Id,
                Type = LogTypes.InsertForoosh,
                UserId = request.UserIdAdded,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };

            await _log.InsertAsync(command);

            var result = await _context.ForooshFactors
                .Select(x => new SavePaymentResponse
                {
                    AmountTax = x.AmountTax,
                    PaymentMethod = x.PaymentMethod,
                    Amount = x.Amount,
                    AmountTotal = x.AmountTotal,
                    TedadeAghsat = x.TedadeAghsat,
                    PishPardakht = x.PishPardakht,
                    CustomerFullName = x.IdCustomerNavigation.FirstName + " " + x.IdCustomerNavigation.LastName,
                    ShoroAghsat = x.ShoroAghsat,
                    BazeyeZamany = x.BazeyeZamany,
                    DarSadeSoud = x.DarSadeSoud,
                    DatePayed = x.DatePayed,
                    IdFactor = x.Id,
                    MablagheKoleSoud = x.MablagheKoleSoud,
                    StatusTypeForooshFactor = x.StatusTypeForooshFactor,
                    Orders = x.ForooshOrders,
                    Payments = x.Payments
                }).SingleOrDefaultAsync(x => x.IdFactor == item.Id);

            return new Result<SavePaymentResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<SavePaymentResponse>(new ValidationException(e.Message));
        }
    }
}