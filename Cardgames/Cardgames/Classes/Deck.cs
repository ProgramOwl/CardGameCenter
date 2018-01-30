using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames.Classes
{
    public class Deck
    {
        private Card[] cards;

        public Card[] Cards
        {
            get { return cards; }
            set { cards = value; }
        }
        public void FillDeck()
        {
            CardValue[] ranks = (CardValue[])Enum.GetValues(typeof(CardValue));
            CardSuit[] suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
            Card tempCard;
            for(int i = 0; i < suits.Length; i++)
            {
                for(int j = 0; j < ranks.Length; j++)
                {
                    tempCard = new Card(suits[i], ranks[j]);
                    
                }
            }
        }
    }
}
