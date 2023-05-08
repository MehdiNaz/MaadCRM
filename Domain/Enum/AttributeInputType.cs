namespace Domain.Enum;

public enum AttributeّInputType
{
    [Display(Name = "فهرست کشویی")]
    DropDownList = 1,
    [Display(Name = "دکمه های رادیویی")]
    RadioButtonList = 2,
    [Display(Name = "کادر انتخابی (checkboxs)")]
    CheckBoxList = 3,
    [Display(Name = "کادر متنی")]
    TextBox = 4,
    [Display(Name = "کادر متنی چند خطی")]
    MultilineText = 5,
    [Display(Name = "انتخاب تاریخ")]
    DatePicker = 6,
    [Display(Name = "بارگذاری فایل")]
    UploadFile = 7,
    [Display(Name = "کادر عدد")]
    Number = 8,
    [Display(Name = "مربع رنگ")]
    ColorSqr = 9
}