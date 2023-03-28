namespace Domain.Mapping.Contacts;

public class ContactMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(x => x.ContactId);
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.MobileNumber).HasMaxLength(255).IsRequired();
    }
}