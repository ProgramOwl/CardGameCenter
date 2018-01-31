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
            cards = new Card[52];
            CardValue[] ranks = (CardValue[])Enum.GetValues(typeof(CardValue));
            CardSuit[] suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
            Card tempCard;
            int cardNumber = 0;
            for(int i = 0; i < suits.Length; i++)
            {
                for(int j = 0; j < ranks.Length; j++)
                {
                    tempCard = new Card(suits[i], ranks[j], false);
                    cards[cardNumber] = tempCard;
                    cardNumber++;
                }
            }
        }
        public Card[] ShuffleDeck()
        {

            Random r = new Random();
            for(int i = 0; i < Cards.Length - 1; i++)
            {
                int j = r.Next(i, Cards.Length);
                Card tempCard = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = tempCard;
            }

            return Cards;
        }
        //public Card[] Deal(Deck deck, string gameMode, bool isFirstDeal, int numOfPlayers)
        //{

        //}
        public Deck()
        {
            FillDeck();
            Cards = ShuffleDeck();
        }
    }
}
