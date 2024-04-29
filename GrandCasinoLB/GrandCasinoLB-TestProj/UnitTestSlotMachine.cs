using GrandCasinoLB;

namespace GrandCasinoLB_TestProject
{
    [TestClass]
    public class SlotMachineTests
    {
        private const string JackpotResult = "7 7 7";
        private const string TwoSameResult = "7 7 5";
        private const string NoneMatchResult = "1 3 5";

        private StringWriter stringWriter;
        private StringReader stringReader;

        [TestInitialize]
        public void Initialize()
        {
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [TestMethod]
        public void PlayGame_AllSlotsMatch_ReturnsJackpot()
        {
            // Arrange
            stringReader = new StringReader("100" + Environment.NewLine);
            Console.SetIn(stringReader);
            var slotMachine = new SlotMachine();

            // Act
            string output = GetConsoleOutput(() => slotMachine.PlayGame());

            // Assert
            Assert.IsTrue(output.Contains(JackpotResult));
            Assert.IsTrue(output.Contains("You won 1000 chips!"));
        }

        [TestMethod]
        public void PlayGame_TwoSlotsMatch_ReturnsPrize()
        {
            // Arrange
            stringReader = new StringReader("100" + Environment.NewLine);
            Console.SetIn(stringReader);
            var slotMachine = new SlotMachine();

            // Act
            string output = GetConsoleOutput(() => slotMachine.PlayGame());

            // Assert
            Assert.IsTrue(output.Contains(TwoSameResult));
            Assert.IsTrue(output.Contains("You won 200 chips!"));
        }

        [TestMethod]
        public void PlayGame_NoSlotsMatch_ReturnsLoss()
        {
            // Arrange
            stringReader = new StringReader("100" + Environment.NewLine);
            Console.SetIn(stringReader);
            var slotMachine = new SlotMachine();

            // Act
            string output = GetConsoleOutput(() => slotMachine.PlayGame());

            // Assert
            Assert.IsTrue(output.Contains(NoneMatchResult));
            Assert.IsTrue(output.Contains("Better luck next time!"));
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