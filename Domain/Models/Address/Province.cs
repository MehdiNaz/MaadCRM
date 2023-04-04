﻿namespace Domain.Models.Address;

public class Province : BaseEntity
{
    public Province()
    {
        ProvinceId = Ulid.NewUlid();
        ProvinceStatus = Status.Show;
    }

    public Ulid ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public bool IsDefault { get; set; }
    public int DisplayOrder { get; set; }
    public Ulid CountryId { get; set; }
    public Status ProvinceStatus { get; set; }


    public Country Country { get; set; }
    public ICollection<City> Cities { get; set; }
}