using Blocks.Domain.Entities;
using Blocks.EntityFrameWork.Repo;
using Blocks.Exceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blocks.EntityFrameWork;

public static class RepositoryExtentions 
{
    public async static  Task<TEntity> FindByIdOrThrowAsync<TEntity,TContext>(this Repository<TEntity,TContext> repository, int id) 
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        var entity = await repository.FindByIdAsync(id);
        if (entity == null)
        {
            throw new NotFoundException($"{typeof(TEntity).Name} with id {id} not found.");
        }
    
        return entity;
    } 
                         
}

