using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TOH.Data.Entities;
using TOH.Data.Repository;
using TOH.Data.Repository.Contracts;
using TOH.Data.Repository.GenericRepository;
using TOH.Models;

namespace TOH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IRepository<Hero> heroesRepository;
        public HeroesController(IRepository<Hero> heroesRepository)
        {
            this.heroesRepository = heroesRepository;
        }
        // GET api/heroes
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public ActionResult<IEnumerable<HeroModel>> Get()
        {
            return (from h in this.heroesRepository.GetHeroes()
                   select new HeroModel
                   {
                       Id = h.Id,
                       Name = h.Name
                   }).ToList();
        }

        // GET api/heroes/5
        [HttpGet("{id}")]
        [EnableCors("AllowAllOrigins")]
        public ActionResult<HeroModel> Get(long id)
        {
            var hero = this.heroesRepository.GetById(id);
            return new HeroModel
            {
                Id = hero.Id,
                Name = hero.Name
            };
        }

        // POST api/heroes
        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public IActionResult Post([FromBody] HeroModel hero)
        {
            if(this.heroesRepository.AddHero(hero.Name))
            {
                return NoContent();
            }
            return NotFound();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [EnableCors("AllowAllOrigins")]
        public IActionResult Put(long id, [FromBody] HeroModel hero)
        {
            if (this.heroesRepository.UpdateHero(id, hero.Name))
            {
                return NoContent();
            }
            return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [EnableCors("AllowAllOrigins")]
        public IActionResult Delete(long id)
        {
            if (this.heroesRepository.DeleteHero(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
