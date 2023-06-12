using Application.Responses.Customer.Foroosh;

namespace DataAccess.Repositories.Customers.Foroosh;

public class PaymentRepository : IForooshPaymentRepository
{
    private readonly MaadContext _context;
    private readonly ILogRepository _log;

    public PaymentRepository(MaadContext context, ILogRepository log)
    {
        _context = context;
        _log = log;
    }


    public async ValueTask<Result<ICollection<ForooshPayment>>> GetAllPaymentsAsync()
    {
        try
        {
            return await _context.Payments.Where(x => x.PaymentStatusType == StatusType.Show).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<ForooshPayment>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshPayment>> GetPaymentByIdAsync(Ulid paymentId)
    {
        try
        {
            return await _context.Payments.SingleOrDefaultAsync(x => x.Id == paymentId && x.PaymentStatusType == StatusType.Show);
        }
        catch (Exception e)
        {
            return new Result<ForooshPayment>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshPayment>> ChangeStatusPaymentByIdAsync(ChangeStatusPaymentCommand request)
    {
        try
        {
            var item = await _context.Payments.FindAsync(request.Id);
            if (item is null) return new Result<ForooshPayment>(new ValidationException(ResultErrorMessage.NotFound));
            item.PaymentStatusType = request.PaymentStatusType;
            await _context.SaveChangesAsync();

            return item;
        }
        catch (Exception e)
        {
            return new Result<ForooshPayment>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshPayment>> CreatePaymentAsync(CreatePaymentCommand request)
    {
        try
        {
            ForooshPayment item = new()
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
            return new Result<ForooshPayment>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshPayment>> UpdatePaymentAsync(UpdatePaymentCommand request)
    {
        try
        {
            ForooshPayment item = await _context.Payments.FindAsync(request.Id);

            item.PaymentAmount = request.PaymentAmount;

            await _context.SaveChangesAsync();
            return item;
        }
        catch (Exception e)
        {
            return new Result<ForooshPayment>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ForooshPayment>> DeletePaymentAsync(Ulid paymentId)
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
            return new Result<ForooshPayment>(new ValidationException(e.Message));
        }
    }
    
    public async ValueTask<Result<SaveForooshPaymentResponse>> SavePaymentsAsync(SaveForooshPaymentCommand request)
    {
        try
        {
            var resultFactor = await _context.ForooshFactors.FindAsync(request.IdFactor);
            if (resultFactor is null) return new Result<SaveForooshPaymentResponse>(new ValidationException("شماره فاکتور اشتباه است"));

            resultFactor.Amount = request.Amount;
            resultFactor.AmountTax = request.AmountTax;
            resultFactor.AmountDiscount = request.AmountDiscount;
            resultFactor.PaymentMethod = request.PaymentMethod;
            resultFactor.ShippingMethodType = request.ShippingMethodType;
            // item.IdUserUpdated = request.UserIdUpdated;
            resultFactor.AmountTotal = request.Amount + request.AmountTax;
            resultFactor.DatePayed = DateTime.UtcNow;

            if (request.PaymentMethod is PaymentMethodTypes.OnCredit)
            {
                resultFactor.TedadeAghsat = request.TedadeAghsat;
                resultFactor.BazeyeZamany = request.BazeyeZamany;
                resultFactor.DarSadeSoud = request.DarSadeSoud;
                resultFactor.PishPardakht = request.PishPardakht;
                resultFactor.MablagheKoleSoud = request.MablagheKoleSoud;
                resultFactor.ShoroAghsat = request.ShoroAghsat;
            }

            await _context.SaveChangesAsync();
            
            // Delete All Payments
            var lstPayments = await _context.Payments.Where(x => x.IdForooshFactor == request.IdFactor).ToListAsync();
            _context.Payments.RemoveRange(lstPayments);
            await _context.SaveChangesAsync();


            if (request.PaymentMethod is PaymentMethodTypes.OnCredit)
            {
                ForooshPayment payment = new()
                {
                    PaymentAmount = request.PishPardakht!.Value,
                    IdForooshFactor = resultFactor.Id,
                    DatePay = DateTime.UtcNow
                };
            
                await _context.Payments.AddAsync(payment);
            
                var paymentAmount = (request.AmountTotal + request.MablagheKoleSoud - request.PishPardakht) /
                                    request.TedadeAghsat;
                var paymentDate = request.ShoroAghsat;
                
                for (var i = 0; i < request.TedadeAghsat; i++)
                {
                    payment = new ForooshPayment
                    {
                        PaymentAmount = paymentAmount!.Value,
                        IdForooshFactor = resultFactor.Id,
                        DatePay = paymentDate!.Value
                    };
                    await _context.Payments.AddAsync(payment);
            
                    paymentDate = paymentDate.Value.AddDays(request.BazeyeZamany!.Value);
                }
            }
            else
            {
                ForooshPayment payment = new()
                {
                    PaymentAmount = request.AmountTotal,
                    IdForooshFactor = resultFactor.Id,
                    DatePay = DateTime.UtcNow
                };
            
                await _context.Payments.AddAsync(payment);
            }
            
            await _context.SaveChangesAsync();

            

            var resultCustomer = await _context.Customers.SingleOrDefaultAsync(x => x.Id == request.IdCustomer);
            if (resultCustomer != null) resultCustomer.CustomerState = CustomerStateTypes.BelFel;
            
            await _context.SaveChangesAsync();
            
            // Create Log
            CreateLogCommand command = new()
            {
                PeyGiryId = null,
                NoteId = null,
                FeedBackId = null,
                CustomerId = null,
                ProductId = null,
                ProductCategoryId = null,
                ForooshId = resultFactor.Id,
                Type = LogTypes.InsertForoosh,
                UserId = request.IdUserAdded,
                IpAddress = "IPAddress",
                UserAgent = "UserAgent",
                Description = "Description"
            };
            await _log.InsertAsync(command);
            
            // Return Result
            var result = await _context.ForooshFactors
                .Select(s => new SaveForooshPaymentResponse
                {
                    AmountTax = s.AmountTax,
                    PaymentMethod = s.PaymentMethod,
                    Amount = s.Amount,
                    AmountDiscount = s.AmountDiscount,
                    AmountTotal = s.AmountTotal,
                    TedadeAghsat = s.TedadeAghsat,
                    PishPardakht = s.PishPardakht,
                    IdCustomer = s.IdCustomer,
                    CustomerFullName = s.IdCustomerNavigation.FirstName + " " + s.IdCustomerNavigation.LastName,
                    ShoroAghsat = s.ShoroAghsat,
                    BazeyeZamany = s.BazeyeZamany,
                    DarSadeSoud = s.DarSadeSoud,
                    DatePayed = s.DatePayed,
                    IdFactor = s.Id,
                    MablagheKoleSoud = s.MablagheKoleSoud,
                    StatusTypeForooshFactor = s.StatusTypeForooshFactor,
                    Orders = s.ForooshOrders!.Select(o => new ForooshOrderResponse
                    {
                        Id = o.Id,
                        IdProduct = o.IdProduct,
                        ProductName = o.IdProductNavigation.ProductName,
                        Tedad = o.Tedad,
                        Price = o.Price,
                        PriceDiscount = o.PriceDiscount,
                        PriceShipping = o.PriceShipping,
                        PriceTotal = o.PriceTotal,
                        StatusTypeForooshOrder = o.StatusTypeForooshOrder
                    }).ToList(),
                    Payments = s.Payments!.Select(p => new ForooshPaymentResponse
                    {
                        Id = p.Id,
                        DatePay = p.DatePay,
                        PaymentAmount = p.PaymentAmount,
                        PaymentStatusType = p.PaymentStatusType
                    }).ToList()
                }).SingleOrDefaultAsync(r => r.IdFactor == resultFactor.Id);

            return new Result<SaveForooshPaymentResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<SaveForooshPaymentResponse>(new ValidationException(e.Message));
        }
    }
}