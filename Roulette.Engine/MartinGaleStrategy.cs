using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Engine
{
    public class MartinGaleStrategy : IStrategy
    {
        public bool InvertColorIfLose { get; set; }
        public int TurnNumber { get; private set; }
        readonly int baseBetAmount;
        bool winLastBest = true;
        int lastBet = 1;
        EnumColor lastColor = EnumColor.Black;

        public MartinGaleStrategy(int baseBetAmount)
        {
            this.TurnNumber = 0;
            this.baseBetAmount = baseBetAmount;
        }
        
        public List<Bet> GetBets()
        {
            TurnNumber++;

            List<Bet> bets = new List<Bet>();
            if (winLastBest)
            {
                // minimun bet
                bets.Add(new Bet()
                {
                    Amount = baseBetAmount,
                    BetKind = Bet.EnumBetKind.BetInColor,
                    Color = lastColor,
                });
            }
            else
            {
                // double last bet
                bets.Add(new Bet()
                {
                    Amount = lastBet * 2,
                    BetKind = Bet.EnumBetKind.BetInColor,
                    Color = lastColor,
                });
            }

            lastBet = bets.Sum(s => s.Amount);
            return bets;
        }

        public void Won()
        {
            this.winLastBest = true;
        }

        public void Lose()
        {
            this.winLastBest = false;
            if (this.InvertColorIfLose)
            {
                lastColor = lastColor == EnumColor.Black ? EnumColor.Red : EnumColor.Black;
            }
        }
    }
}
