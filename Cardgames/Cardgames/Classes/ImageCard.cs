using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames.Classes
{
    class ImageCard
    {
        private string cardName;
        private string CardImage;
        private string CardBack;
        private string cardFace;
        private bool cardFaceUp;

        public ImageCard(string suit, int value, bool isFaceUp)
        {
            string suit2 = suit.Substring(0,1).ToUpper() + suit.Substring(1, suit.Length - 1).ToLower();
            this.cardName = ValueToCard(value) + " of " + suit2;
            this.cardFaceUp = isFaceUp;
            this.CardBack = "/Images/Cards/CardBack.png";
            this.CardImage = "/Images/Cards/" + ImageNameFormat(suit2, value)+".png";
            this.cardFace = cardFaceUp ? CardImage : CardBack;
        }
        private string ImageNameFormat(string suit2, int value)
        {
            string imageName = suit2;
            if (value < 10)
            {
                imageName = imageName + "0" + value;
            }
            else
            {
                imageName = imageName + value;
            }
            return imageName;
        }
        private string ValueToCard(int value)
        {
            string convertedValue = "";
            if(value == 1)
            {
                convertedValue = "Ace";
            }
            else if (value == 11)
            {
                convertedValue = "Jack";
            }
            else if (value == 12)
            {
                convertedValue = "Queen";
            }
            else if (value == 13)
            {
                convertedValue = "King";
            }
            else
            {
                convertedValue = value + "";
            }
            return convertedValue;
        }

        public string CardFace
        {
            get { return cardFace; }
            set { cardFace = value; }
           
        }
        public string CardName
        {
            get { return cardName; }
        }
        public bool CardFaceUp
        {
            get { return cardFaceUp; }
            set { cardFaceUp = value;
                cardFace = cardFaceUp ? CardImage : CardBack; }
        }

    }
}
