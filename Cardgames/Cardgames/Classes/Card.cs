using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames.Classes
{
    public class Card
    {
        private CardSuits suit;

        public CardSuits Suit
        {
            get { return suit; }
            set { suit = value; }
        }

    }
}
