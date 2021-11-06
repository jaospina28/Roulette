using System;
using System.ComponentModel.DataAnnotations;

namespace Roulette.Core.Entities
{
    public class Player
    {
        public Player()
        {
            CreatedAt = DateTime.UtcNow;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
