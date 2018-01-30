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
        public bool player1Bet = false;
        public bool player2Bet = false;
        public bool player3Bet = false;
        public bool player4Bet = false;
        public bool player5Bet = false;
        public Blackjack()
        {
            InitializeComponent();
        }
        public void StartGame(int players)
        {
            BlackJackDealer dealer = new BlackJackDealer(0, 0);
            if(players == 5)
            {
                Player5Game();
            } else if(players == 4)
            {
                Player4Game();
            } else if(players == 3)
            {
                Player3Game();
            } else if(players == 2)
            {
                Player2Game();
            } else
            {
                Player1Game();
            }
        }
        private void Player1Game()
        {
            player1 = new Player("Player 1", 0, 20, 0, 0);
        }

        private void Player2Game()
        {
            player1 = new Player("Player 1", 0, 20, 0, 0);
            player2 = new Player("Player 2", 0, 20, 0, 0);
        }

        private void Player3Game()
        {
            player1 = new Player("Player 1", 0, 20, 0, 0);
            player2 = new Player("Player 2", 0, 20, 0, 0);
            player3 = new Player("Player 3", 0, 20, 0, 0);
        }

        private void Player4Game()
        {
            player1 = new Player("Player 1", 0, 20, 0, 0);
            player2 = new Player("Player 2", 0, 20, 0, 0);
            player3 = new Player("Player 3", 0, 20, 0, 0);
            player4 = new Player("Player 4", 0, 20, 0, 0);
        }

        private void Player5Game()
        {
            player1 = new Player("Player 1", 0, 20, 0, 0);
            player2 = new Player("Player 2", 0, 20, 0, 0);
            player3 = new Player("Player 3", 0, 20, 0, 0);
            player4 = new Player("Player 4", 0, 20, 0, 0);
            player5 = new Player("Player 5", 0, 20, 0, 0);
        }
    }
}
