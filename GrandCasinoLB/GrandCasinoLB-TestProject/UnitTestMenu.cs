using GrandCasinoLB;

namespace GrandCasinoLB_TestProject
{
    [TestClass]
    public class CasinoMenuTests
    {
        [TestMethod]
        public void MainMenu_DisplayOptions()
        {
            // Arrange
            var casinoMenu = new CasinoMenu();

            // Act
            string output = GetConsoleOutput(() => casinoMenu.Run());

            // Assert
            Assert.IsTrue(output.Contains("Welcome to Grand Casino LB!"));
            Assert.IsTrue(output.Contains("1. Play"));
            Assert.IsTrue(output.Contains("2. Bank"));
            Assert.IsTrue(output.Contains("3. Quit"));
        }

        private string GetConsoleOutput(Action action)
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            action();

            return writer.ToString();
        }

        [TestMethod]
        public void Bank_ShouldConvertMoneyToChips()
        {
            // Arrange
            var casinoMenu = new CasinoMenu();

            // Act
            string output = GetConsoleOutput(() =>
            {
                casinoMenu.Bank();
                Console.WriteLine("1000");
            });

            // Assert
            Assert.IsTrue(output.Contains("How much money do you want to turn into chips?"));
            Assert.IsTrue(output.Contains("You turned 1000 into chips."));
        }

        [TestMethod]
        public void Play_ShouldDisplayGameOptions()
        {
            // Arrange
            var casinoMenu = new CasinoMenu();
            int RouletteOption = 1;

            // Act
            string output = GetConsoleOutput(() =>
            {
                casinoMenu.PlayGame();
                Console.WriteLine(RouletteOption);
            });

            // Assert
            Assert.IsTrue(output.Contains("Roulette (1) / Slot Machine (2)"));
            Assert.IsTrue(output.Contains("You chose Roulette!"));
        }
    }
}