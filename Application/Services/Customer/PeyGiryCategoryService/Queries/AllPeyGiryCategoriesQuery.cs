namespace Application.Services.Customer.PeyGiryCategoryService.Queries;

public struct AllPeyGiryCategoriesQuery : IRequest<Result<ICollection<PeyGiryCategoryResponse>>>
{
    public Ulid BusinessId { get; set; }
}