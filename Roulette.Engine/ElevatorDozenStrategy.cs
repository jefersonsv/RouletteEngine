//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Roulette.Engine
//{
//    // ganhou mantem
//    // perdeu coloca uma aposta e meia
//    public class ElevatorDozenStrategy
//    {
//        public int BetNumber { get; private set; }
//        public int Pocket { get; private set; }

//        bool winLastBest = true;
//        readonly int leave;

//        public ElevatorDozenStrategy(int pocket, int leave)
//        {
//            this.Pocket = pocket;
//            this.leave = leave;
//        }
        
//        public int Bet()
//        {
//            BetNumber++;

//            var betAmount = 1;
//            if (!winLastBest)
//            {
//                betAmount = betAmount * 2;
//            }

//            if (Pocket - betAmount < 0)
//            {
//                throw new Exception("Broken");
//            }

//            this.Pocket -= betAmount;

//            return betAmount;
//        }

//        public bool ReachGoal()
//        {
//            return leave >= Pocket;
//        }


//        public void Won(int amount)
//        {
//            Pocket += amount;
//            this.winLastBest = true;
//        }

//        public void Lose()
//        {
//            this.winLastBest = false;
//        }
//    }
//}
