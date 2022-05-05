using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette.Engine
{
    public class RouletteTable
    {
        public NumberInTable[] Numbers { get; }
        public List<Bet> Bets { get; } = new();

        public RouletteTable()
        {
            Numbers = new NumberInTable[]
            {
                new () { Number = 0, Color = EnumColor.Green, Dozen = null },
                new () { Number = 1, Color = EnumColor.Red, Dozen = EnumDozen.FirstDozen },
                new () { Number = 2, Color = EnumColor.Black, Dozen = EnumDozen.FirstDozen },
                new () { Number = 3, Color = EnumColor.Red, Dozen = EnumDozen.FirstDozen },
                new () { Number = 4, Color = EnumColor.Black, Dozen = EnumDozen.FirstDozen },
                new () { Number = 5, Color = EnumColor.Red, Dozen = EnumDozen.FirstDozen },
                new () { Number = 6, Color = EnumColor.Black, Dozen = EnumDozen.FirstDozen },
                new () { Number = 7, Color = EnumColor.Red, Dozen = EnumDozen.FirstDozen },
                new () { Number = 8, Color = EnumColor.Black, Dozen = EnumDozen.FirstDozen },
                new () { Number = 9, Color = EnumColor.Red, Dozen = EnumDozen.FirstDozen },
                new () { Number = 10, Color = EnumColor.Black, Dozen = EnumDozen.FirstDozen },
                new () { Number = 11, Color = EnumColor.Black, Dozen = EnumDozen.FirstDozen },
                new () { Number = 12, Color = EnumColor.Red, Dozen = EnumDozen.FirstDozen },
                new () { Number = 13, Color = EnumColor.Black, Dozen = EnumDozen.SecondDozen },
                new () { Number = 14, Color = EnumColor.Red, Dozen = EnumDozen.SecondDozen },
                new () { Number = 15, Color = EnumColor.Black, Dozen = EnumDozen.SecondDozen },
                new () { Number = 16, Color = EnumColor.Red, Dozen = EnumDozen.SecondDozen },
                new () { Number = 17, Color = EnumColor.Black, Dozen = EnumDozen.SecondDozen },
                new () { Number = 18, Color = EnumColor.Red, Dozen = EnumDozen.SecondDozen },
                new () { Number = 19, Color = EnumColor.Red, Dozen = EnumDozen.SecondDozen },
                new () { Number = 20, Color = EnumColor.Black, Dozen = EnumDozen.SecondDozen },
                new () { Number = 21, Color = EnumColor.Red, Dozen = EnumDozen.SecondDozen },
                new () { Number = 22, Color = EnumColor.Black, Dozen = EnumDozen.SecondDozen },
                new () { Number = 23, Color = EnumColor.Red, Dozen = EnumDozen.SecondDozen },
                new () { Number = 24, Color = EnumColor.Black, Dozen = EnumDozen.SecondDozen },
                new () { Number = 25, Color = EnumColor.Red, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 26, Color = EnumColor.Black, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 27, Color = EnumColor.Red, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 28, Color = EnumColor.Black, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 29, Color = EnumColor.Black, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 30, Color = EnumColor.Red, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 31, Color = EnumColor.Black, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 32, Color = EnumColor.Red, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 33, Color = EnumColor.Black, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 34, Color = EnumColor.Red, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 35, Color = EnumColor.Black, Dozen = EnumDozen.ThirdDozen },
                new () { Number = 36, Color = EnumColor.Red, Dozen = EnumDozen.ThirdDozen },

            };
        }

        public void DoBet(Bet bet)
        {
            Bets.Add(bet);
        }

        public void BetInColor(EnumColor color, int amount)
        {
            Bets.Add(new()
            {
                Amount = amount,
                Color = color,
                BetKind = Bet.EnumBetKind.BetInColor
            });
        }

        public void BetInDozen(EnumDozen dozen, int amount)
        {
            Bets.Add(new()
            {
                Amount = amount,
                Dozen = dozen,
                BetKind = Bet.EnumBetKind.BetInDozen
            });
        }

        public Result Spin()
        {
            var idx = new Random().Next(0, Numbers.Count());
            var number = Numbers.Single(w => w.Number == idx);

            var result = new Result();
            result.Number = number;

            // Check Bet
            foreach (var item in Bets)
            {
                if (item.BetKind == Bet.EnumBetKind.BetInColor)
                {
                    if (number.Color == item.Color)
                    {
                        result.Prizes.Add(new()
                        {
                            Amount = item.Amount * 2,
                            Bet = item
                        });
                    }
                }
                else if (item.BetKind == Bet.EnumBetKind.BetInDozen)
                {
                    if (number.Dozen == item.Dozen)
                    {
                        result.Prizes.Add(new()
                        {
                            Amount = item.Amount * 3,
                            Bet = item
                        });
                    }
                }
            }

            Bets.Clear();
            return result;
        }
    }

    public class Result
    {
        public NumberInTable Number { get; set; }

        public List<Prize> Prizes { get; } = new();
    }

    public class Prize
    {
        public int Amount { get; set; }
        public Bet Bet { get; set; }
    }

    public class Bet
    {
        public int Amount { get; set; }
        public EnumColor? Color { get; set; }
        public EnumDozen? Dozen { get; set; }
        public EnumBetKind BetKind { get; set; }

        public enum EnumBetKind
        {
            BetInColor,
            BetInDozen
        }
    }

    public class NumberInTable
    {
        public int Number { get; set; }

        public EnumColor Color { get; set; }

        public EnumDozen? Dozen { get; set; }
    }

    public enum EnumColor
    {
        Red,
        Black,
        Green
    }

    public enum EnumDozen
    {
        FirstDozen,
        SecondDozen,
        ThirdDozen
    }
}
