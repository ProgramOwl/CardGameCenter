﻿using System;
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
            for(int i = 0; i <= suits.Length - 1; i++)
            {
                for (int j = 0; j <= ranks.Length - 1; j++)
                {
                    tempCard = new Card(suits[i], ranks[j], false);
                    cards.Add(tempCard);
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
        public Deck firstDeal(Deck deck, string gameMode, List<Player> listPlayers, BlackJackDealer dealer)
        {
            Card tempCard;
            var playerNumber = 0;
            switch (gameMode)
            {
                case "blackjack": 
                    for(int i = 0; i < listPlayers.Count * 2 - 1; i++)
                    {
                        tempCard = deck.Cards[0];
                        deck.Cards.RemoveAt(0);
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
                    }
                    dealerDraw(deck, dealer, 2);
                    break;
                case "gofish":
                    for (int i = 0; i < listPlayers.Count * 5 - 1; i++)
                    {
                        tempCard = deck.Cards[0];
                        deck.Cards.RemoveAt(0);
                        addToPlayerHand(listPlayers[playerNumber], tempCard);
                        playerNumber++;
                    }
                    
                 break;
            }
            return deck;
        }
        public void dealerDraw(Deck deck, BlackJackDealer dealer, int NumOfCards)
        {
            Card tempCard;
            for (int i = 0; i < NumOfCards; i++)
            {
                tempCard = deck.Cards[0];
                deck.Cards.RemoveAt(0);
                if (NumOfCards == 2)
                {
                    if(i == 0)
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
        public Deck()
        {
            FillDeck();
            Cards = ShuffleDeck();
        }
    }
}
