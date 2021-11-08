using Roulette.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roulette.Core.Entities
{
    public class Bet : Entity
    {
        public int RouletteId { get; set; }
        public int PlayerId { get; set; }
        public int? NumberBet { get; set; }
        public string ColorBet { get; set; }
        public double MoneyBet { get; set; }
        [ForeignKey("RouletteId")]
        public Roulette Roulette { get; set; }
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }
    }
}
