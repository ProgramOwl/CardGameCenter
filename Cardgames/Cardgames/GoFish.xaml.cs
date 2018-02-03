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
using Cardgames.Classes;

namespace Cardgames
{   //Check that game over works and other possible glitches
    //Once Working try and futher implement card

    /// <summary>
    /// Interaction logic for GoFish.xaml
    /// </summary>
    public partial class GoFish : Window
    {
        public int NumberOfPlayers = 2;
        public Deck goFishDeck;
        public int currIndex = 0;
        public List<Player> PlayerList;

        public GoFish()
        {
            InitializeComponent();
            GameOverPanel.Visibility = Visibility.Collapsed;
            CoverPanel.Visibility = Visibility.Collapsed;
        }
        //Inialization_Setup
        public void Setup(int playerAmounts)
        {
            NumberOfPlayers = playerAmounts;
            PlayerList = new List<Player>();
            goFishDeck = new Deck();
            Console.WriteLine("Deck has: ", goFishDeck.Cards.Count);
            
            SetupPlayerVisibilityGo(NumberOfPlayers);
            SetupOpponentSelector(NumberOfPlayers);
            //TestingMethod();
            PlayerSetup(NumberOfPlayers);

            for(int i=0; i<NumberOfPlayers; i++)
            {
               FindAndRemovePairs(i);
            }
            
            PlayerListBox.ItemsSource = PlayerList;
            PlayerListBox.SelectedIndex = 0;
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                for (int t = 0; t < PlayerList[i].PlayerHand.Count; t++)
                {
                    PlayerList[i].PlayerHand[t].CardFaceUp = true;
                }
            }
            int indexT = PlayerListBox.SelectedIndex;
            PlayerListBox.ItemsSource = null;
            PlayerListBox.ItemsSource = PlayerList;
            PlayerListBox.SelectedIndex = indexT;
            CurrentPlayerLabel.Content = PlayerList[PlayerListBox.SelectedIndex].Name + "'s Turn";
            CoverPanel.Visibility = Visibility.Collapsed;
            Updatescores();
        }
        private void TestingMethod()
        {
            List<Card> cards1 = new List<Card>();
            List<Card> cards2 = new List<Card>();
            List<Card> cards3 = new List<Card>();
            List<Card> cards4 = new List<Card>();
            cards1.Add(new Card(CardSuit.Clubs, CardValue.Ace, true));
            cards1.Add(new Card(CardSuit.Clubs, CardValue.Six, true));
            cards1.Add(new Card(CardSuit.Spades, CardValue.Seven, true));

            cards2.Add(new Card(CardSuit.Hearts, CardValue.Eight, true));
            cards2.Add(new Card(CardSuit.Clubs, CardValue.Two, true));
            cards2.Add(new Card(CardSuit.Clubs, CardValue.King, true));
            cards2.Add(new Card(CardSuit.Hearts, CardValue.Ace, true));
            cards2.Add(new Card(CardSuit.Spades, CardValue.Queen, true));

            cards3.Add(new Card(CardSuit.Clubs, CardValue.Ten, true));
            cards3.Add(new Card(CardSuit.Hearts, CardValue.Ten, true));
            cards3.Add(new Card(CardSuit.Clubs, CardValue.Five, true));
            cards3.Add(new Card(CardSuit.Spades, CardValue.Four, true));
            cards3.Add(new Card(CardSuit.Clubs, CardValue.Queen, true));

            cards4.Add(new Card(CardSuit.Diamonds, CardValue.Jack, true));
            cards4.Add(new Card(CardSuit.Spades, CardValue.Ten, true));
            cards4.Add(new Card(CardSuit.Hearts, CardValue.King, true));
            cards4.Add(new Card(CardSuit.Clubs, CardValue.Three, true));
            cards4.Add(new Card(CardSuit.Diamonds, CardValue.Four, true));

            PlayerList.Add(new Player("Player 1", cards1));
            PlayerList.Add(new Player("Player 2", cards2));
            player1Points.Content = PlayerList[0].GoFishCounter;
            player2Points.Content = PlayerList[1].GoFishCounter;

            if (NumberOfPlayers == 4)
            {
                PlayerList.Add(new Player("Player 3", cards3));
                PlayerList.Add(new Player("Player 4", cards4));
                player3Points.Content = PlayerList[2].GoFishCounter;
                player4Points.Content = PlayerList[3].GoFishCounter;
            }
            else if (NumberOfPlayers == 3)
            {
                PlayerList.Add(new Player("Player 3", cards3));
                player3Points.Content = PlayerList[2].GoFishCounter;
            }

            PlayerListBox.ItemsSource = PlayerList;
        }
        //Visuals
        private void SetupPlayerVisibilityGo(int numberOfPlayers)
        {
            player1Stats.Visibility = Visibility.Visible;
            player2Stats.Visibility = Visibility.Visible;
            player3Stats.Visibility = Visibility.Collapsed;
            player4Stats.Visibility = Visibility.Collapsed;
            if (numberOfPlayers == 3)
            {
                player3Stats.Visibility = Visibility.Visible;
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
        //Logic
        public void PlayerSetup(int players)
        {
            List<Card> cards1 = new List<Card>();
            List<Card> cards2 = new List<Card>();
            List<Card> cards3 = new List<Card>();
            List<Card> cards4 = new List<Card>();
            //for (int t = 0; t < 5; t++)
            //{
            //    cards1.Add(goFishDeck.drawCard());//[t].CardFaceUp = true;
            //    cards2.Add(goFishDeck.drawCard());
            //}
            PlayerList.Add(new Player("Player 1", cards1));
            PlayerList.Add(new Player("Player 2", cards2));
            player1Points.Content = PlayerList[0].GoFishCounter;
            player2Points.Content = PlayerList[1].GoFishCounter;

            if (NumberOfPlayers == 4)
            {
                //for (int t = 0; t < 5; t++)
                //{
                //    cards3.Add(goFishDeck.drawCard());//[t].CardFaceUp = true;
                //    cards4.Add(goFishDeck.drawCard());
                //}
                PlayerList.Add(new Player("Player 3", cards3));
                PlayerList.Add(new Player("Player 4", cards4));
                player3Points.Content = PlayerList[2].GoFishCounter;
                player4Points.Content = PlayerList[3].GoFishCounter;
            }
            else if (NumberOfPlayers == 3)
            {
                //for (int t = 0; t < 5; t++)
                //{
                //    cards3.Add(goFishDeck.drawCard());
                //}
                PlayerList.Add(new Player("Player 3", cards3));
                player3Points.Content = PlayerList[2].GoFishCounter;
            }
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                goFishDeck.playerDraw(PlayerList[i], 5);
            }

            //for (int i = 0; i < PlayerList.Count; i++)
            //{
            //    goFishDeck.playerDraw(PlayerList[i], 5);
            //}
            //for (int i = 0; i < PlayerList.Count; i++)
            //{
            //    for (int t = 0; t < 5; t++)
            //    {
            //        PlayerList[i].PlayerHand[t].CardFaceUp = true;
            //    }
            //}

            //List<Card> EmptyCards = new List<Card>();
            //PlayerList.Add(new Player("Player 1", EmptyCards, EmptyCards, 0, 0, 0, true));
            //PlayerList.Add(new Player("Player 2", EmptyCards, EmptyCards, 0, 0, 0, true));
            //player1Points.Content = PlayerList[0].GoFishCounter;
            //player2Points.Content = PlayerList[1].GoFishCounter;

            //if (NumberOfPlayers == 4)
            //{
            //    PlayerList.Add(new Player("Player 3", EmptyCards, EmptyCards, 0, 0, 0, true));
            //    PlayerList.Add(new Player("Player 4", EmptyCards, EmptyCards, 0, 0, 0, true));
            //    player3Points.Content = PlayerList[2].GoFishCounter;
            //    player4Points.Content = PlayerList[3].GoFishCounter;
            //}
            //else if (NumberOfPlayers == 3)
            //{
            //    PlayerList.Add(new Player("Player 3", EmptyCards, EmptyCards, 0, 0, 0, true));
            //    player3Points.Content = PlayerList[2].GoFishCounter;
            //}
            ////for(int i=0; i<PlayerList.Count; i++)
            ////{
            ////    goFishDeck.playerDraw(PlayerList[i], 5);
            ////}
            //for (int i = 0; i < PlayerList.Count; i++)
            //{
            //    for (int t = 0; t < 5; t++)
            //    {
            //        PlayerList[i].PlayerHand.Add(goFishDeck.drawCard());//[t].CardFaceUp = true;
            //    }
            //}

        }
        /// <summary>
        /// Should set up a players hands with cards.
        /// </summary>
        /*public void initialPlayerHand()
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

        }*/

        //TurnUpdateing and changes
        private void TurnChange()
        {
            //player1.GoFishCounter++;
            PlayerListBox.SelectedIndex = (PlayerListBox.SelectedIndex + 1) % NumberOfPlayers;

            if (PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Count == 0)
            {
                if (isGameOver())
                {
                    GameHasEnded();
                }
                else
                {
                    if (goFishDeck.Cards.Count > 0)
                    {
                        //goFishDeck.playerDraw(PlayerList[PlayerListBox.SelectedIndex], 1);
                        for (int i = 0; i < 5; i++)
                        {
                            if (goFishDeck.Cards.Count > 0)
                            {
                                PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Add(goFishDeck.drawCard());
                            }
                        }
                    }
                    for (int i = 0; i < NumberOfPlayers; i++)
                    {
                        for (int t = 0; t < PlayerList[i].PlayerHand.Count; t++)
                        {
                            PlayerList[i].PlayerHand[t].CardFaceUp = true;
                        }
                    }
                    int indexT = PlayerListBox.SelectedIndex;
                    PlayerListBox.ItemsSource = null;
                    PlayerListBox.ItemsSource = PlayerList;
                    PlayerListBox.SelectedIndex = indexT;
                    TurnChange();
                    CoverPanel.Visibility = Visibility.Visible;
                }
            }
            else
            {
                CurrentPlayerLabel.Content = PlayerList[PlayerListBox.SelectedIndex].Name + "'s Turn";
                CardList_ListBox.SelectedIndex = 0;
                UpDateOpponentSelector();
            }
            CardList_ListBox.SelectedIndex = 0;
        }            
        private void UpDateOpponentSelector()
        {            
            if(NumberOfPlayers > 2)
            {
                Opponent.SelectedIndex = 0;
                OpponentOption1.Visibility = Visibility.Visible;
                OpponentOption2.Visibility = Visibility.Visible;
                OpponentOption1Label.Content = (PlayerList[(PlayerListBox.SelectedIndex + 1) % NumberOfPlayers].Playing) ? PlayerList[(PlayerListBox.SelectedIndex + 1) % NumberOfPlayers].Name : "Empty";
                OpponentOption2Label.Content = (PlayerList[(PlayerListBox.SelectedIndex + 2) % NumberOfPlayers].Playing) ? PlayerList[(PlayerListBox.SelectedIndex + 2) % NumberOfPlayers].Name : "Empty";

                if ((string)OpponentOption1Label.Content == "Empty")
                {
                    OpponentOption1.Visibility = Visibility.Collapsed;
                }
                if ((string)OpponentOption2Label.Content == "Empty")
                {
                    OpponentOption2.Visibility = Visibility.Collapsed;
                }
            }
            if (NumberOfPlayers > 3)
            {
                OpponentOption3.Visibility = Visibility.Visible;
                OpponentOption3Label.Content = (PlayerList[(PlayerListBox.SelectedIndex + 3) % NumberOfPlayers].Playing) ? PlayerList[(PlayerListBox.SelectedIndex + 3) % NumberOfPlayers].Name : "Empty";

                if ((string)OpponentOption3Label.Content == "Empty")
                {
                    OpponentOption3.Visibility = Visibility.Collapsed;
                }
            }
        }
       
        //Game Logic
        public void SingleTurn()
        {
            //returns 1 for player 1 and so on
            int selectedOpponent = (((Opponent.SelectedIndex + 1) + PlayerListBox.SelectedIndex) % NumberOfPlayers);
            Console.WriteLine("Opponent selected = " + selectedOpponent);
            Card pickedCard = PlayerList[PlayerListBox.SelectedIndex].PlayerHand[CardList_ListBox.SelectedIndex];
            //Check if selected opponent has a match
            bool matched = CardCheck(pickedCard, selectedOpponent);
            //If match then correctly remove card from opponent and from player, player gains a point and Go Fish is false
            //check if Go Fish
            if (!matched)
            {
                //draw new card and add to hand, also check if it is a match
                //goFishDeck.playerDraw((Player)PlayerList[PlayerListBox.SelectedIndex], 1);
                if (goFishDeck.Cards.Count > 0)
                {
                    Card drawnCard = goFishDeck.drawCard();//PlayerList[PlayerListBox.SelectedIndex].PlayerHand[PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Count];
                    matched = (pickedCard.FaceValue == drawnCard.FaceValue);
                    if (matched)
                    {
                        PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Remove(pickedCard);
                        if (isGameOver())
                        {
                            GameHasEnded();
                        }                        
                    }
                    else
                    {
                        PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Add(drawnCard);
                    }
                }
                else
                {
                   if(PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Count == 0)
                   {
                        PlayerList[PlayerListBox.SelectedIndex].Playing = false;
                   }
                }               
            }

            if (!matched)
            {
                CoverPanel.Visibility = Visibility.Visible;
                TurnChange();
            }
            else
            {
                PlayerList[PlayerListBox.SelectedIndex].GoFishCounter += 1;
                PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Remove(pickedCard);
                //They get to go again
                CardList_ListBox.SelectedIndex = 0;
                //FindAndRemovePairs();
            }
            Updatescores();

        }
        public bool MatchingCards(Card x, Card y)
        {
            if (x.FaceValue == y.FaceValue)
            {
                return true;
            }
            return false;
        }
        private bool CardCheck(Card selectedCard, int opponent)
        {
            bool hasAMatch = false;
            Card opponentsC = null;
            for(int i=0; i < PlayerList[opponent].PlayerHand.Count; i++)
            {
                if(selectedCard.FaceValue == ((Card)PlayerList[opponent].PlayerHand[i]).FaceValue)//MatchingCards(selectedCard, (Card)PlayerList[opponent].PlayerHand[i]))
                {
                    hasAMatch = true;
                    opponentsC = PlayerList[opponent].PlayerHand[i];
                    PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Remove(selectedCard);
                    i = PlayerList[opponent].PlayerHand.Count + 10;
                }
            }
            if (hasAMatch)
            {
                PlayerList[opponent].PlayerHand.Remove(opponentsC);
                //PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Remove(selectedCard);
            }
            return hasAMatch;
        }

        private void FindAndRemovePairs(int playerI)
        {
            bool hasAMatch = false;
            do
            {
                hasAMatch = false;
                for (int i = 0; i < PlayerList[playerI].PlayerHand.Count - 1; i++)
                {
                    for (int j = i+1; j < PlayerList[playerI].PlayerHand.Count; j++)
                    {
                        if (MatchingCards(PlayerList[playerI].PlayerHand[i], PlayerList[playerI].PlayerHand[j]))
                        {
                            Card one = PlayerList[playerI].PlayerHand[i];
                            Card two = PlayerList[playerI].PlayerHand[j];
                            //remove the two cards
                            PlayerList[playerI].PlayerHand.Remove(one);
                            PlayerList[playerI].PlayerHand.Remove(two);
                            //add point
                            PlayerList[playerI].GoFishCounter = PlayerList[playerI].GoFishCounter + 1;
                            //fix loop constant
                            i = PlayerList[playerI].PlayerHand.Count+10;
                            j = i;
                            hasAMatch = true;
                        }
                    }
                }
            } while (hasAMatch);
            //Do some system to remove them with out affecting the original array and making sure not to accidentally get triples
        }
        private bool isGameOver()
        {
            bool gameOver = false;
            int playersPlaying = 0;
            //check if deck is empty
            if (goFishDeck.Cards.Count == 0)
            {
                //then check if any players are playing
                for (int i=0; i < NumberOfPlayers; i++)
                {
                    if (PlayerList[i].PlayerHand.Count == 0)
                    {
                        PlayerList[i].Playing = false;
                    }
                    else
                    {
                        playersPlaying++;
                    }

                    //if (PlayerList[i].Playing)
                    //{
                    //    playersPlaying++;
                    //}
                }
                if(playersPlaying == 0)
                {
                    gameOver = true;
                }
            }
            //then check if all players have no cards
            return gameOver;
        }
        
        private void GameHasEnded()
        {
            List<Player> winners = new List<Player>();
            winners.Add((Player)PlayerList[0]);
            bool isATie = false;
            for (int i = 1; i < NumberOfPlayers; i++)
            {
                if (winners[0].GoFishCounter < PlayerList[i].GoFishCounter)
                {
                    winners = new List<Player>();
                    winners.Add(PlayerList[i]);
                    isATie = false;
                }
                else if (winners[0].GoFishCounter == PlayerList[i].GoFishCounter)
                {
                    winners.Add(PlayerList[i]);
                    isATie = true;
                }
            }
            WinnerLabel.Content = CompileEndMessage(winners, isATie);
            GameOverPanel.Visibility = Visibility.Visible;
        }
        private string CompileEndMessage(List<Player> winners, bool isATie)
        {
            string message = "";
            if (isATie)
            {
                message = "Tie of " + winners[0].GoFishCounter + " points, the winners are: " + winners[0].Name;
                for (int i=1; i < winners.Count; i++) 
                {
                    message = message + ", " + winners[i].Name;
                }
            }
            else
            {
                message = "The winner is " + winners[0].Name + " with " + winners[0].GoFishCounter + " points.";
            }
            return message;
        }

        //Button Prompts
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Updatescores()
        {
            FindAndRemovePairs(PlayerListBox.SelectedIndex);

            player1Points.Content = PlayerList[0].GoFishCounter;
            player2Points.Content = PlayerList[1].GoFishCounter;
            if(NumberOfPlayers > 2)
            {
                player3Points.Content = PlayerList[2].GoFishCounter;
            }
            if (NumberOfPlayers > 3)
            {
                player4Points.Content = PlayerList[3].GoFishCounter;
            }

            for (int i = 0; i < NumberOfPlayers; i++)
            {
                for (int t = 0; t < PlayerList[i].PlayerHand.Count; t++)
                {
                    PlayerList[i].PlayerHand[t].CardFaceUp = true;
                }
            }
            int indexT = PlayerListBox.SelectedIndex;
            PlayerListBox.ItemsSource = null;
            PlayerListBox.ItemsSource = PlayerList;
            PlayerListBox.SelectedIndex = indexT;

            //PlayerListBox.ItemsSource = PlayerList;
        }
        private void GoFishTurnButton_Click(object sender, RoutedEventArgs e)
        {
            //Updatescores();
            if (PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Count == 0)
            {
                if (goFishDeck.Cards.Count > 0 && PlayerList[PlayerListBox.SelectedIndex].Playing)
                {
                    //goFishDeck.playerDraw(PlayerList[PlayerListBox.SelectedIndex], 1);
                    for (int i = 0; i < 5; i++)
                    {
                        if (goFishDeck.Cards.Count > 0)
                        {
                            PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Add(goFishDeck.drawCard());
                        }
                    }
                }
                else
                {
                    PlayerList[PlayerListBox.SelectedIndex].Playing = false;
                }
                TurnChange();
                CoverPanel.Visibility = Visibility.Visible;
            }
            else
            {
                SingleTurn();
            }
        }

        private void NextPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            //set player to next
            //TurnChange();
            CoverPanel.Visibility = Visibility.Collapsed;
        }

        private void ReturnToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }
    }
}
