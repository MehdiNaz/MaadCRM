﻿namespace Domain.Models.Customers.FeedBack;

public class CustomerFeedback 
{
    public CustomerFeedback()
    {
        Id = Ulid.NewUlid();
        Status = Status.Show;
        Attachments = new HashSet<CustomerFeedbackAttachment>();
    }

    public Ulid Id { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }

    public Ulid IdCategory { get; set; }
    public CustomerFeedbackCategory? Category { get; set; }

    public Ulid IdProduct { get; set; }
    public Product? IdProductNavigation { get; set; }

    public Ulid IdCustomer { get; set; }
    public Customer? IdCustomerNavigation { get; set; }

    public ICollection<CustomerFeedbackAttachment>? Attachments;

}