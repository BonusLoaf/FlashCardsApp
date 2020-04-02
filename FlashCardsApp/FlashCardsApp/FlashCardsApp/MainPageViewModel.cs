using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardsApp
{
    class MainPageViewModel
    {


        private List<string> _subjects;

       
        public List<string> subjects
        {
            get => _subjects;
            set
            {


                if (_subjects == value) return;



                _subjects = value;
                
            }
        }


        


        public MainPageViewModel()
        {


            subjects = new List<string>();


            ArrayControl.fillArray();



            for (int i = 0; i < ArrayControl.testSubjectArray.Length; i++)
            {

                subjects.Add(ArrayControl.testSubjectArray[i]);

            }
            


        }




    }
}
