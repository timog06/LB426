namespace GrandCasinoLB.Roulette
{
    // Concrete Command
    class SpinCommand : ICommand
    {
        private RouletteTable _rouletteTable;

        public SpinCommand(RouletteTable rouletteTable)
        {
            _rouletteTable = rouletteTable;
        }

        public int Execute()
        {
            int result = _rouletteTable.Spin();
            return result;
        }
    }
}
