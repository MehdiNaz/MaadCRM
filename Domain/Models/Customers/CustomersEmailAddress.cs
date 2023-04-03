﻿namespace Domain.Models.Customers;

public class CustomersEmailAddress : BaseEntity
{
    public CustomersEmailAddress()
    {
        CustomersEmailAddressId = Ulid.NewUlid();
        IsDeleted = Status.NotDeleted;
        IsShown = ShowTypes.Show;
    }

    public Ulid CustomersEmailAddressId { get; set; }
    public string CustomersEmailAddrs { get; set; }
    public Ulid CustomerId { get; set; }
    public Status IsDeleted { get; set; }
    public ShowTypes IsShown { get; set; }

    public Customer Customer { get; set; }
}