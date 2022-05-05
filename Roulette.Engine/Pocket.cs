using Roulette.Engine;

using System;
using System.Linq;

namespace Roulette.Engine
{
    public class Pocket
    {
        int amount;
        int goal;

        public Pocket(int initialAmount, int goal)
        {
            amount = initialAmount;
            this.goal = goal;
        }

        public void Deposit(int amount)
        {
            this.amount += amount;
        }

        public bool ReachGoal() => this.amount >= this.goal;
        public int Balance() => this.amount;

        public void Withdraw(int amount)
        {
            this.amount -= amount;

            if (this.amount <= 0)
            {
                throw new Exception("You are broken");
            }
        }
    }
}
