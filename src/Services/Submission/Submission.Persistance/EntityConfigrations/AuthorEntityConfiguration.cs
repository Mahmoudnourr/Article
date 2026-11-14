using Blocks.EntityFrameWork.EntityConfiguration;
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
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<Author>
    {
        public  void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(e=>e.Degree).HasMaxLength(100)
                .HasComment("The author's main field of study or research (e.g., Biology, Physics)");
            builder.Property(e => e.Discipline).HasMaxLength(100)
                .HasComment("The author's highest level of education or academic qualification (e.g., Bachelor's, Master's, PhD)");
        }
    }
}
