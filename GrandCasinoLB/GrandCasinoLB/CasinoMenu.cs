using GrandCasinoLB.Roulette;
using System;

namespace GrandCasinoLB
{
    public class CasinoMenu : IChipsObserver
    {
        private ChipsObservable _chipsObservable;

        public CasinoMenu()
        {
            _chipsObservable = new ChipsObservable();
            _chipsObservable.AddObserver(this);
        }

        public void ChipsUpdated(int newChips)
        {
            Console.WriteLine($"Chips updated: {newChips}");
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.Title = "Grand Casino LB";
                Console.WriteLine("Welcome to Grand Casino LB!");
                Console.WriteLine($"You currently have {_chipsObservable.Chips} chips.");
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
            if (_chipsObservable.Chips == 0)
            {
                Console.WriteLine("You can't play without chips.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Roulette (1) / Slot Machine (2)");
            Console.Write("Choose: ");
            string gameChoice = Console.ReadLine();
            switch (gameChoice)
            {
                case "1":
                    //PlayRoulette();
                    break;
                case "2":
                    PlaySlotMachine();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    Console.ReadKey();
                    break;
            }
        }
        
        private void PlayRoulette()
        {
            if (_chipsObservable.Chips < 0)
            {
                Console.WriteLine("You can't play Roulette without any chips.");
                Console.ReadKey();
                return;
            }

            RouletteGame roulette = new RouletteGame(_chipsObservable);
            roulette.PlayRoulette();
        }
        

        private void PlaySlotMachine()
        {
            if (_chipsObservable.Chips < 10)
            {
                Console.WriteLine("You need at least 10 chips to play the Slot Machine.");
                Console.ReadKey();
                return;
            }

            SlotMachine slotMachine = new SlotMachine(_chipsObservable);
            slotMachine.PlayGame();
            int winnings = slotMachine.CalculateWinnings(new int[3], 10);
            _chipsObservable.Chips += winnings;
        }

        public void Bank()
        {
            Console.Clear();
            Console.WriteLine("How much money do you want to turn into chips?");
            Console.Write("Enter amount: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int amount))
            {
                _chipsObservable.Chips += amount;
                Console.WriteLine($"You now have {_chipsObservable.Chips} chips.");
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a valid number.");
            }
            Console.ReadKey();
        }
    }
}