namespace GrandCasinoLB
{
    public class SlotMachine
    {
        private const int FixedBet = 10;
        private const int MaxSlotValue = 9;
        private const int NumSlots = 3;
        private readonly Random _random;

        public SlotMachine()
        {
            _random = new Random();
        }

        public void PlayGame()
        {
            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Slot Machine!");

                Console.WriteLine($"You are betting {FixedBet} chips.");
                Console.WriteLine("Spinning...");

                int[] slots = new int[NumSlots];

                for (int i = 0; i < NumSlots; i++)
                {
                    Thread.Sleep(500);
                    slots[i] = _random.Next(0, MaxSlotValue + 1);
                    Console.Write(slots[i] + " ");
                }

                Console.WriteLine();

                int winnings = CalculateWinnings(slots, FixedBet);

                if (winnings > 0)
                {
                    Console.WriteLine($"You won {winnings} chips!");
                }
                else
                {
                    Console.WriteLine("Better luck next time!");
                }

                Console.WriteLine("Press (1) to back to the Menu or press Enter to play again");
                string userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    playAgain = false;
                }
                else
                {
                    Console.ReadKey();
                }
            }
        }

        // Die Kalkulation wurde mit Hilfe von Claude.ai erstellt
        private int CalculateWinnings(int[] slots, int bet)
        {
            int uniqueCount = slots.Distinct().Count();

            switch (uniqueCount)
            {
                case 1:
                    return bet * 10; // Gewinn mit 3 gleichen Nummern
                case 2:
                    return bet * 2; // Gewinn mit 2 gleichen Nummern
                default:
                    return 0;
            }
        }
    }
}
