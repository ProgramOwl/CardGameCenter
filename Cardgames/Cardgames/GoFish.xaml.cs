using Cardgames.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cardgames
{
    /// <summary>
    /// Interaction logic for GoFish.xaml
    /// </summary>
    public partial class GoFish : Window
    {
        private int NumberOfPlayers = 2;
        public Player player1;
        public Player player2;
        public Player player3;
        public Player player4;
        public Deck goFishDeck;
        public int numOfPlayers;
        public int currIndex = 0;
        //public Card[] cardArr;
        //public List<Card> cards;
        public GoFish()
        {
            InitializeComponent();
            DeckSetup();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GoFishTurnButton_Click(object sender, RoutedEventArgs e)
        {
            //returns 1 for player 1 and so on
            int selectedOpponent = (((Opponent.SelectedIndex + 1) + PlayerListBox.SelectedIndex) % NumberOfPlayers) + 1;
            CoverPanel.Visibility = Visibility.Visible;
        }

        private void NextPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            //set player to next
            //PlayerListBox.SelectedIndex = counter % turns;
            CoverPanel.Visibility = Visibility.Collapsed;
        }
        private void TurnChange()
        {
            PlayerListBox.SelectedIndex = (PlayerListBox.SelectedIndex + 1) % NumberOfPlayers;
            CurrentPlayerLabel.Content = "Player " + (PlayerListBox.SelectedIndex + 1) + "'s Trun";
            UpDateOpponentSelector();
        }
        private void UpDateOpponentSelector()
        {
            int PlayerNumber = PlayerListBox.SelectedIndex + 1;
            OpponentOption1Label.Content = "Player " + ((PlayerNumber % NumberOfPlayers) + 1);
            OpponentOption2Label.Content = "Player " + ((PlayerNumber % NumberOfPlayers) + 2);
            OpponentOption3Label.Content = "Player " + ((PlayerNumber % NumberOfPlayers) + 3);
        }
        public void Setup(int playerNum)
        {
            NumberOfPlayers = playerNum;
            //testing purpose
            ImageCard[] cardsI = new ImageCard[6];
            cardsI[0] = new ImageCard("club", 5, true);
            cardsI[1] = new ImageCard("heart", 12, true);
            cardsI[2] = new ImageCard("club", 10, true);
            cardsI[3] = new ImageCard("spade", 13, true);
            cardsI[4] = new ImageCard("heart", 7, true);
            cardsI[5] = new ImageCard("spade", 4, false);

            Playerv2[] Players = new Playerv2[NumberOfPlayers];
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Players[i] = new Playerv2("Player " + i, cardsI);
            }
            PlayerListBox.ItemsSource = Players;

            PlayerListBox.SelectedIndex = 0;
            CurrentPlayerLabel.Content = "Player " + (PlayerListBox.SelectedIndex + 1) + "'s Trun";
            SetupPlayerVisibilityGo(NumberOfPlayers);
            SetupOpponentSelector(NumberOfPlayers);
            CoverPanel.Visibility = Visibility.Collapsed;
        }
        private void SetupPlayerVisibilityGo(int numberOfPlayers)
        {
            player1Stats.Visibility = Visibility.Visible;
            player2Stats.Visibility = Visibility.Visible;
            player3Stats.Visibility = Visibility.Collapsed;
            player4Stats.Visibility = Visibility.Collapsed;
            if (numberOfPlayers == 3)
            {
                player3Stats.Visibility = Visibility.Visible;
                player4Stats.Visibility = Visibility.Collapsed;
            }
            else if (numberOfPlayers == 4)
            {
                player3Stats.Visibility = Visibility.Visible;
                player4Stats.Visibility = Visibility.Visible;
            }
        }
        private void SetupOpponentSelector(int numberOfPlayers)
        {
            if (numberOfPlayers == 2)
            {
                OpponentSelector.Visibility = Visibility.Collapsed;
            }
            else if (numberOfPlayers == 3)
            {
                OpponentSelector.Visibility = Visibility.Visible;
                OpponentOption1.Visibility = Visibility.Visible;
                OpponentOption2.Visibility = Visibility.Visible;
                OpponentOption3.Visibility = Visibility.Collapsed;
            }
            else if (numberOfPlayers == 4)
            {
                OpponentSelector.Visibility = Visibility.Visible;
                OpponentOption1.Visibility = Visibility.Visible;
                OpponentOption2.Visibility = Visibility.Visible;
                OpponentOption3.Visibility = Visibility.Visible;
            }
        }

        public void MatchingCards(Player p, Card x, Card y)
        {
            if (x.FaceValue == y.FaceValue)
            {
                p.GoFishCounter++;
            }
        }
        public void DeckSetup()
        {
            goFishDeck.FillDeck();
            //cardArr = goFishDeck.Cards;
            //cards = new List<Card>(cardArr);
        }

        public void PlayerSetup(int players)
        {

            if (players == 4)
            {
                Player4Game();
            }
            else if (players == 3)
            {
                Player3Game();
            }
            else if (players == 2)
            {
                Player2Game();
            }
            else
            {
                Player2Game();
            }

        }

        private void Player2Game()
        {
            player1 = new Player("Player 1", new Card[5], 0, 0, 0);
            player2 = new Player("Player 2", new Card[5], 0, 0, 0);
            //TurnRotation(2);               
        }
        private void Player3Game()
        {
            player1 = new Player("Player 1", new Card[5], 0, 0, 0);
            player2 = new Player("Player 2", new Card[5], 0, 0, 0);
            player3 = new Player("Player 3", new Card[5], 0, 0, 0);
        }
            private void Player4Game()
            {
                player1 = new Player("Player 1", new Card[5], 0, 0, 0);
                player2 = new Player("Player 2", new Card[5], 0, 0, 0);
                player3 = new Player("Player 3", new Card[5], 0, 0, 0);
                player4 = new Player("Player 4", new Card[5], 0, 0, 0);

                //TurnRotation(4);               
            }

            /// <summary>
            ///Called if player/cpu does not get a match on their turn
            /// </summary>
            public void DrawACard()
            {
                // call nextCard()
                nextCard(player1);
                //Add the taken card and add it to the players hand based on current player's turn


                //call TurnSwitch()

            }
            /// <summary>
            /// Called by DrawACard(), removes next card object from the deck
            /// </summary>
            public void nextCard(Player player)
            {
                //check if the deck is empty
                //if empty call endGame()???
                //else remove next card in the deck
                if (goFishDeck.Cards.Length > 0)
                {
                    getNextCards(player, 1);
                    //player.CardHand.Add(cards.First());
                }
                else
                {
                    //endGame();
                }

            }
            /// <summary>
            /// Should set up a players hands with cards.
            /// </summary>
            public void initialPlayerHand()
            {
                switch (numOfPlayers)
                {
                    case 2:
                        getNextCards(player1, 5);

                        getNextCards(player2, 5);

                        break;

                    case 3:
                        getNextCards(player1, 5);
                        getNextCards(player2, 5);
                        getNextCards(player3, 5);

                        break;
                    case 4:
                        getNextCards(player1, 5);
                        getNextCards(player2, 5);
                        getNextCards(player3, 5);
                        getNextCards(player4, 5);

                        break;
                }

                //populate player hand with the correct amount of cards

            }

            public void getNextCards(Player player, int numOfCards)
            {
                for (int i = 0; i < numOfCards; i++)
                {
                    if (goFishDeck.Cards[i] != null)
                    {
                        //player.CardHand[i] = goFishDeck.Cards[currIndex];
                        currIndex++;
                    }
                }

                //removeCards(5);
            }




            //public void removeCards(int num)
            //{
            //    if (cards != null)
            //    {
            //        cards.RemoveRange(0, num);
            //    }
            //}

        }
    }

//for (int i = 0; i < 5; i++)
//{
//    //player1.PlayerHand[i] = goFishDeck.Cards[i];
//    player1.PlayerHand[i] = cards[i];
//}
//goFishDeck.Cards.Skip(5);
