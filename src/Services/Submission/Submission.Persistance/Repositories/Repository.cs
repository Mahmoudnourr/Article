using Blocks.Domain.Entities;
using Blocks.EntityFrameWork.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission.Persistance.Repositories
{
    public class Repository <TEntity>(SubmissionDbContext dbContext) : Repository<TEntity, SubmissionDbContext>(dbContext) where TEntity : class, IEntity
    {
    }
}
