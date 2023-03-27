namespace Application.Services.MoarefService.Commands;

public class CreateMoarefCommand : IRequest<Moaref>
{
    public string MoarefName { get; set; }
    public string MoarefFamily { get; set; }
    public string MoarefPhone { get; set; }
    public byte IsDeleted { get; set; }
}