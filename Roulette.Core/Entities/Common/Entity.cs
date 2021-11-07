using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Roulette.Core.Entities.Common
{
    public abstract class Entity
    {
        public Entity()
        {
            CreatedAt = DateTime.UtcNow;
        }
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
