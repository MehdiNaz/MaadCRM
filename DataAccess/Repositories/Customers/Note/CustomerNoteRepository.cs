﻿namespace DataAccess.Repositories.Customers.Note;

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
    public async ValueTask<Result<CustomerNoteResponse>> ChangeStatusCustomerNoteByIdAsync(ChangeStatusCustomerNoteCommand request)
    {
        try
        {
            BusinessPlan businessPlan = new()
            {
                BusinessId = request.CustomerNoteId
            };

            var item = await _context.CustomerNotes.FindAsync(request.CustomerNoteId);
            if (item is null) return new Result<CustomerNoteResponse>(new ValidationException(ResultErrorMessage.NotFound));
            item.CustomerNoteStatusType = request.CustomerNoteStatusType;
            await _context.SaveChangesAsync();
            return await _context.CustomerNotes.FindAsync(request.CustomerNoteId)
                .Select(x => new CustomerNoteResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    CustomerNoteStatusType = x.CustomerNoteStatusType,
                    IdProduct = x.IdProduct,
                    IdCustomer = x.IdCustomer,
                    CreateDate = x.DateCreated
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CustomerNoteResponse>> CreateCustomerNoteAsync(CreateCustomerNoteCommand request)
    {
        try
        {
            CustomerNote item = new()
            {
                IdCustomer = request.CustomerId,
                IdProduct = request.ProductId,
                Description = request.Description,
                IdUserAdded = request.IdUser,
                IdUserUpdated = request.IdUser
            };
            await _context.CustomerNotes.AddAsync(item);
            var result = await _context.SaveChangesAsync();


            if (result == 0)
                return new Result<CustomerNoteResponse>(new ValidationException(""));

            if (request.HashTagIds is not null)
                foreach (var requestHashTagId in request.HashTagIds)
                {
                    CustomerNoteHashTag newHashTable = new()
                    {
                        IdNoteHashTable = requestHashTagId,
                        IdCustomerNote = item.Id
                    };
                    await _context.NoteHashTags.AddAsync(newHashTable);
                }


            await _context.SaveChangesAsync();

            return await _context.CustomerNotes.FindAsync(item.Id)
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

    public async ValueTask<Result<CustomerNoteResponse>> UpdateCustomerNoteAsync(UpdateCustomerNoteCommand request)
    {
        try
        {
            var result = await _context.CustomerNotes.FindAsync(request.Id);
            result.IdUserUpdated = request.IdUser;
            result.Description = request.Description;


            //await _context.SaveChangesAsync();

            //var result = await _context.SaveChangesAsync();

            //if (result == 0)
            //    return null;

            // foreach (var requestHashTagId in request.HashTagIds)
            // {
            //     CustomerNoteHashTag newHashTable = new()
            //     {
            //         IdNoteHashTable = requestHashTagId
            //     };
            //     await _context.NoteHashTags.AddAsync(newHashTable);
            // }

            // foreach (var customerNoteId in request.CustomerNoteId)
            // {
            //     CustomerNoteHashTag newHashTable = new()
            //     {
            //         IdCustomerNote = customerNoteId
            //     };
            //     await _context.NoteHashTags.AddAsync(newHashTable);
            // }

            //await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
            return await _context.CustomerNotes.FindAsync(request.Id)
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

    public async ValueTask<Result<CustomerNoteResponse>> DeleteCustomerNoteAsync(Ulid id)
    {
        try
        {
            var item = await _context.CustomerNotes.FindAsync(id);
            item.CustomerNoteStatusType = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return await _context.CustomerNotes.FindAsync(id)
                .Select(x => new CustomerNoteResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    CustomerNoteStatusType = x.CustomerNoteStatusType,
                    IdProduct = x.IdProduct,
                    IdCustomer = x.IdCustomer,
                    CreateDate = x.DateCreated
                });
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteResponse>(new ValidationException(e.Message));
        }
    }
}