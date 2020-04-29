using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp
{

    

    public class SwipeContainer : ContentView
    {


        public event EventHandler<SwipedEventArgs> Swipe;

        public SwipeContainer()
        {
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Up));

            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Down));

        }

        SwipeGestureRecognizer GetSwipeGestureRecognizer(SwipeDirection direction)
        {
            var swipe = new SwipeGestureRecognizer { Direction = direction };
            swipe.Swiped += (sender, e) => Swipe?.Invoke(this, e);           
            return swipe;
        }





    }





    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPage : ContentPage
    {

        

        private CardPageViewModel viewModel;

        public CardPageViewModel pubVM;

        public SubjectPage pubSubjectPage;

        private int pubSelectedSubject;

        private int pubSelectedCard;

        public CardPage(int selectedSubject, int selectedCard, SubjectPage subjectPage)
        {
            InitializeComponent();

            btnEdit.ImageSource = ImageSource.FromResource("FlashCardsApp.Edit.png");

            btnShow.ImageSource = ImageSource.FromResource("FlashCardsApp.Show.png");

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

            if (btnEdit.Text == "Edit")
            {

                answer.IsVisible = true;

                btnEdit.BackgroundColor = Color.Green;
                btnEdit.Text = "Save";

                question.IsReadOnly = false;
                answer.IsReadOnly = false;

                


            }
            else
            {

                btnEdit.BackgroundColor = Color.Blue;
                btnEdit.Text = "Edit";

                question.IsReadOnly = true;
                answer.IsReadOnly = true;


                ArrayControl.editCard(pubSelectedSubject, pubSelectedCard, question.Text, answer.Text);

                pubSubjectPage.updateCards();

                ArrayControl.JsonSave();

            }


        }

        private void btnShow_Clicked(object sender, EventArgs e)
        {

            answer.IsVisible = true;

        }




        private async void SwipeContainer_Swipe(object sender, SwipedEventArgs e)
        {



            if( == SwipeDirection.Up)
            {



                bool popupResult = await DisplayAlert("Alert", "Are you sure you want to delete this card?", "Delete", "Cancel");


                if (popupResult)
                {

                    ArrayControl.deleteCard(pubSelectedSubject, pubSelectedCard);

                }



                this.Navigation.RemovePage(this);


                pubSubjectPage.updateCards();






            }
            else if (ArrayControl.pubSwipe == SwipeDirection.Down)
            {


                answer.IsVisible = true;

            }
            




        }

        private void SwipeContainer_SwipeDown(object sender, SwipedEventArgs e)
        {

        }
    }
}