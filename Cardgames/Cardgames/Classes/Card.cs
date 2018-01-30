using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames.Classes
{
    public class Card
    {
        private CardSuit suit;

        public CardSuit Suit
        {
            get { return suit; }
            set { suit = value; }
        }
        private CardValue faceValue;

        public CardValue FaceValue
        {
            get { return faceValue; }
            set { faceValue = value; }
        }
        public Card(CardSuit suit, CardValue faceValue)
        {
            this.Suit = suit;
            this.FaceValue = faceValue;
        }
    }
}
