namespace Domain.Mapping.Contacts;

public class ContactMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(255);
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.ContactGroup)
            .WithMany(x => x.Contacts)
            .HasForeignKey(x => x.ContactGroupId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ContactGroup_Contact");
    }
}