using Roulette.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Roulette.Core.Entities
{
    public class Roulette : Entity
    {
        public string Name { get; set; }
        public bool RouletteStatus { get; set; }
        public DateTime CloseAt { get; set; }
    }
}
