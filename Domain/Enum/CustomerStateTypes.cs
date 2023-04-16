namespace Domain.Enum;

public enum CustomerStateTypes
{
    [Display(Name = "مشتری بالقوه")]
    Belghoveh = 1,
    [Display(Name = "مشتری بالفعل")]
    BelFel = 2,
    [Display(Name = "مشتری راضی")]
    Razy = 3,
    [Display(Name = "مشتری ناراضی")]
    NaRazy = 4,
    [Display(Name = "مشتری در حال پیگیری")]
    DarHalePeyGiry = 5,
    [Display(Name = "مشتری وفادار")]
    Vafadar = 6
}