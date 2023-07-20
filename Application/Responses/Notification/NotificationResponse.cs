namespace Application.Responses.Notification;

public struct NotificationResponse
{
    public Ulid Id { get; set; }
    public NotificationType NotificationType { get; set; }
    public StatusType Status { get; set; }
    public bool IsRead { get; set; }

    public DateTime DateDue { get; set; }
    public DateTime DateAlarm { get; set; }

    public string Message { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    
    public Ulid? IdPeyGiry { get; set; }
    public CustomerPeyGiry? IdPeyGiryNavigation { get; set; }
    
    public string IdUser { get; set; }
}