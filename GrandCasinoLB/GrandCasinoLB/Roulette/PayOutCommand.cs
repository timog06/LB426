namespace GrandCasinoLB.Roulette
{
    public class PayOutCommand : ICommand
    {
        RouletteGame game;

        public PayOutCommand(RouletteGame game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.PayOut();
        }
    }
}
