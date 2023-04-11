namespace Domain.UnDifined;

public class Setting : BaseEntity
{
    public Setting()
    {
        SettingId = Ulid.NewUlid();
        DisplayOrder = 0;
    }

    public Ulid SettingId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public Ulid BusinessId { get; set; }
    public int DisplayOrder { get; set; } 


    public Business Business { get; set; }
}