namespace Domain.Mapping.Contacts;

public class ContactsEmailAddressMapping : IEntityTypeConfiguration<ContactsEmailAddress>
{
    public void Configure(EntityTypeBuilder<ContactsEmailAddress> builder)
    {
        builder.ToTable("ContactsEmailAddress");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ContactEmailAddress).HasMaxLength(255).IsRequired();
    }
}