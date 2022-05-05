using System;

namespace RouletteEngine
{
    public class Statistics
    {
        public Roulette.Engine.EnumColor ColorBet { get; set; }
        public int NumberResult { get; set; }
        public Roulette.Engine.EnumColor ColorResult { get; set; }
        public int Round { get; set; }
        public int BetAmount { get; set; }
        public int Prize { get; set; }
        public int PocketAmount { get; set; }

        public override string ToString()
        {
            var winLose = Prize > 0 ? "WIN $ " + Prize : "LOSE";
            return $"Round {Round} > [{ColorBet.ToString()}] Bet Amount $ {BetAmount} > ({winLose}) > Number: {NumberResult} [{ColorResult.ToString()}] > Pocket $ {PocketAmount}";
        }
    }
}
