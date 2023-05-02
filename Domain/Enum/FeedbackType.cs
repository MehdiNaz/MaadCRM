namespace Domain.Enum;

public enum FeedbackType
{
    [Display(Name = "همکار")]
    Hamkar = 1,
    [Display(Name = "کالا / خدمات")]
    Product = 2,
    [Display(Name = "فرآیند خرید")]
    Kharid = 3,
}