using Cardgames.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames
{
    public class BlackJackDealer
    {
        public string Name { get; set; }
        public Card[] DealerHand { get; set; }
        public int DealerScore { get; set; }
        public BlackJackDealer(Card[] hand, int dScore)
        {
            Name = "Dealer";
            DealerHand = hand;
            DealerScore = dScore;
        }
    }
}
