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
        public List<Card> DealerHand { get; set; }
        public List<Card> DealerHand2 { get; set; }
        public BlackJackDealer(List<Card> hand, List<Card> hand2)
        {
            Name = "Dealer";
            DealerHand = hand;
            DealerHand2 = hand2;
        }
    }
}
