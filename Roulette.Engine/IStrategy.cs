using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Engine
{
    public interface IStrategy
    {
        public int TurnNumber { get; }
        public List<Bet> GetBets();
        public void Won();
        public void Lose();
    }
}
