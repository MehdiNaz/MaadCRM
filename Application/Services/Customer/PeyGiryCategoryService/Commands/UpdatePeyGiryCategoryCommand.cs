namespace Application.Services.Customer.PeyGiryCategoryService.Commands;

public struct UpdatePeyGiryCategoryCommand : IRequest<Result<PeyGiryCategoryResponse>>
{
    public Ulid Id { get; set; }
    public string Kind { get; set; }
    public Ulid? BusinessId { get; set; }
    public string IdUserUpdated { get; set; }
}