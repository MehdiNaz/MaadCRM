namespace Domain.Models;

public class Notification:BaseEntity
{
    public int UserId { get; set; }
    public bool IsRead { get; set; } = false; 
    public DateTime DateTimeForAlaram { get; set; }
    public string Url { get; set; }
    public string Message { get; set; }
    public string EntityType { get; set; }
    public int EntityId { get; set; }
    public AlaramType AlaramTypeId { get; set; }
    public bool IsDeleted { get; set; } = false;
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}
public enum AlaramType
{
    [Display(Name ="فقط اعلام پیام در پنل سایت ")]
    AlaramInPanel=1,
    [Display(Name = "ارسال ناتیفیکیشن")]
    PushNotification = 2,
    [Display(Name = "ارسال ایمیل")]
    EmailNotification=3,
    [Display(Name ="ارسال پیامک")]
    SMSNotification=4
}