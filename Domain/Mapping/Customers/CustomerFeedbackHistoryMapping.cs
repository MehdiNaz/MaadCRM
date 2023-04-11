namespace Domain.Mapping.Customers;

public class CustomerFeedbackHistoryMapping : IEntityTypeConfiguration<CustomerFeedbackHistory>
{
    public void Configure(EntityTypeBuilder<CustomerFeedbackHistory> builder)
    {
        builder.ToTable("CustomerFeedbackHistories");
        builder.HasKey(x => x.CustomerFeedbackHistoryId);
        builder.Property(x => x.Description).HasMaxLength(500).IsRequired();

        //
        // builder.HasOne(x => x.Customers).WithMany(x => x.CustomerFeedbackHistory).HasForeignKey(x => x.CustomerId);
        // builder.HasOne(x => x.CustomerFeedback).WithMany(x => x.CustomerFeedbackHistories).HasForeignKey(x => x.CustomerFeedbackId);
    }
}