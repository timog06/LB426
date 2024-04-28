namespace GrandCasinoLB.Roulette
{
    public class SpinWheelCommand : ICommand
    {
        RouletteGame game;

        public SpinWheelCommand(RouletteGame game)
        {
            this.game = game;
        } 
        public void Execute()
        {
            game.SpinWheel();
        }
    }
}