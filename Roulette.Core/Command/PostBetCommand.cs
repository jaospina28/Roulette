namespace Roulette.Core.Command
{
    public class PostBetCommand
    {
        public int RouletteId { get; set; }
        public int PlayerId { get; set; }
        public int NumberBet { get; set; }
        public string ColorBet { get; set; }
        public double MoneyBet { get; set; }
    }
}
