namespace DataAccess.Repositories.Customers.Note;

public class CustomerNoteRepository : ICustomerNoteRepository
{
    private readonly MaadContext _context;

    public CustomerNoteRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<CustomerNote?>> GetAllCustomerNotesAsync()
        => (await _context.CustomerNotes!.ToListAsync()).Where(x => x.CustomerNoteStatus == Status.Show).ToList()!;

    public async ValueTask<CustomerNote?> GetCustomerNoteByIdAsync(Ulid customerNoteId)
        => await _context.CustomerNotes!.FindAsync(customerNoteId);

    public async ValueTask<CustomerNote?> CreateCustomerNoteAsync(CustomerNote? entity)
    {
        try
        {
            await _context.CustomerNotes!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerNote?> UpdateCustomerNoteAsync(CustomerNote entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<CustomerNote?> DeleteCustomerNoteAsync(Ulid customerNoteId)
    {
        try
        {
            var customerNote = await GetCustomerNoteByIdAsync(customerNoteId);
            customerNote!.CustomerNoteStatus = Status.Show;
            await _context.SaveChangesAsync();
            return customerNote;
        }
        catch
        {
            return null;
        }
    }
}