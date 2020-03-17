using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using TOH.Data.DatabaseContext;
using TOH.Data.Entities;
using TOH.Data.Repository.Contracts;

namespace TOH.Data.Repository.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly HeroesContext context;
        private DbSet<TEntity> dbSet;

        public Repository(HeroesContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public bool AddHero(string name)
        {
            try
            {
                this.context.Add(new Hero { Name = name });
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.Write("Exception adding new heroe: " + e);
                return false;
            }
        }

        public bool UpdateHero(long id, string name)
        {
            if ( !string.IsNullOrEmpty(name) )
            {
                Hero hero = this.context.Find<Hero>(id);
                if (hero != null)
                {
                    try
                    {
                        hero.Id = id;
                        hero.Name = name;
                        this.context.Update<Hero>(hero);
                        this.context.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.Write("Exception updating new heroe: " + e);
                        return false;
                    }
                }
                else
                {
                    Console.Write("There is no hero with id = " + id);
                    return false;
                }
            }
            else
            {
                Console.Write("The name of the hero cannot be empty");
                return false;
            }
        }

        public bool DeleteHero(long id)
        {
            if (id > 0)
            {
                Hero hero = this.context.Find<Hero>(id);
                if (hero != null)
                {
                    try
                    {
                        this.context.Remove<Hero>(hero);
                        this.context.SaveChanges();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.Write("Exception deleting hero: " + hero.Name + " - " + e);
                        return false;
                    }
                }
                else
                {
                    Console.Write("There is no hero with id = " + id);
                    return false;
                }
            }
            else
            {
                Console.Write("The id of the hero cannot be less than 1");
                return false;
            }
        }
        public IEnumerable<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            return this.dbSet.Where(filter).ToList();
        }

        public TEntity GetById(long Id)
        {
            return this.dbSet.Where(x => x.Id == Id).Single();
                //First(x => x.Id == Id);
        }

        public IQueryable<TEntity> GetHeroes()
        {
            return this.Query();
        }

        public IQueryable<TEntity> Query()
        {
            return this.dbSet;
        }

    }
}
