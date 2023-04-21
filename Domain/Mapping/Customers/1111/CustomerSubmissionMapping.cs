namespace Domain.Mapping.Customers;

public class CustomerSubmissionMapping : IEntityTypeConfiguration<CustomerSubmission>
{
    public void Configure(EntityTypeBuilder<CustomerSubmission> builder)
    {
        builder.ToTable("CustomerSubmissions");
        builder.HasKey(x => x.CustomerSubmissionId);

        // builder.HasOne(x => x.Customers).WithMany(x => x.CustomerSubmission).HasForeignKey(x => x.CustomerSubmissionId);
        // builder.HasOne(x => x.Users).WithMany(x => x.CustomerSubmissions).HasForeignKey(x => x.UserId);
    }
}