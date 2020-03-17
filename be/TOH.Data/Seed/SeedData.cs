using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TOH.Data.DatabaseContext;
using TOH.Data.Entities;
using TOH.Data.Repository.Contracts;

namespace TOH.Models.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HeroesContext(
                serviceProvider.GetRequiredService<DbContextOptions<HeroesContext>>()))
            {
                var first = 1;
                if (context.Heroes.Find((long)first) != null)
                {
                    return;   // DB has been seeded
                }

                context.Heroes.AddRange(
                    new Hero
                    {
                        //Id = 11,
                        Name = "Superman"
                    },

                    new Hero
                    {
                        //Id = 12,
                        Name = "Batman"
                    },

                    new Hero
                    {
                        //Id = 13,
                        Name = "Spiderman"
                    },

                    new Hero
                    {
                        //Id = 14,
                        Name = "Deathpool"
                    },

                    new Hero
                    {
                        //Id = 15,
                        Name = "Wonderwoman"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}