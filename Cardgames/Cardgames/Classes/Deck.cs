using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames.Classes
{
    public class Deck
    {
       private Random rand = new Random();
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
            for(int i = 0; i < suits.Length-1; i++)
            {
                for(int j = 0; j < ranks.Length-1; j++)
                {
                    tempCard = new Card(suits[i], ranks[j], false);
                    cards.Add(tempCard);
                    cardNumber++;
                }
            }
        }
        public void TestingDeck()
        {
            cards = new List<Card>();
            CardValue[] ranks = (CardValue[])Enum.GetValues(typeof(CardValue));
            CardSuit[] suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
            Card tempCard;
            int cardNumber = 0;
            for (int i = 0; i < suits.Length - 1; i++)
            {
                for (int j = 0; j < 6 - 1; j++)
                {
                    tempCard = new Card(suits[i], ranks[j], false);
                    cards.Add(tempCard);
                    cardNumber++;
                }
            }
        }
        public List<Card> ShuffleDeck()
        {
            for(int i = 0; i < Cards.Count - 1; i++)
            {
                int j = rand.Next(i, Cards.Count);
                Card tempCard = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = tempCard;
            }
            return Cards;
        }

        public void firstDeal(string gameMode, List<Player> listPlayers, BlackJackDealer dealer)
        {
            Card tempCard;
            var playerNumber = 0;
            switch (gameMode)
            {
                case "blackjack":
                    for (int i = 0; i < listPlayers.Count * 2 - 1; i++)
                    {
                        tempCard = this.Cards[0];
                        this.Cards.RemoveAt(0);
                        if (i <= listPlayers.Count - 1)
                        {
                            addToPlayerHand(listPlayers[playerNumber], tempCard);
                        }
                        else
                        {
                            tempCard.CardFaceUp = true;
                            addToPlayerHand(listPlayers[playerNumber], tempCard);
                        }
                        playerNumber++;
                        if (playerNumber == listPlayers.Count)
                        {
                            playerNumber = 0;
                        }
                    }
                    dealerDraw(dealer, 2);
                    break;
                case "gofish":
                    for (int i = 0; i < listPlayers.Count * 5 - 1; i++)
                    {
                        tempCard = this.Cards[0];
                        this.Cards.RemoveAt(0);
                        addToPlayerHand(listPlayers[playerNumber], tempCard);
                        playerNumber++;
                        if (playerNumber == listPlayers.Count)
                        {
                            playerNumber = 0;
                        }
                    }

                    break;
            }
        }
        public void playerDraw(Player player, int NumOfCards)
        {
            Card tempCard;
            for (int i = 0; i < NumOfCards; i++)
            {
                tempCard = this.Cards[0];
                this.Cards.RemoveAt(0);
                player.PlayerHand.Add(tempCard);
            }
        }
        public void dealerDraw(BlackJackDealer dealer, int NumOfCards)
        {
            Card tempCard;
            for (int i = 0; i < NumOfCards; i++)
            {
                tempCard = this.Cards[0];
                this.Cards.RemoveAt(0);
                if (NumOfCards == 2)
                {
                    if (i == 0)
                    {
                        addToDealerHand(tempCard, dealer);
                    }
                    else
                    {
                        tempCard.CardFaceUp = true;
                        addToDealerHand(tempCard, dealer);
                    }
                }
                else
                {
                    addToDealerHand(tempCard, dealer);
                }
            }
        }

        //add draw method for individual player, dealer deal
        public void addToDealerHand(Card card, BlackJackDealer dealer)
        {
            dealer.DealerHand.Add(card);
        }
        public void addToPlayerHand(Player player, Card card)
        {
            player.PlayerHand.Add(card);
        }

        //Main
        public Deck()
        {
            //TestingDeck();
            FillDeck();
            Cards = ShuffleDeck();
        }

        //draw, Sam
        public Card drawCard()
        {
            Card temp = this.Cards[rand.Next(0, this.Cards.Count)];
            this.Cards.Remove(temp);
            temp.CardFaceUp = true;
            return temp;
        }
    }
}
