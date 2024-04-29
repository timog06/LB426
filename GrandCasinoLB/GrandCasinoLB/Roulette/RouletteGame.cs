using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCasinoLB.Roulette
{

    // Receiver
    public class RouletteGame
    {
        private ChipsObservable _chipsObservable;
        private static Dictionary<int, string> _numberColorMap;
        private SpinCommand spinCommand;
        private static RouletteTable rouletteTable;

        public string BetType { get; set; }
        public int Bet { get; set; }

        public RouletteGame(ChipsObservable chipsObservable)
        {
            _chipsObservable = chipsObservable;
            InitializeNumberColorMap();
            rouletteTable = new RouletteTable();
            spinCommand = new SpinCommand(rouletteTable);
        }

        private static void InitializeNumberColorMap()
        {
            _numberColorMap = new Dictionary<int, string>()
        {
            {0, "green"},
            {1, "red"}, {2, "black"}, {3, "red"}, {4, "black"}, {5, "red"},
            {6, "black"}, {7, "red"}, {8, "black"}, {9, "red"}, {10, "black"},
            {11, "black"}, {12, "red"}, {13, "black"}, {14, "red"}, {15, "black"},
            {16, "red"}, {17, "black"}, {18, "red"}, {19, "red"}, {20, "black"},
            {21, "red"}, {22, "black"}, {23, "red"}, {24, "black"}, {25, "red"},
            {26, "black"}, {27, "red"}, {28, "black"}, {29, "black"}, {30, "red"},
            {31, "black"}, {32, "red"}, {33, "black"}, {34, "red"}, {35, "black"},
            {36, "red"}
            };
        }

        public void PlayRoulette()
        {
            PlaceBet();
            Payout(spinCommand.Execute());


        }

        public void PlaceBet()
        {
            do
            {
                Console.WriteLine("Please type in the betting type [b] " +
                "if you want to bet on black and [r] if you want to bet on red" +
                "or just any number from 0 - 36 if you want to bet on a number.");
                string betType = Console.ReadLine();

                if (IsBetValid(betType))
                {
                    string amount;
                    BetType = betType;
                    do
                    {
                        Console.WriteLine("Please Type a bet amount: ");
                        amount = Console.ReadLine();
                        
                    }while(!IsAmountValid(amount));
                    Bet = Convert.ToInt32(amount);
                }
                _chipsObservable.Chips -= Bet;
                return;
            } while (true);
            
        }
        public void Payout(int number)
        {
            if (BetType == "r")
            {
                if ("red" == _numberColorMap[number])
                {
                    _chipsObservable.Chips += 2 * Bet;
                    Console.WriteLine("Congrats you have won!");
                }
                else return;
            }
            else if (BetType == "b")
            {
                if ("black" == _numberColorMap[number])
                {
                    _chipsObservable.Chips += 2 * Bet;
                    Console.WriteLine("Congrats you have won!");
                }
                else { return; }
            }
            else
            {
                if (Convert.ToInt32(BetType) == number)
                {
                    _chipsObservable.Chips += 35 * Bet;
                    Console.WriteLine("Congratulations you have won!");
                }
                else
                {
                    Console.WriteLine("You have lost.");
                    return;
                }
            }
        }
        static bool IsBetValid(string betType)
        {
            // Check if the bet is a number between 0 and 36
            if (int.TryParse(betType, out int number))
            {
                if (number >= 0 && number <= 36)
                {
                    return true;
                }
            }
            // Check if the bet is 'b' for black or 'r' for red
            else if (betType.ToLower() == "b" || betType.ToLower() == "r")
            {
                return true;
            }

            return false;
        }
        bool IsAmountValid(string amount)
        {
            if (int.TryParse(amount, out int betAmount))
            {
                // Check if the bet amount is positive and not greater than available chips
                if (betAmount > 0 && betAmount < _chipsObservable.Chips)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
