using Articles.Abstractions.Enums;
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
    public class PersonEntityConfiguration : IEntityConfiguration<Person>
    {
        public override void Configure( EntityTypeBuilder<Person> builder)
        {
          base.Configure(builder);
          builder.HasIndex(x=>x.Id).IsUnique();
            builder.HasDiscriminator(e => e.TypeDiscriminator)
                  .HasValue<Person>(nameof(Person))
                  .HasValue<Author>(nameof(Author));
      
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
          builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
          builder.Property(p => p.Affiliation).IsRequired().HasMaxLength(512)
          .HasComment("Institution or Organization they are associated with when they conduct research");
          builder.Property(p => p.Title).HasMaxLength(100);
          builder.Property(p=>p.UserId).IsRequired(false);

            builder.ComplexProperty(
                o => o.Email, builder =>
                {
                    builder.Property(p => p.value).IsRequired().HasMaxLength(256).HasColumnName(builder.Metadata.PropertyInfo!.Name);
                }
                );
        }
    }
}
