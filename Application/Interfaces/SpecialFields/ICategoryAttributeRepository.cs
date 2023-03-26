namespace Application.Interfaces.SpecialFields;

public interface ICategoryAttributeRepository
{
    ValueTask<ICollection<CategoryAttribute?>> GetAllCategoryAttributeAsync();
    ValueTask<CategoryAttribute?> GetCategoryAttributeByIdAsync(int categoryAttributeId);
    ValueTask<CategoryAttribute?> CreateCategoryAttributeAsync(CategoryAttribute? toCreate);
    ValueTask<CategoryAttribute?> UpdateCategoryAttributeAsync(string updateContent, int categoryAttributeId);
    ValueTask DeleteCategoryAttributeAsync(int categoryAttributeId);
}