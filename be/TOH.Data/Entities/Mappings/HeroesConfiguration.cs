using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TOH.Data.Entities.Mappings
{
    public class HeroesConfiguration
    {
        public HeroesConfiguration(EntityTypeBuilder<Hero> entityBuilder)
        {
        }
    }
}
