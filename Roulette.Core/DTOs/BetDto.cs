using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Core.DTOs
{
    public class BetDto
    {
        public int Id { get; set; }
        public int RouletteId { get; set; }
        public int PlayerId { get; set; }
        public int? NumberBet { get; set; }
        public string ColorBet { get; set; }
        public double MoneyBet { get; set; }
    }
}
