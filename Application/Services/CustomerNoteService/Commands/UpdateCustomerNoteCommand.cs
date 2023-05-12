namespace Application.Services.CustomerNoteService.Commands;

public struct UpdateCustomerNoteCommand : IRequest<Result<CustomerNoteResponse>>
{
    public Ulid Id { get; set; }
    public string Description { get; set; }
    public Ulid? ProductId { get; set; }
    public ICollection<Ulid>? HashTagIds { get; set; }
}