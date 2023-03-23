namespace Domain.Models;

public class Visit
{
    public long Id { get; set; }
    public string IdUser { get; set; }
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public DateTime DateCreated { get; set; }
}