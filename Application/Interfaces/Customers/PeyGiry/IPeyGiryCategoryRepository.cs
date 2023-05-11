namespace Application.Interfaces.Customers.PeyGiry;

public interface IPeyGiryCategoryRepository
{
    ValueTask<Result<ICollection<PeyGiryCategoryResponse>>> GetAllPeyGiryCategoriesAsync(Ulid businessId);
    ValueTask<Result<PeyGiryCategoryResponse>> GetPeyGiryCategoryByIdAsync(Ulid peyGiryCategoryId);
    ValueTask<Result<PeyGiryCategoryResponse>> ChangeStatusPeyGiryCategoryByIdAsync(ChangeStatusPeyGiryCategoryCommand request);
    ValueTask<Result<PeyGiryCategoryResponse>> CreatePeyGiryCategoryAsync(CreatePeyGiryCategoryCommand request);
    ValueTask<Result<PeyGiryCategoryResponse>> UpdatePeyGiryCategoryAsync(UpdatePeyGiryCategoryCommand request);
    ValueTask<Result<PeyGiryCategoryResponse>> DeletePeyGiryCategoryAsync(Ulid peyGiryCategoryId);
}