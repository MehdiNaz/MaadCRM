namespace Application.Interfaces.Customers;

public interface ICustCategoryRepository
{
    Task<ICollection<CustCategory?>> GetAllCustCategoryAsync();
    ValueTask<CustCategory?> GetCustCategoryByIdAsync(Ulid custCategoryId);
    ValueTask<CustCategory?> CreateCustCategoryAsync(CustCategory? entity);
    ValueTask<CustCategory?> UpdateCustCategoryAsync(CustCategory entity, Ulid custCategoryId);
    ValueTask<CustCategory?> DeleteCusCustomerAsync(Ulid custCategoryId);
}