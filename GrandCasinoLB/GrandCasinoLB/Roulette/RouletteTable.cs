namespace GrandCasinoLB.Roulette
{
    public class RouletteTable
    {
        public int Spin()
        {
            Random rand = new Random();
            int result = rand.Next(0, 36);
            Console.WriteLine($"The ball landed on {result}!");
            return result;
        }
    }
}
