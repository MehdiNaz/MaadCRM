namespace DataAccess.Repositories.Customers.Note;

public class NoteHashTableRepository : INoteHashTableRepository
{
    private readonly MaadContext _context;

    public NoteHashTableRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CustomerNoteHashTable>>> GetAllNoteHashTablesAsync(Ulid customerId)
    {
        try
        {
            return await _context.NoteHashTables.Where(x => x.NoteHashTagStatus == Status.Show).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerNoteHashTable>>(new ValidationException(e.Message));
        }
    }
    public async ValueTask<Result<CustomerNoteHashTable>> GetNoteHashTableByIdAsync(Ulid noteHashTableId)
    {
        try
        {
            return await _context.NoteHashTables.SingleOrDefaultAsync(x => x.Id == noteHashTableId && x.NoteHashTagStatus == Status.Show);
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteHashTable>> ChangeStatusNoteHashTableByIdAsync(ChangeStatusNoteHashTableCommand request)
    {
        try
        {
            var item = await _context.NoteHashTables!.FindAsync(request.Id);
            if (item is null) return null;
            item.NoteHashTagStatus = request.NoteHashTagStatus;
            await _context.SaveChangesAsync();
            return new Result<CustomerNoteHashTable>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteHashTable>> CreateNoteHashTableAsync(CreateNoteHashTableCommand entity)
    {
        try
        {
            CustomerNoteHashTable item = new()
            {
                Title = entity.Title,
                IdBusiness = entity.BusinessId
            };
            await _context.NoteHashTables!.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<CustomerNoteHashTable>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteHashTable>> UpdateNoteHashTableAsync(UpdateNoteHashTableCommand entity)
    {
        try
        {
            CustomerNoteHashTable item = new()
            {
                Id = entity.Id,
                Title = entity.Title,
            };
            _context.Update(item);
            await _context.SaveChangesAsync();
            return new Result<CustomerNoteHashTable>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteHashTable>> DeleteNoteHashTableAsync(Ulid id)
    {

        try
        {
            var item = await _context.NoteHashTables.FindAsync(id);
            item!.NoteHashTagStatus = Status.Deleted;

            await _context.SaveChangesAsync();
            return new Result<CustomerNoteHashTable>(item);
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTable>(new ValidationException(e.Message));
        }
    }
}