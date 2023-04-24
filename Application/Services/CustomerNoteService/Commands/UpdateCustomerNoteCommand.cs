namespace Application.Services.CustomerNoteService.Commands;

public struct UpdateCustomerNoteCommand : IRequest<Result<CustomerNote>>
{
    public Ulid Id { get; set; }
    public string Description { get; set; }
    public Ulid? ProductId { get; set; }
    public ICollection<Ulid>? HashTagIds { get; set; }
    public string? IdUser { get; set; }
}