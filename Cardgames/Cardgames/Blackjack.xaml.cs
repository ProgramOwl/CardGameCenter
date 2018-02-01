﻿using Cardgames.Classes;
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
        public int counter = 0;
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
            //BlackJackDealer dealer = new BlackJackDealer(0, 0);
            if(players == 5)
            {

            } else if(players == 4)
            {

            } else if(players == 3)
            {

            } else if(players == 2)
            {

            } else
            {

            }
        }
        private void TurnRotation(int turns)
        {
            PlayerListBox.SelectedIndex = counter % turns;
            if (counter % turns == 0)
            {
                Console.WriteLine("player 1 turn");
                counter++;
            }
            else if (counter % turns == 1)
            {
                Console.WriteLine("player 2 turn");
                counter++;
            }
            else if (counter % turns == 2)
            {
                Console.WriteLine("player 3 turn");
                counter++;
            }
            else if (counter % turns == 3)
            {
                Console.WriteLine("plaer 4 turn");
                counter++;
            }
            else if (counter % turns == 4)
            {
                Console.WriteLine("player 5 turn");
                counter++;
            }    
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
