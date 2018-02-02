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
    /// Interaction logic for Blackjack.xaml
    /// </summary>
    public partial class Blackjack : Window
    {
        public Player player1;
        public Player player2;
        public Player player3;
        public Player player4;
        public Player player5;
        bool gameOnGoing;
        public bool player1Bet = false;
        public bool player2Bet = false;
        public bool player3Bet = false;
        public bool player4Bet = false;
        public bool player5Bet = false;
        public int counter = 0;
        public Deck deck;
        public List<Card> dHand = new List<Card>();
        public List<Card> dHand_2 = new List<Card>();
        public List<Card> hand1 = new List<Card>();
        public List<Card> hand1_2 = new List<Card>();
        public List<Card> hand2 = new List<Card>();
        public List<Card> hand2_2 = new List<Card>();
        public List<Card> hand3 = new List<Card>();
        public List<Card> hand3_2 = new List<Card>();
        public List<Card> hand4 = new List<Card>();
        public List<Card> hand4_2 = new List<Card>();
        public List<Card> hand5 = new List<Card>();
        public List<Card> hand5_2 = new List<Card>();
        public List<Player> gamePlayers = new List<Player>();
        public Blackjack()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void StartGame(int players)
        {
            SetupPlayerVisibilityBlack(players);
            gameOnGoing = true;
            deck = new Deck();
            BlackJackDealer dealer = new BlackJackDealer(dHand, dHand_2);
            player1 = new Player("Player 1", hand1, hand1_2, 20, 0, 0, false);
            player2 = new Player("Player 2", hand1, hand1_2, 20, 0, 0, false);
            player3 = new Player("Player 3", hand1, hand1_2, 20, 0, 0, false);
            player4 = new Player("Player 4", hand1, hand1_2, 20, 0, 0, false);
            player5 = new Player("Player 5", hand1, hand1_2, 20, 0, 0, false);
            if (players == 5)
            {
                player1.Playing = true;
                player2.Playing = true;
                player3.Playing = true;
                player4.Playing = true;
                player5.Playing = true;
                gamePlayers.Add(player1);
                gamePlayers.Add(player2);
                gamePlayers.Add(player3);
                gamePlayers.Add(player4);
                gamePlayers.Add(player5);
                deck.Deal(deck, "blackjack", true, gamePlayers);
                TurnRotation(5);
            } else if(players == 4)
            {
                player1.Playing = true;
                player2.Playing = true;
                player3.Playing = true;
                player4.Playing = true;
                gamePlayers.Add(player1);
                gamePlayers.Add(player2);
                gamePlayers.Add(player3);
                gamePlayers.Add(player4);
                deck.Deal(deck, "blackjack", true, gamePlayers);
                TurnRotation(4);
            } else if(players == 3)
            {
                player1.Playing = true;
                player2.Playing = true;
                player3.Playing = true;
                gamePlayers.Add(player1);
                gamePlayers.Add(player2);
                gamePlayers.Add(player3);
                deck.Deal(deck, "blackjack", true, gamePlayers);
                TurnRotation(3);
            } else if(players == 2)
            {
                player1.Playing = true;
                player2.Playing = true;
                gamePlayers.Add(player1);
                gamePlayers.Add(player2);
                deck.Deal(deck, "blackjack", true, gamePlayers);
                TurnRotation(2);
            } else
            {
                player1.Playing = true;
                gamePlayers.Add(player1);
                deck.Deal(deck, "blackjack", true, gamePlayers);
                TurnRotation(1);
            }
        }
        private void TurnRotation(int turns)
        {
            //PlayerListBox.SelectedIndex = counter % turns;
            if (counter % turns == 0)
            {
                Console.WriteLine("player 1 turn");
                counter++;
            }
            if (counter % turns == 1)
            {
                Console.WriteLine("player 2 turn");
                counter++;
            }
            if (counter % turns == 2)
            {
                Console.WriteLine("player 3 turn");
                counter++;
            }
            if (counter % turns == 3)
            {
                Console.WriteLine("plaer 4 turn");
                counter++;
            }
            if (counter % turns == 4)
            {
                Console.WriteLine("player 5 turn");
                counter++;
            }
            DealerTurn();
        }
        private void DealerTurn()
        {
            throw new NotImplementedException();
        }
        private void ChangeTurn()
        {
            //PlayerListBox.SelectedIndex = counter % turns;
            CurrentPlayerLabel.Content = "Player " + (PlayerListBox.SelectedIndex + 1) + "'s Trun";
        }
        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void StayButton_Click(object sender, RoutedEventArgs e)
        {
            TurnSelection.Visibility = Visibility.Collapsed;
        }

        private void BetSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            //place in bet amount from BetAmount, 0=$1, 1=$5, 2=$10
            //BetPanel.Visibility = Visibility.Collapsed;
            //TurnSelection.Visibility = Visibility.Visible;
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
            } else if (numberOfPlayers == 3)
            {
                player2Stats.Visibility = Visibility.Visible;
                player3Stats.Visibility = Visibility.Visible;
                player4Stats.Visibility = Visibility.Collapsed;
                player5Stats.Visibility = Visibility.Collapsed;
            } else if (numberOfPlayers == 4)
            {
                player2Stats.Visibility = Visibility.Visible;
                player3Stats.Visibility = Visibility.Visible;
                player4Stats.Visibility = Visibility.Visible;
                player5Stats.Visibility = Visibility.Collapsed;
            } else if (numberOfPlayers == 5)
            {
                player2Stats.Visibility = Visibility.Visible;
                player3Stats.Visibility = Visibility.Visible;
                player4Stats.Visibility = Visibility.Visible;
                player5Stats.Visibility = Visibility.Visible;
            }
        }
    }
}
