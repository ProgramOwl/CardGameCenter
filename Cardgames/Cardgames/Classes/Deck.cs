using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames.Classes
{
    public class Deck
    {
        private List<Card> cards;

        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }
        public void FillDeck()
        {
            cards = new List<Card>();
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
        public List<Card> ShuffleDeck()
        {

            Random r = new Random();
            for(int i = 0; i < Cards.Count - 1; i++)
            {
                int j = r.Next(i, Cards.Count);
                Card tempCard = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = tempCard;
            }

            return Cards;
        }
        public Deck Deal(Deck deck, string gameMode, bool isFirstDeal, List<Player> listPlayers)
        {
            Card tempCard;
            var playerNumber = 0;
            switch (gameMode)
            {
                case "blackjack":
                    if (isFirstDeal)
                    { 
                            for(int i = 0; i < listPlayers.Count * 2 - 1; i++)
                            {
                                tempCard = deck.Cards[0];
                                deck.Cards.RemoveAt(0);
                                if(i <= listPlayers.Count - 1)
                                {
                                    addToPlayerHand(listPlayers[playerNumber], tempCard);
                                }
                                else
                                {
                                    tempCard.CardFaceUp = true;
                                    addToPlayerHand(listPlayers[playerNumber], tempCard);
                                }
                            playerNumber++;
                            }
                    }
                    break;
                case "gofish":
                    if (isFirstDeal)
                    {
                        for (int i = 0; i < listPlayers.Count * 5 - 1; i++)
                        {
                            tempCard = deck.Cards[0];
                            deck.Cards.RemoveAt(0);
                            addToPlayerHand(listPlayers[playerNumber], tempCard);  
                        }
                        playerNumber++;
                    }
                    break;
            }
            return deck;
        }
        public Deck dealerDeal(BlackJackDealer dealer)
        {
            return null;
        }
        public void addToPlayerHand(Player player, Card card)
        {
            player.PlayerHand.Add(card);
        }
        public Deck()
        {
            FillDeck();
            Cards = ShuffleDeck();
        }
    }
}
