using System;
using System.Collections.Generic;
using System.Text;

namespace TOH.Data.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }
    }
}
