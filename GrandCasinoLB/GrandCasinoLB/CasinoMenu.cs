namespace GrandCasinoLB
{
    public class CasinoMenu
    {
        public void Run()
        {
            Console.Clear();
            Console.Title = "Grand Casino LB";
            Console.WriteLine("Welcome to Grand Casino LB!");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Bank");
            Console.WriteLine("3. Quit");
            Console.ReadLine();
        }
        public void Bank()
        {
            Console.Clear();
            Console.WriteLine("How much money do you want to turn into chips?");
            Console.Write("Enter amount: ");
            string amount = Console.ReadLine();
            Console.WriteLine($"You turned {amount}$ into chips.");
            Console.ReadKey();
        }

        public void PlayGame()
        {
            
        }
    }
}
