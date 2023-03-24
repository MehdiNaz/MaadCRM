namespace Domain.Enum;

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