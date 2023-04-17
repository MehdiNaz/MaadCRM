﻿namespace DataAccess.Repositories.Customers.Note;

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
        => await _context.CustomerNotes.FirstOrDefaultAsync(x => x.CustomerNoteId == customerNoteId && x.CustomerNoteStatus == Status.Show);

    public async ValueTask<CustomerNote?> ChangeStatusCustomerNoteByIdAsync(Status status, Ulid customerNoteId)
    {
        try
        {
            var item = await _context.CustomerNotes!.FindAsync(customerNoteId);
            if (item is null) return null;
            item.CustomerNoteStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async Task<CustomerNoteResponse?> CreateCustomerNoteAsync(CreateCustomerNoteCommand entity)
    {
        try
        {
            CustomerNote newEntity = new()
            {
                CustomerNoteStatus = entity.CustomerNoteStatus,
                CustomerId = entity.CustomerId,
                ProductId = entity.ProductId,
                Description = entity.Description,
            };

            await _context.CustomerNotes!.AddAsync(newEntity!);
            int result = await _context.SaveChangesAsync();

            if (result == 0)
                return null;

            if (entity.HashTagIds is not null)
            {
                foreach (string entityHashTagId in entity.HashTagIds)
                {
                    NoteHashTag newHashTag = new()
                    {
                        Title = entityHashTagId
                    };
                }

                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();

            CustomerNoteResponse returnItem = new()
            {
                CustomerId = newEntity.CustomerId,
                ProductId = newEntity.ProductId,
                Description = newEntity.Description,
                CustomerNoteStatus = newEntity.CustomerNoteStatus
            };

            return returnItem;
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