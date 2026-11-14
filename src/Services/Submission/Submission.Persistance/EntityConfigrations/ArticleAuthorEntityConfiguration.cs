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
    public class ArticleAuthorEntityConfiguration : IEntityTypeConfiguration<ArticleAuthor>
    {
        public void Configure(EntityTypeBuilder<ArticleAuthor> builder)
        {
            builder.Property(e => e.ContributionAreas).HasJsonConversion().IsRequired();
        }
    }
}
