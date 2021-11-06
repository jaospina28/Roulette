using System;
using System.ComponentModel.DataAnnotations;

namespace Roulette.Core.Entities
{
    public class Roulette
    {
        public Roulette()
        {
            CreatedAt = DateTime.UtcNow;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool RouletteStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CloseAt { get; set; }
    }
}
