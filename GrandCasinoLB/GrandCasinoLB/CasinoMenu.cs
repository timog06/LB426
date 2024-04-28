﻿using System;

namespace GrandCasinoLB
{
    public class CasinoMenu
    {
        private int _chips;

        public CasinoMenu()
        {
            _chips = 0;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.Title = "Grand Casino LB";
                Console.WriteLine($"Welcome to Grand Casino LB! You have {_chips} chips.");
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
            if (_chips == 0)
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
                    Console.WriteLine("Roulette is currently unavailable.");
                    Console.ReadKey();
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

        private void PlaySlotMachine()
        {
            if (_chips < 10) 
            {
                Console.WriteLine("You need at least 10 chips to play the Slot Machine.");
                Console.ReadKey();
                return; 
            }

            SlotMachine slotMachine = new SlotMachine(_chips);
            slotMachine.PlayGame(); 

            int winnings = slotMachine.CalculateWinnings(new int[3], 10); 
            _chips += winnings; 
        }

        private void Bank()
        {
            Console.Clear();
            Console.WriteLine("How much money do you want to turn into chips?");
            Console.Write("Enter amount: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int amount))
            {
                _chips += amount;
                Console.WriteLine($"You now have {_chips} chips.");
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a valid number.");
            }

            Console.ReadKey(); 
        }
    }
}
