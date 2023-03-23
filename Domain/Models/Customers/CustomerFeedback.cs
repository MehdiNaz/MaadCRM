﻿namespace Domain.Models.Customers;

public class CustomerFeedback:BaseEntity
{
    public string FeedbackName { get; set; }
    public int DisplayOrder { get; set; }
    public decimal Point { get; set; }
    public int BalancePoint { get; set; }
    public ICollection<CustomerFeedbackHistory> CustomerFeedbackHistories { get; set; }
}