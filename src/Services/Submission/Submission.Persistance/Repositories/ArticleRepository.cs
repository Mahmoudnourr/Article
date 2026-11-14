using Blocks.EntityFrameWork.Repo;
using Submission.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Persistance.Repositories
{
    public class ArticleRepository(SubmissionDbContext dbContext) : Repository<Article>(dbContext)
    {
    }
}
