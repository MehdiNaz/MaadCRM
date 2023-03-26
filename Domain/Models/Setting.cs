﻿namespace Domain.Models.General;

public class Setting : BaseEntity
{
    public Ulid SettingId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public Ulid BusinessId { get; set; }
    public int DisplayOrder { get; set; } = 0;
    
    
    public Business Business { get; set; }
}