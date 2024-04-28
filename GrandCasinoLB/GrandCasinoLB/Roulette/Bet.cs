namespace GrandCasinoLB.Roulette
{
    public class Bet
    {
        public string Player { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string Type { get; set; } = string.Empty; //For example, Red, Black, Number etc.
    }
}