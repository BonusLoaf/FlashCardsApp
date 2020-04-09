using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardsApp
{
    public class MainPageViewModel
    {

        public static int number = 0;

        private List<string> _subjects;


        public MainPage pubMP;

        public List<string> subjects
        {
            get => _subjects;
            set
            {


                if (_subjects == value) return;

                _subjects = value;
                

            }
        }



        public MainPageViewModel(MainPage mp)
        {

            pubMP = mp;

            updateListView();

        }

        public void updateListView()
        {

            subjects = new List<string>();



            if(number == 0)
            {
                ArrayControl.subjectArrayTests();
                number += 1;
            }
            else
            {
                ArrayControl.updateArrayTests();
            }
            


            for (int i = 0; i < ArrayControl.subjectArray.Length; i++)
            {

                subjects.Add(ArrayControl.subjectArray[i].getSubjectName());

            }
        }




    }
}
