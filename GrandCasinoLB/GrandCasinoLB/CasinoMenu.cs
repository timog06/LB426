using System;

namespace GrandCasinoLB
{
    public class CasinoMenu
    {
        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.Title = "Grand Casino LB";
                Console.WriteLine("Welcome to Grand Casino LB!");
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Bank");
                Console.WriteLine("3. Quit");
                Console.Write("Choose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlayGame();
                        break;
                    case "2":
                        Bank();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void PlayGame()
        {
            Console.Clear();
            Console.WriteLine("Roulette (1) / Slot Machine (2)");
            Console.Write("Choose: ");
            string gameChoice = Console.ReadLine();

            switch (gameChoice)
            {
                case "1":
                    // PlayRoulette();
                    break;
                case "2":
                    PlaySlotMachine();
                    break;
                case "3":
                    // Add more games if wanted
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    Console.ReadKey();
                    break;
            }
        }

        /*
        private void PlayRoulette()
        {
            Roulette roulette = new Roulette();
            roulette.PlayGame();
        }
        */

        private void PlaySlotMachine()
        {
            SlotMachine slotMachine = new SlotMachine();
            slotMachine.PlayGame();
        }

        public void Bank()
        {
            Console.Clear();
            Console.WriteLine("How much money do you want to turn into chips?");
            Console.Write("Enter amount: ");
            string amount = Console.ReadLine();

            Console.WriteLine($"You turned {amount} into chips.");
            Console.ReadKey();
        }
    }
}
