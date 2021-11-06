using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Core.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
