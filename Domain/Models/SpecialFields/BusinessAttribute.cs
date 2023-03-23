namespace Domain.Models.SpecialFields;

public class BusinessAttribute:BaseEntity
{
    public string TextPrompt { get; set; }
    public bool IsRequired { get; set; }
    public AttributeControlType AttributeControlTypeId { get; set; }
    public int DisplayOrder { get; set; }
    public int? ValidationMinLength { get; set; }
    public int? ValidationMaxLength { get; set; }
    public string ValidationFileAllowExtention { get; set; }
    public int? ValidationFileMaximumSize { get; set; }
    public string DefaultValue { get; set; }
    public string ConditionValue { get; set; }
    public int CategoryAttributeId { get; set; }

    [ForeignKey(nameof(CategoryAttributeId))]
    public CategoryAttribute CategoryAttribute { get; set; }
    public ICollection<AttributeOptions> AttributeOptions { get; set; }
}
public enum AttributeControlType
{
    [Display(Name = "فهرست کشویی")]
    DropDownList = 1,
    [Display(Name = "دکمه های رادیویی")]
    RadioButtonList = 2,
    [Display(Name = "کادر انتخابی (checkboxs)")]
    CheckBoxList =3,
    [Display(Name = "کادر متنی")]
    TextBox =4,
    [Display(Name = "کادر متنی چند خطی")]
    MultilineText =5,
    [Display(Name = "انتخاب تاریخ")]
    DatePicker =6,
    [Display(Name = "بارگذاری فایل")]
    UploadFile =7,
    [Display(Name = "مربع رنگ")]
    ColorSqr =8
}