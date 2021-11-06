using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Core.DTOs
{
    public class RouletteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool RouletteStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CloseAt { get; set; }
    }
}
