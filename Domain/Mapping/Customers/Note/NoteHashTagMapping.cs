﻿namespace Domain.Mapping.Customers.Note;

public class NoteHashTagMapping : IEntityTypeConfiguration<CustomerNoteHashTag>
{
    public void Configure(EntityTypeBuilder<CustomerNoteHashTag> builder)
    {
        builder.ToTable("NoteHashTags");
        builder.HasKey(x => new {x.IdCustomerNote, x.IdNoteHashTable});
        
        builder.Property(e => e.Version)
            .IsRowVersion();
        
        builder.HasOne(x => x.IdNoteHashTableNavigation)
            .WithMany(x => x.CustomerNoteHashTags)
            .HasForeignKey(x => x.IdNoteHashTable)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerNoteHashTag_CustomerNoteHashTable");
    }
}