﻿namespace Domain.Mapping.Contacts;

public class ContactMapping : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(x => x.ContactId);
        builder.Property(x => x.FirstName).HasMaxLength(255).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(255).IsRequired();


        builder.HasOne(x => x.ContactPhoneNumber).WithMany(x => x.Contacts).HasForeignKey(x => x.MobileNumberId);
        builder.HasOne(x => x.ContactsEmailAddress).WithMany(x => x.Contacts).HasForeignKey(x => x.EmailId);
        builder.HasOne(x => x.ContactGroup).WithMany(x => x.Contacts).HasForeignKey(x => x.ContactGroupId);
    }
}