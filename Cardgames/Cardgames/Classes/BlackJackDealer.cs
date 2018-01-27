using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames
{
    public class BlackJackDealer
    {
        public int DealerHand { get; set; }
        public int DealerScore { get; set; }
        public BlackJackDealer(int hand, int dScore)
        {
            DealerHand = hand;
            DealerScore = dScore;
        }
    }
}
