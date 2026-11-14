using Articles.Abstractions.Enums;
using Blocks.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Persistance.EntityConfigrations
{
    public class ArticleActorEntityConfiguration : IEntityTypeConfiguration<ArticleActor>
    {
        public void Configure(EntityTypeBuilder<ArticleActor> builder)
        {
            builder.HasKey(a => new { a.ArticleId, a.PersonId ,a.Role});
            builder.Property(a=>a.Role).HasEnumConversion().HasDefaultValue(UserRoleType.Author);

           builder.HasDiscriminator(e => e.TypeDiscriminator)
                  .HasValue<ArticleActor>(nameof(ArticleActor))
                  .HasValue<ArticleAuthor>(nameof(ArticleAuthor));
            builder.HasOne(a => a.Article)
                .WithMany(a => a.Actors)
                .HasForeignKey(a => a.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Person)
                .WithMany(a => a.Actors)
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
