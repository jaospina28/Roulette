using Roulette.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Roulette.Core.Entities
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public double Money { get; set; }
    }
}
