using Blocks.EntityFrameWork.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Submission.Domain.Entities;

namespace Submission.Persistance.EntityConfigrations;

public class JournalEntityConfiguration : IEntityConfiguration<Journal>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Journal> builder)
    {
        base.Configure(builder);
        builder.Property(j => j.Name).IsRequired().HasMaxLength(200);
        builder.Property(j => j.Abreviation).IsRequired().HasMaxLength(500);
    }
}
