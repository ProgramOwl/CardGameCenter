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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cardgames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DeckFillTest();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            //if (TimesClosed == 0)
            //{
            //    MessageBox.Show("You haven't saved recently, are you sure you want to close it?");
            //    TimesClosed = 1;
            //}
            //else
            //{
                //MessageBox.Show("Ok, I'll really close this time.");
                Application.Current.Shutdown();
            //}
        }

        private void GoFishButton_Click(object sender, RoutedEventArgs e)
        {
            HomeTextPage.Visibility = Visibility.Collapsed;
            BlackJackForm.Visibility = Visibility.Collapsed;
            GoFishForm.Visibility = Visibility.Visible;
        }

        private void BlackJackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeTextPage.Visibility = Visibility.Collapsed;
            GoFishForm.Visibility = Visibility.Collapsed;
            BlackJackForm.Visibility = Visibility.Visible;
        }

        private void StartGoFishButton_Click(object sender, RoutedEventArgs e)
        {
            int number = AmountOfPlayersGo.SelectedIndex;
            //call to page
        }

        private void StartBlackJackButton_Click(object sender, RoutedEventArgs e)
        {
            int number = AmountOfPlayersBlack.SelectedIndex;
            //call to page
        }
        public void DeckFillTest()
        {
            Deck tempDeck = new Deck();
        }
    }
}
