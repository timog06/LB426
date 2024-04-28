using System;
using System.Threading;

namespace GrandCasinoLB
{
    internal class SlotMachine
    {
        private const int FixedBet = 10; 
        private const int MaxSlotValue = 9;
        private const int NumSlots = 3;
        private readonly Random _random;

        private int _chips;

        public SlotMachine(int currentChips)
        {
            _random = new Random();
            _chips = currentChips;
        }

        public void PlayGame()
        {
            if (_chips < FixedBet)
            {
                Console.Clear();
                Console.WriteLine("Not enough chips to play.");
                Console.WriteLine("Press any key to go back.");
                Console.ReadKey();
                return; 
            }

            Console.Clear();
            Console.WriteLine("Welcome to the Slot Machine!");

            Console.WriteLine($"You are betting {FixedBet} chips.");
            Console.WriteLine("Spinning...");

            _chips -= FixedBet;

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
                _chips += winnings;
            }
            else
            {
                Console.WriteLine("Better luck next time!");
            }

            Console.WriteLine("Press (1) to go back to the menu or press Enter to play again.");
            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                return;
            }
            else
            {
                PlayGame();
            }
        }

        public int CalculateWinnings(int[] slots, int bet)
        {
            int uniqueCount = slots.Distinct().Count();

            switch (uniqueCount)
            {
                case 1:
                    return bet * 10; // If all slots are the same
                case 2:
                    return bet * 2; // If two slots are the same
                default:
                    return 0;
            }
        }

        public int GetCurrentChips()
        {
            return _chips;
        }
    }
}
