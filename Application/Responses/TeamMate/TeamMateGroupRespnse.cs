namespace Application.Responses.TeamMate;

public struct TeamMateGroupRespnse
{
    public Ulid Id { get; set; }
    public string Title { get; set; }
    public int DisplayOrder { get; set; }
    public StatusType Status { get; set; }
    public Ulid IdBusiness { get; set; }
}