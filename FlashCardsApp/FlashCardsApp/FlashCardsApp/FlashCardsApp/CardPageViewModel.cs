using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp
{
    public class CardPageViewModel
    {

        public bool _editmodeoff = true;




        public bool editModeOff
        {
            get => _editmodeoff;
            set
            {


                if (_editmodeoff == value) return;



                _editmodeoff = value;

            }
        }


        public void toggleEdit()
        {

            if (editModeOff == true)
            {
                editModeOff = false;
            }
            else
            {
                editModeOff = true;
            }

            

        }


    }
}
