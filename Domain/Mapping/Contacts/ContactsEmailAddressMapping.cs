namespace Domain.Mapping.Contacts;

public class ContactsEmailAddressMapping : IEntityTypeConfiguration<ContactsEmailAddress>
{
    public void Configure(EntityTypeBuilder<ContactsEmailAddress> builder)
    {
        builder.ToTable("ContactsEmailAddress");
        builder.HasKey(x => x.CustomersEmailAddressId);
        builder.Property(x => x.CustomersEmailAddrs).HasMaxLength(255).IsRequired();
    }
}