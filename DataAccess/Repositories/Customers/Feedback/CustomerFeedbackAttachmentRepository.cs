namespace DataAccess.Repositories.Customers.Feedback;

public class CustomerFeedbackAttachmentRepository : ICustomerFeedbackAttachmentRepository
{
    private readonly MaadContext _context;

    public CustomerFeedbackAttachmentRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CustomerFeedbackAttachmentResponse>>> GetAllCustomerFeedbackAttachmentAsync(Ulid customerFeedbackId)
    {
        try
        {
            return new Result<ICollection<CustomerFeedbackAttachmentResponse>>(await _context.CustomerFeedbackAttachments
                .Include(x => x.IdCustomerFeedbackNavigation)
                .Where(x => x.IdCustomerFeedback == customerFeedbackId)
                .Select(x => new CustomerFeedbackAttachmentResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    FileName = x.FileName,
                    Extenstion = x.Extenstion,
                    CustomerFeedbackAttachmentStatus = x.CustomerFeedbackAttachmentStatus
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackAttachmentResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackAttachmentResponse>> GetCustomerFeedbackAttachmentByIdAsync(Ulid attachmentId)
    {
        try
        {
            return await _context.CustomerFeedbackAttachments
                .FirstOrDefaultAsync(x => x.Id == attachmentId && x.CustomerFeedbackAttachmentStatus == Status.Show)
                .Select(x => new CustomerFeedbackAttachmentResponse
                {
                    Id = x.Id,
                    Extenstion = x.Extenstion,
                    Name = x.Name,
                    FileName = x.FileName,
                    CustomerFeedbackAttachmentStatus = x.CustomerFeedbackAttachmentStatus
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackAttachmentResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackAttachmentResponse>> CreateCustomerFeedbackAttachmentAsync(CreateCustomerFeedbackAttachmentCommand request)
    {
        try
        {
            CustomerFeedbackAttachment item = new()
            {
                Extenstion = request.Extenstion,
                Name = request.Name,
                FileName = request.FileName,
                IdCustomerFeedback = request.IdCustomerFeedback
            };
            await _context.CustomerFeedbackAttachments.AddAsync(item);
            await _context.SaveChangesAsync();
            return await _context.CustomerFeedbackAttachments.FirstOrDefaultAsync(x => x.Name == request.Name && x.Extenstion == request.Extenstion)
                .Select(x => new CustomerFeedbackAttachmentResponse
                {
                    Id = x.Id,
                    Extenstion = x.Extenstion,
                    Name = x.Name,
                    FileName = x.FileName,
                    CustomerFeedbackAttachmentStatus = x.CustomerFeedbackAttachmentStatus
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackAttachmentResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerFeedbackAttachmentResponse>> UpdateCustomerFeedbackAttachmentAsync(UpdateCustomerFeedbackAttachmentCommand request)
    {
        try
        {
            CustomerFeedbackAttachment item = await _context.CustomerFeedbackAttachments.FindAsync(request.Id);
            item.Extenstion = request.Extenstion;
            item.Name = request.Name;
            item.FileName = request.FileName;

            _context.Update(item);
            await _context.SaveChangesAsync();
            return await _context.CustomerFeedbackAttachments.FindAsync(request.Id)
                .Select(x => new CustomerFeedbackAttachmentResponse
                {
                    Id = x.Id,
                    Extenstion = x.Extenstion,
                    Name = x.Name,
                    FileName = x.FileName,
                    CustomerFeedbackAttachmentStatus = x.CustomerFeedbackAttachmentStatus
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackAttachmentResponse>(new ValidationException(e.Message));
        }

    }

    public async ValueTask<Result<CustomerFeedbackAttachmentResponse>> DeleteCustomerFeedbackAttachmentAsync(Ulid attachmentId)
    {
        try
        {
            var item = await _context.CustomerFeedbackAttachments.FindAsync(attachmentId);

            // Hard Delete : => 

            _context.CustomerFeedbackAttachments.Remove(item);
            await _context.SaveChangesAsync();
            return await _context.CustomerFeedbackAttachments.FindAsync(attachmentId)
                .Select(x => new CustomerFeedbackAttachmentResponse
                {
                    Id = x.Id,
                    Extenstion = x.Extenstion,
                    Name = x.Name,
                    FileName = x.FileName,
                    CustomerFeedbackAttachmentStatus = x.CustomerFeedbackAttachmentStatus
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackAttachmentResponse>(new ValidationException(e.Message));
        }
    }
}