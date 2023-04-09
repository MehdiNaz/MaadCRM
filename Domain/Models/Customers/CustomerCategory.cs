﻿namespace Domain.Models.Customers;

public class CustomerCategory : BaseEntityWithUpdateInfo
{
    public CustomerCategory()
    {
        CustomerCategoryId = Ulid.NewUlid();
        CustomerCategoryStatus = Status.Show;
    }

    public Ulid CustomerCategoryId { get; set; }
    public string CustomerCategoryName { get; set; }
    public Ulid CustomerId { get; set; }
    public Status CustomerCategoryStatus { get; set; }

    public ICollection<Customer>? Customers { get; set; }
}