namespace Application.Services.MoarefService.Commands;

public class DeleteMoarefCommand : IRequest<Moaref>
{
    public Ulid MoarefId { get; set; }
}