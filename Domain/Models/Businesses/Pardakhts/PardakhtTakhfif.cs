namespace Domain.Models.Businesses.Pardakhts;

public class PardakhtTakhfif : BaseEntityWithUserUpdate
{
    public PardakhtTakhfif()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
    }

    public Ulid Id { get; set; }
    
    public Ulid IdPardakht { get; set; }
    public Pardakht IdPardakhtNavigation { get; set; }

    public Ulid IdTakhfif { get; set; }
    public Takhfif IdTakhfifNavigation { get; set; }
    
    public StatusType Status { get; set; }
}