using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandCasinoLB;
using GrandCasinoLB.Roulette;
namespace GrandCasinoLB_TestProj
{
    [TestClass]
    internal class UnitTestRoulette
    {
        [TestMethod]
        public void CalculatePayoutWinningBetReturnsCorrectPayoutOnColorBetBlack()
        {
            // Arrange
            RouletteGame table = new RouletteGame(null);
            table.BetType = "b";
            table.Bet = 50;
            int expectedResult = 100; // Expected payout for a winning bet

            // Act
            int result = table.CalculatePayout();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void CalculatePayoutWinningBetReturnsCorrectPayoutOnColorBetRed()
        {
            // Arrange
            RouletteGame table = new RouletteGame(null);
            table.BetType = "r";
            table.Bet = 50;
            int expectedResult = 100; // Expected payout for a winning bet

            // Act
            int result = table.CalculatePayout();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void CalculatePayoutWinningBetReturnsCorrectPayoutOnNumberBet()
        {
            // Arrange
            RouletteGame table = new RouletteGame(null);
            table.BetType = "18";
            table.Bet = 50;
            int expectedResult = 1750; // Expected payout for a winning bet

            // Act
            int result = table.CalculatePayout();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
