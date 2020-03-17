using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using TOH.Data.Entities;
using TOH.Models;

namespace TOH.Data.Repository.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> Query();
        IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetHeroes();
        TEntity GetById(long Id);
        bool AddHero(string Name);
        bool UpdateHero(long Id, string Name);
        bool DeleteHero(long Id);
    }
}
