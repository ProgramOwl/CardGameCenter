using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames.Classes
{
    class Playerv2
    {
        public string Name { get; set; }
        //public Card[] PlayerHand { get; set; }
        public ImageCard[] PlayerImageHand { get; set; }
        //public int PlayerBank { get; set; }
        //public int BlackjackScore { get; set; }
        public Playerv2(string name, ImageCard[] hand)
        {
            Name = name;
            PlayerImageHand = hand;
        }
    }
}
