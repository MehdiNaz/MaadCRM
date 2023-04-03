﻿namespace Domain.Mapping.Customers.Note;

public class NoteHashTagMapping : IEntityTypeConfiguration<NoteHashTag>
{
    public void Configure(EntityTypeBuilder<NoteHashTag> builder)
    {
        builder.ToTable("CustomerHashTags");
        builder.HasKey(x => x.NoteHashTagId);
        builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
    }
}