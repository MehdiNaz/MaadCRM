namespace Domain.Models;

public class Subscribe
{
    public long Id { get; set; }
    public string Email { get; set; }
    public short? IdCity { get; set; }
    public string Ip { get; set; }
    public string UserAgent { get; set; }
    public byte? Status { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] Rowversion { get; set; }

    public virtual City IdCityNavigation { get; set; }
}