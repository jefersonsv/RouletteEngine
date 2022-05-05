using Roulette.Engine;

using System;
using System.Linq;

namespace RouletteEngine
{
    public class Pocket
    {
        int balance;
        int goal;

        public Pocket(int initialAmount, int goal)
        {
            balance = initialAmount;
            this.goal = goal;
        }

        public void Deposit(int amount)
        {
            this.balance += amount;
        }

        public bool ReachGoal() => this.balance >= this.goal;
        public int Balance() => this.balance;

        public bool Withdraw(int amount)
        {
            if (this.balance - amount <= 0)
            {
                return false;
            }
            else
            {
                this.balance -= amount;
                return true;
            }
        }
    }
}
