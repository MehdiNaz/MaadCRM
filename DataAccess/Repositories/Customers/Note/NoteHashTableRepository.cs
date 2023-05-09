namespace DataAccess.Repositories.Customers.Note;

public class NoteHashTableRepository : INoteHashTableRepository
{
    private readonly MaadContext _context;

    public NoteHashTableRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CustomerNoteHashTableResponse>>> GetAllNoteHashTablesAsync(Ulid customerId)
    {
        try
        {
            return await _context.NoteHashTables.
                Where(x => x.NoteHashTagStatusType == StatusType.Show)
                .Select(x => new CustomerNoteHashTableResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    NoteHashTagStatusType = x.NoteHashTagStatusType
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerNoteHashTableResponse>>(new ValidationException(e.Message));
        }
    }
    public async ValueTask<Result<CustomerNoteHashTableResponse>> GetNoteHashTableByIdAsync(Ulid noteHashTableId)
    {
        try
        {
            return await _context.NoteHashTables.SingleOrDefaultAsync(x => x.Id == noteHashTableId && x.NoteHashTagStatusType == StatusType.Show).
                Select(x => new CustomerNoteHashTableResponse()
                {
                    Id = x.Id,
                    Title = x.Title,
                    NoteHashTagStatusType = x.NoteHashTagStatusType
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteHashTableResponse>> ChangeStatusNoteHashTableByIdAsync(ChangeStatusNoteHashTableCommand request)
    {
        try
        {
            var item = await _context.NoteHashTables.FindAsync(request.Id);
            if (item is null) return new Result<CustomerNoteHashTableResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.NoteHashTagStatusType = request.NoteHashTagStatusType;
            await _context.SaveChangesAsync();
            return new Result<CustomerNoteHashTableResponse>(await _context.NoteHashTables.FindAsync(request.Id)
                .Select(x => new CustomerNoteHashTableResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    NoteHashTagStatusType = x.NoteHashTagStatusType

                }));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteHashTableResponse>> CreateNoteHashTableAsync(CreateNoteHashTableCommand request)
    {
        try
        {
            CustomerNoteHashTable item = new()
            {
                Title = request.Title,
                IdBusiness = request.BusinessId
            };
            await _context.NoteHashTables!.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<CustomerNoteHashTableResponse>(await _context.NoteHashTables
                .FirstOrDefaultAsync(x => x.Title == request.Title)
                            .Select(x => new CustomerNoteHashTableResponse
                            {
                                Id = x.Id,
                                Title = x.Title,
                                NoteHashTagStatusType = x.NoteHashTagStatusType

                            }));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteHashTableResponse>> UpdateNoteHashTableAsync(UpdateNoteHashTableCommand request)
    {
        try
        {
            var item = await _context.NoteHashTables.FindAsync(request.Id);
            item.Title = request.Title;
            _context.Update(item);
            await _context.SaveChangesAsync();
            return new Result<CustomerNoteHashTableResponse>(await _context.NoteHashTables.FindAsync(request.Id)
                            .Select(x => new CustomerNoteHashTableResponse
                            {
                                Id = x.Id,
                                Title = x.Title,
                            }));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteHashTableResponse>> DeleteNoteHashTableAsync(Ulid id)
    {

        try
        {
            var item = await _context.NoteHashTables.FindAsync(id);
            item!.NoteHashTagStatusType = StatusType.Deleted;

            await _context.SaveChangesAsync();
            return new Result<CustomerNoteHashTableResponse>(await _context.NoteHashTables.FindAsync(id)
                .Select(x => new CustomerNoteHashTableResponse
                {
                    Id = x.Id,
                    Title = x.Title,
                    NoteHashTagStatusType = x.NoteHashTagStatusType

                }));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new ValidationException(e.Message));
        }
    }
}