namespace DataAccess.Repositories.Customers.Note;

public class CustomerNoteRepository : ICustomerNoteRepository
{
    private readonly MaadContext _context;

    public CustomerNoteRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerNote?>> GetAllCustomerNotesAsync(Ulid customerId)
        => await _context.CustomerNotes.Where(x => x.CustomerNoteStatus == Status.Show && x.CustomerId == customerId).ToListAsync();

    public async ValueTask<CustomerNote?> GetCustomerNoteByIdAsync(Ulid customerNoteId)
        => await _context.CustomerNotes.FirstOrDefaultAsync(x => x.Id == customerNoteId && x.CustomerNoteStatus == Status.Show);

    public async ValueTask<CustomerNote?> ChangeStatusCustomerNoteByIdAsync(ChangeStatusCustomerNoteCommand request)
    {
        try
        {
            var item = await _context.CustomerNotes!.FindAsync(request.CustomerNoteId);
            if (item is null) return null;
            item.CustomerNoteStatus = request.CustomerNoteStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerNote?> CreateCustomerNoteAsync(CreateCustomerNoteCommand entity)
    {
        try
        {
            CustomerNote newEntity = new()
            {
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                Description = entity.Description

            };

            await _context.CustomerNotes.AddAsync(newEntity);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return null;

            foreach (var entityHashTagId in entity.HashTagIds)
            {
                NoteHashTag newHashTable = new()
                {
                    NoteHashTableId = entityHashTagId
                };
                await _context.NoteHashTags.AddAsync(newHashTable);
            }

            foreach (var customerNoteId in entity.CustomerNoteId)
            {
                NoteHashTag newHashTable = new()
                {
                    CustomerNoteId = customerNoteId
                };
                await _context.NoteHashTags.AddAsync(newHashTable);
            }

            await _context.SaveChangesAsync();

            //  CustomerNoteResponse returnItem = new()
            //  {
            //      CustomerId = newEntity.CustomerId,
            //      Id = newEntity.Id,
            //      Description = newEntity.Description,
            //      CustomerNoteStatus = newEntity.CustomerNoteStatus,
            //// List String   List HashTag              
            //      HashTags = newEntity.CustomerHashTags.FirstOrDefault().Title
            //  };

            return newEntity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerNote?> UpdateCustomerNoteAsync(UpdateCustomerNoteCommand entity)
    {
        try
        {
            CustomerNote newEntity = new()
            {
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                Description = entity.Description

            };

            await _context.CustomerNotes.AddAsync(newEntity);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
                return null;

            foreach (var entityHashTagId in entity.HashTagIds)
            {
                NoteHashTag newHashTable = new()
                {
                    NoteHashTableId = entityHashTagId
                };
                await _context.NoteHashTags.AddAsync(newHashTable);
            }

            foreach (var customerNoteId in entity.CustomerNoteId)
            {
                NoteHashTag newHashTable = new()
                {
                    CustomerNoteId = customerNoteId
                };
                await _context.NoteHashTags.AddAsync(newHashTable);
            }

            await _context.SaveChangesAsync();

            _context.Update(newEntity);
            await _context.SaveChangesAsync();
            return newEntity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerNote?> DeleteCustomerNoteAsync(DeleteCustomerNoteCommand request)
    {
        try
        {
            var customerNote = await GetCustomerNoteByIdAsync(request.Id);
            customerNote!.CustomerNoteStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return customerNote;
        }
        catch
        {
            return null;
        }
    }
}