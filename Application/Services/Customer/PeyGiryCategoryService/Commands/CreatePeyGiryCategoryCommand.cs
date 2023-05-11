namespace Application.Services.Customer.PeyGiryCategoryService.Commands;

public struct CreatePeyGiryCategoryCommand : IRequest<Result<PeyGiryCategoryResponse>>
{
    public string Kind { get; set; }
    public Ulid? BusinessId { get; set; }
    public string IdUserAdded { get; set; }
    public string IdUserUpdated { get; set; }
}