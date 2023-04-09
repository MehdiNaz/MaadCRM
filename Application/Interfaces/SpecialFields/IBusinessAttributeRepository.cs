namespace Application.Interfaces.SpecialFields;

public interface IBusinessAttributeRepository
{
    ValueTask<ICollection<BusinessAttribute?>> GetAllBusinessAttributesAsync();
    ValueTask<BusinessAttribute?> GetBusinessAttributeByIdAsync(int businessAttributeId);
    ValueTask<BusinessAttribute?> CreateBusinessAttributeAsync(BusinessAttribute? toCreate);
    ValueTask<BusinessAttribute?> UpdateBusinessAttributeAsync(string updateContent, int businessAttributeId);
    ValueTask<BusinessAttribute?> DeleteBusinessAttributeAsync(int businessAttributeId);
}