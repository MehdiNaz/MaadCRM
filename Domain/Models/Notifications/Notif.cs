namespace Domain.Models.Notifications;

public class Notif : BaseEntityWithUserId
{
    public Notif()
    {
        Id = Ulid.NewUlid();
        Status = StatusType.Show;
    }
    public Ulid Id { get; set; }
    public NotificationType NotificationType { get; set; }
    public StatusType Status { get; set; }

    public DateTime DateDue { get; set; }
    public Ulid? IdPeyGiry { get; set; }
    public CustomerPeyGiry? IdPeyGiryNavigation { get; set; }
}