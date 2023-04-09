namespace Domain.Mapping.Contacts;

public class ContactGroupMapping : IEntityTypeConfiguration<ContactGroup>
{
    public void Configure(EntityTypeBuilder<ContactGroup> builder)
    {
        builder.ToTable("ContactGroups");
        builder.HasKey(x => x.ContactGroupId);
        builder.Property(x => x.GroupName).HasMaxLength(255).IsRequired();

        builder.HasOne(x => x.Business).WithMany(x => x.ContactGroups).HasForeignKey(x => x.BusinessId);
    }
}