namespace Domain.UnDifined;

public class Setting : BaseEntity
{
    public Setting()
    {
        SettingId = Ulid.NewUlid();
    }

    public Ulid SettingId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public Ulid BusinessId { get; set; }
    public int DisplayOrder { get; set; } = 0;


    public Business Business { get; set; }
}