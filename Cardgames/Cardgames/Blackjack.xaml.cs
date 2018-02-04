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
{//Issues: Getting card visibility to work with one player, and getting dealer to show their hand
    //Game over doesn't exist yet(use a how many players are playing system and update Playing)

    /// <summary>
    /// Interaction logic for Blackjack.xaml
    /// </summary>
    public partial class Blackjack : Window
    {
        public BlackJackDealer dealer;
        public List<Player> PlayerList;
        public Deck blackJackDeck;
        public int countB=0;
        public int countT=0;
        //public int counter = 1;
        public int NumberOfPlayers = 1;

        //Testing values
        public bool hasSplit = false;
        public bool onHand2 = false;

        public Blackjack()
        {
            InitializeComponent();
            HandPointsPanel.Visibility = Visibility.Collapsed;
        }
        //Inialization_Setup
        public void Setup(int players)
        {
            blackJackDeck = new Deck();
            PlayerList = new List<Player>();
            NumberOfPlayers = players;
            //TestingMethod();
            SetupPlayerVisibilityBlack(NumberOfPlayers);
            NewDealer();
            StartGame(NumberOfPlayers);
            //After handing players cards
            //UpdateBanks();
            SetCardFaceStates();
        }
        public void StartGame(int players)
        {
            List<Card> Cards1 = new List<Card>();
            PlayerList.Add(new Player("Player 1", Cards1));
            player1Bank.Content = PlayerList[0].PlayerBank;

            if (NumberOfPlayers == 5)
            {
                List<Card> Cards2 = new List<Card>();
                List<Card> Cards3 = new List<Card>();
                List<Card> Cards4 = new List<Card>();
                List<Card> Cards5 = new List<Card>();
                PlayerList.Add(new Player("Player 2", Cards2));
                PlayerList.Add(new Player("Player 3", Cards3));
                PlayerList.Add(new Player("Player 4", Cards4));
                PlayerList.Add(new Player("Player 5", Cards5));
                player3Bank.Content = PlayerList[1].PlayerBank;
                player3Bank.Content = PlayerList[2].PlayerBank;
                player4Bank.Content = PlayerList[3].PlayerBank;
                player5Bank.Content = PlayerList[4].PlayerBank;
            }
            else if (NumberOfPlayers == 4)
            {
                List<Card> Cards2 = new List<Card>();
                List<Card> Cards3 = new List<Card>();
                List<Card> Cards4 = new List<Card>();
                PlayerList.Add(new Player("Player 2", Cards2));
                PlayerList.Add(new Player("Player 3", Cards3));
                PlayerList.Add(new Player("Player 4", Cards4));
                player3Bank.Content = PlayerList[1].PlayerBank;
                player3Bank.Content = PlayerList[2].PlayerBank;
                player4Bank.Content = PlayerList[3].PlayerBank;
            }
            else if (NumberOfPlayers == 3)
            {
                List<Card> Cards2 = new List<Card>();
                List<Card> Cards3 = new List<Card>();
                PlayerList.Add(new Player("Player 2", Cards2));
                PlayerList.Add(new Player("Player 3", Cards3));
                player2Bank.Content = PlayerList[1].PlayerBank;
                player3Bank.Content = PlayerList[2].PlayerBank;
            }
            else if (NumberOfPlayers == 2)
            {
                List<Card> Cards2 = new List<Card>();
                PlayerList.Add(new Player("Player 2", Cards2));
                player2Bank.Content = PlayerList[1].PlayerBank;
            }

            for (int i = 0; i < NumberOfPlayers; i++)
            {
                blackJackDeck.playerDraw(PlayerList[i], 2);
            }
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                PlayerList[i].PlayerHand[0].CardFaceUp = false;
                PlayerList[i].PlayerHand[1].CardFaceUp = true;
                PlayerList[i].Playing = true;
            }

            PlayerListBox.ItemsSource = PlayerList;
            PlayerListBox.SelectedIndex = 0;
            CurrentPlayerLabel.Content = PlayerList[PlayerListBox.SelectedIndex].Name + "'s Trun";
        }
        private void NewDealer()
        {
            List<Card> cardsDealer = new List<Card>(); 
            List<Card> cardsDealer2 = new List<Card>(); 
             dealer = new BlackJackDealer(cardsDealer, cardsDealer2);
            blackJackDeck.dealerDraw(dealer, 2);
            HouseCardList_ListBox.ItemsSource = null;
            HouseCardList_ListBox.ItemsSource = dealer.DealerHand;
        }
        private void SetupPlayerVisibilityBlack(int numberOfPlayers)
        {

            player1Stats.Visibility = Visibility.Visible;
            player2Stats.Visibility = Visibility.Collapsed;
            player3Stats.Visibility = Visibility.Collapsed;
            player4Stats.Visibility = Visibility.Collapsed;
            player5Stats.Visibility = Visibility.Collapsed;
            if (numberOfPlayers == 2)
            {
                player2Stats.Visibility = Visibility.Visible;
                player3Stats.Visibility = Visibility.Collapsed;
                player4Stats.Visibility = Visibility.Collapsed;
                player5Stats.Visibility = Visibility.Collapsed;
            }
            else if (numberOfPlayers == 3)
            {
                player2Stats.Visibility = Visibility.Visible;
                player3Stats.Visibility = Visibility.Visible;
                player4Stats.Visibility = Visibility.Collapsed;
                player5Stats.Visibility = Visibility.Collapsed;
            }
            else if (numberOfPlayers == 4)
            {
                player2Stats.Visibility = Visibility.Visible;
                player3Stats.Visibility = Visibility.Visible;
                player4Stats.Visibility = Visibility.Visible;
                player5Stats.Visibility = Visibility.Collapsed;
            }
            else if (numberOfPlayers == 5)
            {
                player2Stats.Visibility = Visibility.Visible;
                player3Stats.Visibility = Visibility.Visible;
                player4Stats.Visibility = Visibility.Visible;
                player5Stats.Visibility = Visibility.Visible;
            }
        }
        private void TestingMethod()
        {
            PlayerList = new List<Player>();
            List<Card> cards1 = new List<Card>();
            List<Card> cards2 = new List<Card>();
            List<Card> cards3 = new List<Card>();
            List<Card> cards4 = new List<Card>();
            List<Card> cards5 = new List<Card>();
            List<Card> cardsDealer = new List<Card>();
            List<Card> cardsDealer2 = new List<Card>();
            cards1.Add(new Card(CardSuit.Clubs, CardValue.Ace, true));
            cards1.Add(new Card(CardSuit.Spades, CardValue.Six, true));
            cards2.Add(new Card(CardSuit.Clubs, CardValue.Two, true));
            cards2.Add(new Card(CardSuit.Spades, CardValue.Queen, true));
            cards3.Add(new Card(CardSuit.Clubs, CardValue.Jack, true));
            cards3.Add(new Card(CardSuit.Hearts, CardValue.Ten, true));
            cards4.Add(new Card(CardSuit.Spades, CardValue.Ten, true));
            cards4.Add(new Card(CardSuit.Hearts, CardValue.King, true));
            cards5.Add(new Card(CardSuit.Diamonds, CardValue.Three, true));
            cards5.Add(new Card(CardSuit.Clubs, CardValue.Four, true));
            cardsDealer.Add(new Card(CardSuit.Hearts, CardValue.Three, true));
            cardsDealer.Add(new Card(CardSuit.Diamonds, CardValue.Four, true));

            dealer = new BlackJackDealer(cardsDealer, cardsDealer2);
            HouseCardList_ListBox.ItemsSource = dealer.DealerHand;

            PlayerList.Add(new Player("Player 1", cards1));
            player1Bank.Content = PlayerList[0].PlayerBank;

            if (NumberOfPlayers == 5)
            {
                PlayerList.Add(new Player("Player 2", cards2));
                PlayerList.Add(new Player("Player 3", cards3));
                PlayerList.Add(new Player("Player 4", cards4));
                PlayerList.Add(new Player("Player 5", cards5));
                player3Bank.Content = PlayerList[1].PlayerBank;
                player3Bank.Content = PlayerList[2].PlayerBank;
                player4Bank.Content = PlayerList[3].PlayerBank;
                player5Bank.Content = PlayerList[4].PlayerBank;
            }
            else if (NumberOfPlayers == 4)
            {
                PlayerList.Add(new Player("Player 2", cards2));
                PlayerList.Add(new Player("Player 3", cards3));
                PlayerList.Add(new Player("Player 4", cards4));
                player3Bank.Content = PlayerList[1].PlayerBank;
                player3Bank.Content = PlayerList[2].PlayerBank;
                player4Bank.Content = PlayerList[3].PlayerBank;
            }
            else if (NumberOfPlayers == 3)
            {
                PlayerList.Add(new Player("Player 2", cards2));
                PlayerList.Add(new Player("Player 3", cards3));
                player2Bank.Content = PlayerList[1].PlayerBank;
                player3Bank.Content = PlayerList[2].PlayerBank;
            }
            else if (NumberOfPlayers == 2)
            {
                PlayerList.Add(new Player("Player 2", cards2));
                player2Bank.Content = PlayerList[1].PlayerBank;
            }
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                blackJackDeck.playerDraw(PlayerList[i], 2);
            }
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                PlayerList[i].PlayerHand[0].CardFaceUp = false;
                PlayerList[i].PlayerHand[1].CardFaceUp = true;
            }
            PlayerListBox.ItemsSource = PlayerList;
            PlayerListBox.SelectedIndex = 0;
            CurrentPlayerLabel.Content = PlayerList[PlayerListBox.SelectedIndex].Name + "'s Trun";
        }
        private void SetCardFaceStates()
        {
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                PlayerList[i].PlayerHand[0].CardFaceUp = false;
                PlayerList[i].PlayerHand[1].CardFaceUp = true;
            }
            dealer.DealerHand[0].CardFaceUp = false;
            dealer.DealerHand[1].CardFaceUp = true;
        }

        //Turn Updateing and changes

        private void UpdateBanks()
        {
            player1Bank.Content = PlayerList[0].PlayerBank;
            if (NumberOfPlayers > 1)
            {
                player2Bank.Content = PlayerList[1].PlayerBank;
            }
            if (NumberOfPlayers > 2)
            {
                player3Bank.Content = PlayerList[2].PlayerBank;
            }
            if (NumberOfPlayers > 3)
            {
                player4Bank.Content = PlayerList[3].PlayerBank;
            }
            if (NumberOfPlayers > 4)
            {
                player5Bank.Content = PlayerList[4].PlayerBank;
            }
        }
        private void UpdateCards()
        {
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
        private void UpDatePlayersPlaying()
        { 
            for(int i=0; i<NumberOfPlayers; i++)
            {
                if (PlayerList[i].PlayerBank <= -50)
                {
                    PlayerList[i].Playing = false;
                    countB++;
                    countT++;
                }

                if (!PlayerList[i].Playing && PlayerList[i].Name == "Player 1")
                {
                    player1Stats.Visibility = Visibility.Collapsed;
                }
                else if (!PlayerList[i].Playing && PlayerList[i].Name == "Player 2")
                {
                    player2Stats.Visibility = Visibility.Collapsed;
                }
                else if (!PlayerList[i].Playing && PlayerList[i].Name == "Player 3")
                {
                    player3Stats.Visibility = Visibility.Collapsed;
                }
                else if (!PlayerList[i].Playing && PlayerList[i].Name == "Player 4")
                {
                    player4Stats.Visibility = Visibility.Collapsed;
                }
                else if (!PlayerList[i].Playing && PlayerList[i].Name == "Player 5")
                {
                    player5Stats.Visibility = Visibility.Collapsed;
                }
            }
        }
        
        private void NextMove()
        {
            SplitBox.Visibility = Visibility.Collapsed;
            if (PlayerListBox.SelectedIndex == NumberOfPlayers-1)
            {
                NextPlayerButton.Content = "Continue";
            }
            else
            {
                NextPlayerButton.Content = "Next Player";
            }

            if (hasSplit && !onHand2)
            {
                int score = HandScore(PlayerList[PlayerListBox.SelectedIndex].PlayerHand);
                if (CheckForBlackjack(score, PlayerList[PlayerListBox.SelectedIndex].PlayerHand))
                {
                    //end turn due to meeting a known end hand
                    NextMove();
                }
                else
                {
                    HandScore(PlayerList[PlayerListBox.SelectedIndex].PlayerHand2);
                    TurnSelection.Visibility = Visibility.Visible;
                    HitButton.Content = "Hit on Split";
                    onHand2 = true;
                    UpdateCards();
                    //Hand2Turn();
                }
            }
            //Move on to next player
            //if(all players have played then){
            //TurnSelection.Visibility = Visibility.Collapsed;
            //Call RoundEndCalculations()
            //NextRoundPanel.Visibility = Visibility.Visible;}

            else if (countT < NumberOfPlayers-1)
            {
                countT++;
                int score = HandScore(PlayerList[PlayerListBox.SelectedIndex].PlayerHand);
                if (CheckForBlackjack(score, PlayerList[PlayerListBox.SelectedIndex].PlayerHand))
                {
                    //end turn due to meeting a known end hand
                    NextMove();
                }
                else
                {
                    HandScore(PlayerList[PlayerListBox.SelectedIndex].PlayerHand);
                    UpdateCards();
                    TurnSelection.Visibility = Visibility.Collapsed;
                    NextPlayerPanel.Visibility = Visibility.Visible;
                }
            }
            //else if (counter == NumberOfPlayers)
            //{ 
            //    counter++;
            //    UpdateCards();
            //    DealerHandTurn();
            //    //TurnSelection.Visibility = Visibility.Collapsed;
            //    NextPlayerPanel.Visibility = Visibility.Visible;
            //    NextPlayerButton.Visibility = Visibility.Collapsed;
            //    NextRoundPanel.Visibility = Visibility.Visible;
            //    PlayerCardDisplaySection.Visibility = Visibility.Collapsed;
            //    PlayerSplitCardDisplaySection.Visibility = Visibility.Collapsed;
            //}
            else
            {
                TurnSelection.Visibility = Visibility.Collapsed;
                DealerHandTurn();
                UpdateCards();
                RoundEndCalculations();
                NextPlayerPanel.Visibility = Visibility.Visible;
                NextPlayerButtonPanel.Visibility = Visibility.Collapsed;
                NextRoundPanel.Visibility = Visibility.Visible;
                PlayerCardDisplaySection.Visibility = Visibility.Collapsed;
                PlayerSplitCardDisplaySection.Visibility = Visibility.Collapsed;
                //counter = 0;
            }
        }
        private void ChangePlayer()
        {
            //PlayerListBox.SelectedIndex = counter % turns;
            PlayerSplitCardDisplaySection.Visibility = Visibility.Collapsed;
            PlayerListBox.SelectedIndex = (PlayerListBox.SelectedIndex + 1) % NumberOfPlayers;
            if (PlayerList[PlayerListBox.SelectedIndex].Playing)
            {
                CurrentPlayerLabel.Content = PlayerList[PlayerListBox.SelectedIndex].Name + "'s Turn";
            }
            else
            {
                ChangePlayer();
            }
        }
        private void Hand1Turn()
        {
            hasSplit = false;
            onHand2 = false;
            PlayerList[PlayerListBox.SelectedIndex].PlayerHand[0].CardFaceUp = true;
            UpdateCards();
            //for (int t = 0; t < PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Count; t++)
            //{
            //    PlayerList[PlayerListBox.SelectedIndex].PlayerHand[t].CardFaceUp = true;
            //}
            int score = HandScore(PlayerList[PlayerListBox.SelectedIndex].PlayerHand);
            if (CheckForBlackjack(score, PlayerList[PlayerListBox.SelectedIndex].PlayerHand))
            {
                //end turn due to meeting a known end hand
                NextMove();
            }
            else
            {
                CheckForSplit();
            }
            
        }
        private void PlayOneCard()
        {
            //Draw and Add a card to player
            List<Card> hand = new List<Card>();
            if (onHand2)
            {
                //add new card to 
                hand = PlayerList[PlayerListBox.SelectedIndex].PlayerHand2;
                int score2 = HandScore(hand);
                if (!CheckForBlackjack(score2, hand))
                {
                    HitButton.Content = "Hit to Split";
                    PlayerList[PlayerListBox.SelectedIndex].PlayerHand2.Add(blackJackDeck.drawCard());
                    hand = PlayerList[PlayerListBox.SelectedIndex].PlayerHand2;
                    for (int t = 0; t < PlayerList[PlayerListBox.SelectedIndex].PlayerHand2.Count; t++)
                    {
                        PlayerList[PlayerListBox.SelectedIndex].PlayerHand2[t].CardFaceUp = true;
                    }
                    //HandScore(PlayerList[PlayerListBox.SelectedIndex].PlayerHand2);
                }
            }
            else
            {
                HitButton.Content = "Hit";
                hand = PlayerList[PlayerListBox.SelectedIndex].PlayerHand;
                int score2 = HandScore(hand);
                if (!CheckForBlackjack(score2, hand))
                {
                    //add new card to 
                    blackJackDeck.playerDraw(PlayerList[PlayerListBox.SelectedIndex], 1);
                    //PlayerList[PlayerListBox.SelectedIndex].PlayerHand[PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Count].CardFaceUp = true;
                    hand = PlayerList[PlayerListBox.SelectedIndex].PlayerHand;
                    for (int t = 0; t < PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Count; t++)
                    {
                        PlayerList[PlayerListBox.SelectedIndex].PlayerHand[t].CardFaceUp = true;
                    }
                }                
            }
            
            UpdateCards();
            //Check for should turn end
            int score = HandScore(hand);
            if (CheckForBust(score) || CheckFor5CardCharlie(hand) || CheckFor21(score) || CheckForBlackjack(score, hand))
            {
                //end turn due to meeting a known end hand
                NextMove();
            }
        }
        private void DealerHandTurn()
        {
            int dealerScore = DealerHandScore(dealer.DealerHand);
            while (dealerScore < 17 && blackJackDeck.Cards.Count > 0)
            {
                //add to 
                blackJackDeck.dealerDraw(dealer, 1);
                dealerScore = DealerHandScore(dealer.DealerHand);
            }
            for(int i=0; i < dealer.DealerHand.Count; i++)
            {
                dealer.DealerHand[i].CardFaceUp = true;
            }
            HouseCardList_ListBox.ItemsSource = null;
            HouseCardList_ListBox.ItemsSource = dealer.DealerHand;
            HouseCardList_ListBox.SelectedIndex = 0;
            UpdateCards();
        }

        //Game Body Logic
        private void RoundEndCalculations()
        {
            //figure out winning hands and update banks
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                if (PlayerList[i].Playing)
                {
                    int score = HandScore(PlayerList[i].PlayerHand);
                    List<Card> dealerH = dealer.DealerHand;
                    int dealerScore = HandScore(dealerH);
                    if (CheckForBust(score))
                    {
                        PlayerList[i].PlayerBank = PlayerList[i].PlayerBank - PlayerList[i].Bet;
                    }
                    else if (CheckFor5CardCharlie(PlayerList[i].PlayerHand))
                    {
                        PlayerList[i].PlayerBank = PlayerList[i].PlayerBank + (PlayerList[i].Bet * 3);
                    }
                    else if (CheckForBlackjack(dealerScore, dealerH) && CheckForBlackjack(score, PlayerList[i].PlayerHand2))
                    {
                        PlayerList[i].PlayerBank = PlayerList[i].PlayerBank;
                    }
                    else if (CheckForBlackjack(score, PlayerList[i].PlayerHand2))
                    {
                        PlayerList[i].PlayerBank = PlayerList[i].PlayerBank + (PlayerList[i].Bet * 2);
                    }
                    else if (CheckFor5CardCharlie(dealerH)|| CheckForBlackjack(dealerScore, dealerH))
                    {
                        PlayerList[i].PlayerBank = PlayerList[i].PlayerBank - PlayerList[i].Bet;
                    }
                    else if (dealerScore > 21)
                    {
                        PlayerList[i].PlayerBank = PlayerList[i].PlayerBank + PlayerList[i].Bet;
                    }
                    else
                    {
                        if (score > dealerScore)
                        {
                            PlayerList[i].PlayerBank = PlayerList[i].PlayerBank + (PlayerList[i].Bet * 1);
                        }
                        else if (score == dealerScore)
                        {
                            PlayerList[i].PlayerBank = PlayerList[i].PlayerBank;
                        }
                        else
                        {
                            PlayerList[i].PlayerBank = PlayerList[i].PlayerBank - PlayerList[i].Bet;
                        }
                    }

                    if (PlayerList[i].PlayerHand2.Count > 1)
                    {
                        score = HandScore(PlayerList[i].PlayerHand2);
                        if (CheckForBust(score))
                        {
                            PlayerList[i].PlayerBank = PlayerList[i].PlayerBank - PlayerList[i].Bet;
                        }
                        else if (CheckFor5CardCharlie(PlayerList[i].PlayerHand))
                        {
                            PlayerList[i].PlayerBank = PlayerList[i].PlayerBank + (PlayerList[i].Bet * 3);
                        }
                        else if (CheckForBlackjack(dealerScore, dealerH) && CheckForBlackjack(score, PlayerList[i].PlayerHand2))
                        {
                            PlayerList[i].PlayerBank = PlayerList[i].PlayerBank;
                        }
                        else if (CheckForBlackjack(score, PlayerList[i].PlayerHand2))
                        {
                            PlayerList[i].PlayerBank = PlayerList[i].PlayerBank + (PlayerList[i].Bet * 2);
                        }
                        else if (CheckFor5CardCharlie(dealerH) || CheckForBlackjack(dealerScore, dealerH))
                        {
                            PlayerList[i].PlayerBank = PlayerList[i].PlayerBank - PlayerList[i].Bet;
                        }
                        else if (dealerScore > 21)
                        {
                            PlayerList[i].PlayerBank = PlayerList[i].PlayerBank + PlayerList[i].Bet;
                        }
                        else
                        {
                            if (score > dealerScore)
                            {
                                PlayerList[i].PlayerBank = PlayerList[i].PlayerBank + (PlayerList[i].Bet * 1);
                            }
                            else if (score == dealerScore)
                            {
                                PlayerList[i].PlayerBank = PlayerList[i].PlayerBank;
                            }
                            else
                            {
                                PlayerList[i].PlayerBank = PlayerList[i].PlayerBank - PlayerList[i].Bet;
                            }
                        }
                    }                    
                }
                Console.WriteLine(PlayerList[i].Name + ": $" + PlayerList[i].PlayerBank);
            }
            UpdateBanks();
            if (CheckForGameOver())
            {
                GameHasEnded();
            }
        }
        private bool CheckFor5CardCharlie(List<Card> hand)
        {
            if (hand.Count == 5)
            {
                CauseOfTurnEnd.Content = "Five Hand";
                return true;
            }
            return false;
        }
        private bool CheckForBust(int score)
        {
            if (score > 21)
            {
                CauseOfTurnEnd.Content = "Hit Bust";
                return true;
            }
            return false;
        }
        private bool CheckForBlackjack(int score, List<Card> hand)
        {
            if (score == 21 && hand.Count == 2)
            {
                CauseOfTurnEnd.Content = "Blackjack";
                return true;
            }
            return false;
        }
        private bool CheckFor21(int score)
        {
            if (score == 21)
            {
                CauseOfTurnEnd.Content = "Hit 21 Points";
                return true;
            }
            return false;
        }
        private int HandScore(List<Card> hand)
        {
            int score = 0;
            int numOfAces = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                CardValue face = hand[i].FaceValue;
                if(face == CardValue.Ace)
                {
                    numOfAces = numOfAces + 1;
                    score = score + 11;
                }
                else if (face == CardValue.Two)
                {
                    score = score + 2;
                }
                else if (face == CardValue.Three)
                {
                    score = score + 3;
                }
                else if (face == CardValue.Four)
                {
                    score = score + 4;
                }
                else if (face == CardValue.Five)
                {
                    score = score + 5;
                }
                else if (face == CardValue.Six)
                {
                    score = score + 6;
                }
                else if (face == CardValue.Seven)
                {
                    score = score + 7;
                }
                else if (face == CardValue.Eight)
                {
                    score = score + 8;
                }
                else if (face == CardValue.Nine)
                {
                    score = score + 9;
                }
                else if (face == CardValue.Ten || face == CardValue.Jack || face == CardValue.Queen || face == CardValue.King)
                {
                    score = score + 10;
                }
                //else if ((int)hand[i].FaceValue == 1)
                //{
                //    numOfAces = numOfAces + 1;
                //    score = score + 11;
                //}
                //else
                //{
                //    score = score + (int)hand[i].FaceValue+1;
                //}
            }
            while (score > 21 && numOfAces > 0) 
            {
                score = score - 10;
                numOfAces = numOfAces - 1;
            }
            HandPoints.Content = score;
            return score;
        }
        private int DealerHandScore(List<Card> hand)
        {
            int score = 0;
            int numOfAces = 0;
            for (int i = 0; i < hand.Count; i++)
            {
                CardValue face = hand[i].FaceValue;
                if (face == CardValue.Ace)
                {
                    numOfAces = numOfAces + 1;
                    score = score + 11;
                }
                else if (face == CardValue.Two)
                {
                    score = score + 2;
                }
                else if (face == CardValue.Three)
                {
                    score = score + 3;
                }
                else if (face == CardValue.Four)
                {
                    score = score + 4;
                }
                else if (face == CardValue.Five)
                {
                    score = score + 5;
                }
                else if (face == CardValue.Six)
                {
                    score = score + 6;
                }
                else if (face == CardValue.Seven)
                {
                    score = score + 7;
                }
                else if (face == CardValue.Eight)
                {
                    score = score + 8;
                }
                else if (face == CardValue.Nine)
                {
                    score = score + 9;
                }
                else if (face == CardValue.Ten || face == CardValue.Jack || face == CardValue.Queen || face == CardValue.King)
                {
                    score = score + 10;
                }
            }
            return score;
        }
        private void CheckForSplit()
        {
            for (int t = 0; t < PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Count; t++)
            {
                PlayerList[PlayerListBox.SelectedIndex].PlayerHand[t].CardFaceUp = true;
            }

            if (PlayerList[PlayerListBox.SelectedIndex].PlayerHand[0].FaceValue == PlayerList[PlayerListBox.SelectedIndex].PlayerHand[1].FaceValue)
            {
                SplitBox.Visibility = Visibility.Visible;
            }
            else
            {
                SplitBox.Visibility = Visibility.Collapsed;
            }
        }
        private bool CheckForGameOver()
        {
            //What would cause game over?
            UpDatePlayersPlaying();
            int playing = 0;
            for (int i=0; i<NumberOfPlayers; i++)
            {
                if (PlayerList[i].Playing)
                {
                    playing++;
                }
            }
            if (playing == 0)
            {
                return true;
            }
            return false;
        }

        private void GameHasEnded()
        {
            GameOverPanel.Visibility = Visibility.Visible;
        }
        //Button Prompts
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NextRoundButton_Click(object sender, RoutedEventArgs e)
        {
            countB = 0;
            countT = 0;
            //Start a new round
            //reset game material
            blackJackDeck = new Deck();
            //Deck, Hands, Bets to false
            //counter = 0;
            NewDealer();
            if (CheckForGameOver())
            {
                GameHasEnded();
            }
            //clear player hands
            for (int i=0; i<NumberOfPlayers; i++)
            {
                if (PlayerList[i].Playing)
                {
                    PlayerList[i].PlayerHand = new List<Card>();
                    PlayerList[i].PlayerHand2 = new List<Card>();
                    PlayerList[i].Bet = 0;
                    blackJackDeck.playerDraw(PlayerList[i], 2);
                }
                else
                {
                    countT++;
                    countB++;
                }
            }
            SetCardFaceStates();
            //visibilities
            HandPointsPanel.Visibility = Visibility.Collapsed;
            TurnSelection.Visibility = Visibility.Collapsed;
            NextPlayerPanel.Visibility = Visibility.Collapsed;
            NextRoundPanel.Visibility = Visibility.Collapsed;
            NextPlayerButtonPanel.Visibility = Visibility.Visible;
        PlayerCardDisplaySection.Visibility = Visibility.Visible;
            PlayerSplitCardDisplaySection.Visibility = Visibility.Visible;
            BetPanel.Visibility = Visibility.Visible;

            PlayerListBox.SelectedIndex = NumberOfPlayers - 1;
            ChangePlayer();
            int indexT = PlayerListBox.SelectedIndex;
            PlayerListBox.ItemsSource = null;
            PlayerListBox.ItemsSource = PlayerList;
            PlayerListBox.SelectedIndex = indexT;
        }

        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {
            SplitBox.Visibility = Visibility.Collapsed;
            //set splitHand to true if using a bool
            hasSplit = true;
            //Execute split material
            List<Card> hand2 = new List<Card>();
            Card tempC = PlayerList[PlayerListBox.SelectedIndex].PlayerHand[1];
            Card newCard = new Card(tempC.Suit, tempC.FaceValue, true);
            hand2.Add(newCard);
            PlayerList[PlayerListBox.SelectedIndex].PlayerHand.RemoveAt(1);
            PlayerList[PlayerListBox.SelectedIndex].PlayerHand2 = hand2;
            //add a face down card to both hands
            //PlayerList[PlayerListBox.SelectedIndex].PlayerHand.Add(<FaceDown card>);
            blackJackDeck.playerDraw(PlayerList[PlayerListBox.SelectedIndex], 1);
            PlayerList[PlayerListBox.SelectedIndex].PlayerHand2.Add(blackJackDeck.drawCard());

            PlayerSplitCardDisplaySection.Visibility = Visibility.Visible;

            for (int t = 0; t < PlayerList[PlayerListBox.SelectedIndex].PlayerHand2.Count; t++)
            {
                PlayerList[PlayerListBox.SelectedIndex].PlayerHand2[t].CardFaceUp = true;
            }

            UpdateCards();
            //Modefie to create and call split variables
        }
        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            if (blackJackDeck.Cards.Count > 0)
            {
                PlayOneCard();
            }
            else
            {
                CauseOfTurnEnd.Content = "We ran out of cards, Sorry";
                TurnSelection.Visibility = Visibility.Collapsed;
                DealerHandTurn();
                UpdateCards();
                RoundEndCalculations();
                NextRoundPanel.Visibility = Visibility.Visible;
                PlayerCardDisplaySection.Visibility = Visibility.Collapsed;
                PlayerSplitCardDisplaySection.Visibility = Visibility.Collapsed;
                //counter = 0;
            }
        }
        private void StayButton_Click(object sender, RoutedEventArgs e)
        {
            CauseOfTurnEnd.Content = "Stayed";
            NextMove();
        }

        private void BetSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            //place in bet amount from BetAmount, 0=$1, 1=$5, 2=$10
            //Move to next player's bet
            //if(all players have placed a bet then){
            //BetPanel.Visibility = Visibility.Collapsed;
            //TurnSelection.Visibility = Visibility.Visible;}
            
            if (countB < NumberOfPlayers)
            {
                //ChangeTurn();
                int amount = BetAmount.SelectedIndex;
                PlayerList[PlayerListBox.SelectedIndex].Bet = (amount == 0) ? 1 : amount ==1? 5: 10;
                //counter++;
                countB++;
                BetAmount.SelectedIndex = 0;
                ChangePlayer();
            }
            if(countB==NumberOfPlayers)
            {
                UpdateCards();
                HandPointsPanel.Visibility = Visibility.Visible;
                BetPanel.Visibility = Visibility.Collapsed;
                TurnSelection.Visibility = Visibility.Visible;
                HandScore(PlayerList[PlayerListBox.SelectedIndex].PlayerHand);

                //counter = 1;
            }
        }

        private void ReturnToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }

        private void NextPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            NextPlayerPanel.Visibility = Visibility.Collapsed;
            TurnSelection.Visibility = Visibility.Visible;
            ChangePlayer();
            Hand1Turn();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerList[PlayerListBox.SelectedIndex].Playing = false;
            countB++;
            countT++;
            if (CheckForGameOver())
            {
                GameHasEnded();
            }
            else
            {
                if (PlayerListBox.SelectedIndex < NumberOfPlayers - 1)
                {
                    //do nothing extra I think
                }
                else
                {
                    UpdateCards();
                    BetPanel.Visibility = Visibility.Collapsed;
                    TurnSelection.Visibility = Visibility.Visible;
                }
                ChangePlayer();
            }
        }
    }
}
