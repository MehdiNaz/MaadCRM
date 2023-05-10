﻿namespace DataAccess.Repositories.Customers.Foroosh;

public class PaymentRepository : IPaymentRepository
{
    private readonly MaadContext _context;

    public PaymentRepository(MaadContext context)
    {
        _context = context;
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
}