using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FlashCardsApp
{
    class Subject
    {
        [JsonProperty(PropertyName = "id")]
         private string subjectName;
         private int numberOfCards;
         private CardData[] cardArray;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


        public Subject(string theSubjectName, int theNumberOfCards, CardData[] theCardData)
         {
        
             subjectName = theSubjectName;
             numberOfCards = theNumberOfCards;
             cardArray = theCardData;
        
         }
        
         public string getSubjectName()
         {
             return subjectName;
         }

         public int getNumberOfCards()
        {
            return numberOfCards;
        }
        
         public CardData[] getCardData()
         {
             return cardArray;
         }
        
         public void setSubjectName(string newSubjectName)
         {
             subjectName = newSubjectName;
         }

        public void setNumberOfCards(int newNumberOfCards)
        {
            numberOfCards = newNumberOfCards;
        }

        public void setCardData(CardData[] newCardArray)
         {
            cardArray = newCardArray;
         }

    }
}
