namespace Application.Interfaces.Customers;

public interface ICustCategoryRepository
{
    Task<ICollection<CustCategory?>> GetAllCustCategoryAsync();
    ValueTask<CustCategory?> GetCustCategoryByIdAsync(int custCategoryId);
    ValueTask<CustCategory?> CreateCustCategoryAsync(CustCategory? toCreate);
    ValueTask<CustCategory?> UpdateCustCategoryAsync(string updateContent, int custCategoryId);
    ValueTask DeleteCusCustomerAsync(int custCategoryId);
}