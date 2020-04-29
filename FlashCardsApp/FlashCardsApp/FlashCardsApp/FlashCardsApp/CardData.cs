using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FlashCardsApp
{
    class CardData
    {

        [JsonProperty(PropertyName = "cardQuestion")]
        private string cardQuestion;
        [JsonProperty(PropertyName = "cardAnswer")]
        private string cardAnswer;

        public CardData(string theCardQuestion, string theCardAnswer) 
        {
            cardQuestion = theCardQuestion;
            cardAnswer = theCardAnswer;
        }
        
        public string getCardQuestion()
        {
            return cardQuestion;
        }
        
        public string getCardAnswer()
        {
            return cardAnswer;
        }
        
        public void setCardQuestion(string newCardQuestion)
        {
            cardQuestion = newCardQuestion;
        }
        
        public void setCardAnswer(string newCardAnswer)
        {
            cardAnswer = newCardAnswer;
        }
    }
}
