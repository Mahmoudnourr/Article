using Microsoft.EntityFrameworkCore;
using Submission.Domain.Entities;

namespace Submission.Persistance;

public class SubmissionDbContext : DbContext
{
    public SubmissionDbContext(DbContextOptions<SubmissionDbContext> options)
        : base(options)
    {
        
    }


    #region Entities
    public DbSet<Journal> Journals { get; set; } 
    public DbSet<Article> Articles { get; set; }
    #endregion
}
