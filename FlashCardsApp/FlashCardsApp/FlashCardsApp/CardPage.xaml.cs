using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPage : ContentPage
    {
        public CardPage(int selectedSubject,int selectedCard)
        {
            InitializeComponent();

             CardData thisCard = ArrayControl.subjectArray[selectedSubject].getCardData()[selectedCard];

            question.Text = thisCard.getCardQuestion();

            answer.Text = thisCard.getCardAnswer();


        }
    }
}