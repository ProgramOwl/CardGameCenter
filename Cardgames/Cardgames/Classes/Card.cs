using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardgames.Classes
{
    public class Card
    {
        private CardSuit suit;
        private string cardName;
        private string CardImage;
        private string CardBack;
        private string cardFace;
        private bool cardFaceUp;

        public CardSuit Suit
        {
            get { return suit; }
            set { suit = value; }
        }
        private CardValue faceValue;

        public CardValue FaceValue
        {
            get { return faceValue; }
            set { faceValue = value; }
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
            if (value == 1)
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
            set
            {
                cardFaceUp = value;
                cardFace = cardFaceUp ? CardImage : CardBack;
            }
        }
        public Card(CardSuit suit, CardValue faceValue, bool isFaceUp)
        {
            this.Suit = suit;
            this.FaceValue = faceValue;
            this.CardFaceUp = isFaceUp;
            string suitStringRaw = suit.ToString();
            string suitString = suitStringRaw.Substring(0, 1).ToUpper() + suitStringRaw.Substring(1, suitStringRaw.Length - 2).ToLower();
            int faceValueInt = (int)this.FaceValue + 1;
            this.cardName = ValueToCard(faceValueInt) + " of " + suitString;
            this.cardFaceUp = isFaceUp;
            this.CardBack = "/Images/Cards/CardBack.png";
            this.CardImage = "/Images/Cards/" + ImageNameFormat(suitString, faceValueInt) + ".png";
            this.cardFace = cardFaceUp ? CardImage : CardBack;
        }
    }
}
