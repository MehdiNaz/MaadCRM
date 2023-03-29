namespace Application.Services.MoarefService.Commands;

public struct UpdateMoarefCommand : IRequest<Moaref>
{
    public Ulid MoarefId { get; set; }
    public string MoarefName { get; set; }
    public string MoarefFamily { get; set; }
    public string MoarefPhone { get; set; }
}