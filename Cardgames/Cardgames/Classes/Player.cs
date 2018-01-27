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
        public int PlayerHand { get; set; }
        public int PlayerBank { get; set; }
        public int GoFishCounter { get; set; }
        public int BlackjackScore { get; set; }
        public Player(string name, int hand, int bank, int fishScore, int bljScore)
        {
            Name = name;
            PlayerHand = hand;
            PlayerBank = bank;
            GoFishCounter = fishScore;
            BlackjackScore = bljScore;
        }
    }
}
