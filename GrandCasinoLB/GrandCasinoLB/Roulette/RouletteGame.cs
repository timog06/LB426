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
        }

        public void PlaceBet()
        {
        Dictionary<string, int> bets = new Dictionary<string, int>();

            do
            {
                Console.WriteLine("Please type in the betting type [b] if you want to bet on black, [r] if you want to bet on red, or just any number from 0 - 36 if you want to bet on a number. Type 'done' when finished.");
                string betType = Console.ReadLine();

                if (betType.ToLower() == "done")
                {
                    break;
                }

                if (IsBetValid(betType))
                {
                    string amount;
                    do
                    {
                        Console.WriteLine($"Please type a bet amount for {betType}: ");
                        amount = Console.ReadLine();

                    } while (!IsAmountValid(amount));

                    int bet = Convert.ToInt32(amount);
                    _chipsObservable.Chips -= bet;

                    if (bets.ContainsKey(betType))
                    {
                        bets[betType] += bet;
                    }
                    else
                    {
                        bets[betType] = bet;
                    }
                }
            } while (true);

        // Continue with the game if there are any bets placed
        if (bets.Count > 0)
        {
            Payout(spinCommand.Execute(), bets);
        }
}
        public void Payout(int number, Dictionary<string, int> bets)
        {
            foreach (var bet in bets)
            {
                string betType = bet.Key;
                int betAmount = bet.Value;

                if (betType == "r")
        {
            if ("red" == _numberColorMap[number])
            {
                _chipsObservable.Chips += 2 * betAmount;
                Console.WriteLine($"You won {2 * betAmount} chips on the red bet!");
            }
        }
        else if (betType == "b")
        {
            if ("black" == _numberColorMap[number])
            {
                _chipsObservable.Chips += 2 * betAmount;
                Console.WriteLine($"You won {2 * betAmount} chips on the black bet!");
            }
        }
        else
        {
            int numberBet = Convert.ToInt32(betType);
            if (numberBet == number)
            {
                _chipsObservable.Chips += 35 * betAmount;
                    Console.WriteLine($"Congratulations! You won {35 * betAmount} chips on the number {numberBet} bet!");
                    }
                    else
                    {
                        Console.WriteLine($"You lost {betAmount} chips on the number {numberBet} bet.");
                    }
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
