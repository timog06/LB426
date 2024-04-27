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


    }
}