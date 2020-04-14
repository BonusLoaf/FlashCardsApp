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

        private CardPageViewModel viewModel;

        public CardPageViewModel pubVM;

        public SubjectPage pubSubjectPage;

        private int pubSelectedSubject;

        private int pubSelectedCard;
        
        public CardPage(int selectedSubject,int selectedCard, SubjectPage subjectPage)
        {
            InitializeComponent();

             CardData thisCard = ArrayControl.subjectArray[selectedSubject].getCardData()[selectedCard];

            question.Text = thisCard.getCardQuestion();

            answer.Text = thisCard.getCardAnswer();


            viewModel = new CardPageViewModel();

            BindingContext = viewModel;

            pubVM = viewModel;

            pubSelectedCard = selectedCard;

            pubSelectedSubject = selectedSubject;

            pubSubjectPage = subjectPage;

        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
           
            if(btnEdit.Text == "Edit")
            {

                btnEdit.BackgroundColor = Color.Green;
                btnEdit.Text = "Save";

                question.IsReadOnly = false;
                answer.IsReadOnly = false;




            }
            else
            {

                btnEdit.BackgroundColor = Color.Gray;
                btnEdit.Text = "Edit";

                question.IsReadOnly = true;
                answer.IsReadOnly = true;
                

                ArrayControl.editCard(pubSelectedSubject, pubSelectedCard, question.Text, answer.Text);

                pubSubjectPage.updateCards();

                

            }


        }
    }
}