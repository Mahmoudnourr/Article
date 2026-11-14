using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;
using Blocks.EntityFrameWork;
using Blocks.EntityFrameWork.EntityConfiguration;

namespace Submission.Persistance.EntityConfigrations;

public class ArticleEntityConfiguration : IEntityConfiguration<Article>
{
    public override void Configure(EntityTypeBuilder<Article> builder)
    {
       base.Configure(builder);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
        builder.Property(a => a.Scope).IsRequired().HasMaxLength(2048);

        builder.Property(b=>b.Stage).HasEnumConversion();
        builder.Property(b => b.Type).HasEnumConversion();


        builder.HasOne(a => a.Journal)
            .WithMany(a=>a.Articles)
            .HasForeignKey(a => a.JournalId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
