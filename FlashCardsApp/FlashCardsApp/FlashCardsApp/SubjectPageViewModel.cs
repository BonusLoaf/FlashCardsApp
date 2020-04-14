using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp
{
    public class SubjectPageViewModel
    {

        private List<string> _cards;


        public List<string> cards
        {
            get => _cards;
            set
            {


                if (_cards == value) return;



                _cards = value;

            }
        }




        public SubjectPageViewModel(int selectedSubject)
        {


            updateListView(selectedSubject);


        }


        public void updateListView(int selectedSubject)
        {


            cards = new List<string>();


            CardData[] cardArray = ArrayControl.subjectArray[selectedSubject].getCardData();



            for (int i = 0; i < cardArray.Length; i++)
            {

                cards.Add(cardArray[i].getCardQuestion());

            }


            


        }



    }
}
