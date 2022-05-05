using Roulette.Engine;

using System;
using System.Linq;

namespace RouletteEngine
{
    static class Program
    {
        static void Main(string[] args)
        {
            Statistics statistics = new Statistics();

            int win = 0;
            int lose = 0;
            int total = 0;

            for (int i = 0; i < 100; i++)
            {
                var strategy = new MartinGaleDozenStrategy(1);
                var res = DoTest(statistics, 1025, 2, strategy);
                if (res > 1025)
                    win++;
                else 
                    lose++;

                total += res;
                total -= 1025;
            }

            double pct = Math.Round((double)lose / win, 2) * 100;
            Console.WriteLine(pct);
            Console.WriteLine(total);
        }

        static int DoTest(Statistics statistics, int amount, double profit, IStrategy strategy)
        {
            var wish = amount * ((profit / 100) + 1);
            RouletteTable rouletteTable = new RouletteTable();
            Pocket pocket = new Pocket(amount, Convert.ToInt32(Math.Round(wish, 0)));

            do
            {
                var bets = strategy.GetBets();
                statistics.BetAmount = bets.Sum(s => s.Amount);
                statistics.ColorBet = EnumColor.Green; // bets.First().Color.Value;

                var canPlay = pocket.Withdraw(statistics.BetAmount);

                if (!canPlay)
                    break;

                foreach (var item in bets)
                {
                    rouletteTable.DoBet(item);
                }

                var results = rouletteTable.Spin();

                var prize = results.Prizes.Sum(s => s.Amount);
                statistics.Prize = prize;
                statistics.ColorResult = results.Number.Color;
                statistics.NumberResult = results.Number.Number;

                if (prize > 0)
                {
                    strategy.Won();
                    pocket.Deposit(prize);
                }
                else
                {
                    strategy.Lose();
                }

                statistics.Round = strategy.TurnNumber;
                statistics.PocketAmount = pocket.Balance();
                Console.WriteLine(statistics.ToString());
            } while (!pocket.ReachGoal());

            return pocket.Balance();
        }
    }
}
