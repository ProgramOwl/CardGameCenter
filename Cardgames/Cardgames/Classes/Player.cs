using Cardgames.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> PlayerHand { get; set; }
        public List<Card> PlayerHand2 { get; set; }
        public int Bet { get; set; }
        public int PlayerBank { get; set; }
        public int GoFishCounter { get; set; }
        public Player(string name, List<Card> hand, List<Card> hand2, int bank, int fishScore, int bet)
        {
            Name = name;
            PlayerHand = hand;
            PlayerHand2 = hand2;
            PlayerBank = bank;
            GoFishCounter = fishScore;
            Bet = bet;
        }
    }
}
