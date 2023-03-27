namespace Application.Services.SanAtService.Commands;

public class DeleteSanAtCommand : IRequest<SanAt>
{
    public Ulid SanAtId { get; set; }
}