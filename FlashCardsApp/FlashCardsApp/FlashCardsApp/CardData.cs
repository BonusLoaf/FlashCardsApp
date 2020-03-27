using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp
{
    class CardData
    {

        private string cardQuestion;
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
