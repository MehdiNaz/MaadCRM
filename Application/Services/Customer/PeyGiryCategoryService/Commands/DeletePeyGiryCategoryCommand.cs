namespace Application.Services.Customer.PeyGiryCategoryService.Commands;

public struct DeletePeyGiryCategoryCommand : IRequest<Result<PeyGiryCategoryResponse>>
{
    public Ulid Id { get; set; }
}