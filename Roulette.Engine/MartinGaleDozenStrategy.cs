using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Engine
{
    public class MartinGaleDozenStrategy : IStrategy
    {
        public bool NextDozenIfLose { get; set; }
        public int TurnNumber { get; private set; }
        readonly int baseBetAmount;
        bool winLastBest = true;
        int lastBet = 0;
        EnumDozen lastDozen = EnumDozen.FirstDozen;

        public MartinGaleDozenStrategy(int baseBetAmount)
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
                    BetKind = Bet.EnumBetKind.BetInDozen,
                    Dozen = EnumDozen.FirstDozen,
                });
                bets.Add(new Bet()
                {
                    Amount = baseBetAmount,
                    BetKind = Bet.EnumBetKind.BetInDozen,
                    Dozen = EnumDozen.SecondDozen,
                });
            }
            else
            {
                // double last bet
                bets.Add(new Bet()
                {
                    Amount = lastBet * 3,
                    BetKind = Bet.EnumBetKind.BetInDozen,
                    Dozen = EnumDozen.FirstDozen,
                });
                bets.Add(new Bet()
                {
                    Amount = lastBet * 3,
                    BetKind = Bet.EnumBetKind.BetInDozen,
                    Dozen = EnumDozen.SecondDozen,
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
            if (this.NextDozenIfLose)
            {
                if (lastDozen == EnumDozen.FirstDozen)
                    lastDozen = EnumDozen.SecondDozen;
                else if (lastDozen == EnumDozen.SecondDozen)
                    lastDozen = EnumDozen.ThirdDozen;
                else
                    lastDozen = EnumDozen.FirstDozen;
            }
        }
    }
}
