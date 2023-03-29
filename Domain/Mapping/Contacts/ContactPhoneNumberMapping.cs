namespace Domain.Mapping.Contacts;

public class ContactPhoneNumberMapping : IEntityTypeConfiguration<ContactPhoneNumber>
{
    public void Configure(EntityTypeBuilder<ContactPhoneNumber> builder)
    {
        builder.ToTable("ContactPhoneNumbers");
        builder.HasKey(x => x.ContactPhoneNumberId);
        builder.Property(x => x.PhoneNo).HasMaxLength(255).IsRequired();
    }
}