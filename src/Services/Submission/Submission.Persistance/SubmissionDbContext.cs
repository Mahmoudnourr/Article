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
    public  DbSet<Person> Persons { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<ArticleActor> ArticleActors { get; set; }
    #endregion
}
