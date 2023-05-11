namespace Application.Services.Customer.PeyGiryCategoryService.Commands;

public struct ChangeStatusPeyGiryCategoryCommand : IRequest<Result<PeyGiryCategoryResponse>>
{
    public Ulid Id { get; set; }
    public StatusType Status { get; set; }
}