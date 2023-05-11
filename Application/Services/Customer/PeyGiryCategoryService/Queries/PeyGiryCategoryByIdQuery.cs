namespace Application.Services.Customer.PeyGiryCategoryService.Queries;

public struct PeyGiryCategoryByIdQuery : IRequest<Result<PeyGiryCategoryResponse>>
{
    public Ulid PeyGiryCategoryId { get; set; }
}