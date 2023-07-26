namespace Domain.Models.Businesses.Pardakhts;

public class Takhfif : BaseEntityWithUserUpdate
{
    public Takhfif()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
        PardakhtTakhfifs = new HashSet<PardakhtTakhfif>();
    }

    public Ulid Id { get; set; }
    
    public Ulid? IdBusiness { get; set; }
    public required string Name { get; set; }
    public string? Note { get; set; }
    public decimal? Amount { get; set; }
    public byte? Percent { get; set; }
    public DateTime? DateStarted { get; set; }
    public DateTime? DateEnded { get; set; }
    public bool? IsUsed { get; set; }
    public uint? MaxCountCanBeUsed { get; set; }
    
    public StatusType Status { get; set; }

    public ICollection<PardakhtTakhfif>? PardakhtTakhfifs { get; set; }
}