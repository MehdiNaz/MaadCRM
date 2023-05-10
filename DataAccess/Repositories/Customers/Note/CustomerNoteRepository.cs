namespace DataAccess.Repositories.Customers.Note;

public class CustomerNoteRepository : ICustomerNoteRepository
{
    private readonly MaadContext _context;

    public CustomerNoteRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CustomerNoteResponse>>> GetAllCustomerNotesAsync(Ulid customerId)
    {
        try
        {
            return await _context.CustomerNotes
                .Where(x => x.CustomerNoteStatusType == StatusType.Show && x.IdCustomer == customerId)
                .Include(x => x.IdUserAddNavigation)
                .Select(x => new CustomerNoteResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    CustomerNoteStatusType = x.CustomerNoteStatusType,
                    IdProduct = x.IdProduct,
                    IdCustomer = x.IdCustomer,
                    UserFirstName = x.IdUserAddNavigation.Name,
                    UserLastName = x.IdUserAddNavigation.Family,
                    CreateDate = x.DateCreated
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerNoteResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteResponse>> GetCustomerNoteByIdAsync(Ulid customerNoteId)
    {
        try
        {
            return await _context.CustomerNotes.Where(x => x.CustomerNoteStatusType == StatusType.Show)
                .Include(x => x.IdUserAddNavigation).FirstOrDefaultAsync(x => x.Id == customerNoteId)
                .Select(x => new CustomerNoteResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    CustomerNoteStatusType = x.CustomerNoteStatusType,
                    IdProduct = x.IdProduct,
                    IdCustomer = x.IdCustomer,
                    UserFirstName = x.IdUserAddNavigation.Name,
                    UserLastName = x.IdUserAddNavigation.Family,
                    CreateDate = x.DateCreated
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteResponse>(new ValidationException(e.Message));
        }
    }
    public async ValueTask<Result<CustomerNote>> ChangeStatusCustomerNoteByIdAsync(ChangeStatusCustomerNoteCommand request)
    {
        try
        {
            BusinessPlan businessPlan = new()
            {
                BusinessId = request.CustomerNoteId
            };

            var item = await _context.CustomerNotes!.FindAsync(request.CustomerNoteId);
            if (item is null) return new Result<CustomerNote>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerNoteStatusType = request.CustomerNoteStatusType;
            await _context.SaveChangesAsync();
            return new Result<CustomerNote>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerNote>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNote>> CreateCustomerNoteAsync(CreateCustomerNoteCommand entity)
    {
        try
        {
            CustomerNote item = new()
            {
                IdCustomer = entity.CustomerId,
                IdProduct = entity.ProductId,
                Description = entity.Description,
                IdUserAdded = entity.IdUser,
                IdUserUpdated = entity.IdUser
            };
            await _context.CustomerNotes.AddAsync(item);
            var result = await _context.SaveChangesAsync();


            if (result == 0)
                return new Result<CustomerNote>(new ValidationException(""));

            if (entity.HashTagIds is not null)
                foreach (var entityHashTagId in entity.HashTagIds)
                {
                    CustomerNoteHashTag newHashTable = new()
                    {
                        IdNoteHashTable = entityHashTagId,
                        IdCustomerNote = item.Id
                    };
                    await _context.NoteHashTags.AddAsync(newHashTable);
                }


            await _context.SaveChangesAsync();

            return new Result<CustomerNote>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerNote>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNote>> UpdateCustomerNoteAsync(UpdateCustomerNoteCommand entity)
    {
        try
        {
            var result = await _context.CustomerNotes.FindAsync(entity.Id);
            result.IdUserUpdated = entity.IdUser;
            result.Description = entity.Description;


            //await _context.SaveChangesAsync();

            //var result = await _context.SaveChangesAsync();

            //if (result == 0)
            //    return null;

            // foreach (var entityHashTagId in entity.HashTagIds)
            // {
            //     CustomerNoteHashTag newHashTable = new()
            //     {
            //         IdNoteHashTable = entityHashTagId
            //     };
            //     await _context.NoteHashTags.AddAsync(newHashTable);
            // }

            // foreach (var customerNoteId in entity.CustomerNoteId)
            // {
            //     CustomerNoteHashTag newHashTable = new()
            //     {
            //         IdCustomerNote = customerNoteId
            //     };
            //     await _context.NoteHashTags.AddAsync(newHashTable);
            // }

            //await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
            return new Result<CustomerNote>(result);
        }
        catch (Exception e)
        {
            return new Result<CustomerNote>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNote>> DeleteCustomerNoteAsync(Ulid id)
    {
        try
        {
            var businessPlan = await _context.CustomerNotes.FindAsync(id);
            businessPlan.CustomerNoteStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return new Result<CustomerNote>(businessPlan);
        }
        catch (Exception e)
        {
            return new Result<CustomerNote>(new ValidationException(e.Message));
        }
    }
}