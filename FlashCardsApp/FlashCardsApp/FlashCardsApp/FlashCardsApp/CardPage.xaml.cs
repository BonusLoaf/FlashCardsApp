using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlashCardsApp
{

    
    //Allows the swipe containter to recognise swipes in 2 directions (up and down)
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


        //Sets up the card page
        //Checks if the page was created with edit mode enabled 
        //Loads a background image as well as the edit and show images for their buttons
        //Fills the entries with information from the the card array
        //Binds card page to its view model
        public CardPage(int selectedSubject, int selectedCard, SubjectPage subjectPage, bool editMode)
        {
            InitializeComponent();


            BackgroundImageSource = ImageSource.FromResource("FlashCardsApp.CardBackground.png");


            if(editMode)
            {

                answer.IsVisible = true;

                btnEdit.BackgroundColor = Color.Green;
                btnEdit.Text = "Save";

                question.IsReadOnly = false;
                answer.IsReadOnly = false;

                BackgroundImageSource = ImageSource.FromResource("FlashCardsApp.CardBackgroundOpen.png");

            }


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


        //If the page is in view mode, tapping the edit button will enable edit mode, allowing the user to change the text in the entries
        //Once in edit mode the button changes to a save button; when pressed the changed entries will be saved and the page will go back into view mode
        private void btnEdit_Clicked(object sender, EventArgs e)
        {

            if (btnEdit.Text == "Edit")
            {

                answer.IsVisible = true;

                btnEdit.BackgroundColor = Color.Green;
                btnEdit.Text = "Save";

                question.IsReadOnly = false;
                answer.IsReadOnly = false;

                BackgroundImageSource = ImageSource.FromResource("FlashCardsApp.CardBackgroundOpen.png");


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


        //The show button simply shows the text in the 'answer' entry to the user
        private void btnShow_Clicked(object sender, EventArgs e)
        {

            answer.IsVisible = true;

            BackgroundImageSource = ImageSource.FromResource("FlashCardsApp.CardBackgroundOpen.png");

        }



        //Swiping up will delete the card and take the user back to the subject page if then then press delete on the popup
        //Swiping down will show the user the answer; giving them the option to either press the button or use a gesture
        private async void SwipeContainer_Swipe(object sender, SwipedEventArgs e)
        {



            if (e.Direction == SwipeDirection.Up)
            {



                bool popupResult = await DisplayAlert("Alert", "Are you sure you want to delete this card?", "Delete", "Cancel");


                if (popupResult)
                {

                    ArrayControl.deleteCard(pubSelectedSubject, pubSelectedCard);


                    this.Navigation.RemovePage(this);


                    pubSubjectPage.updateCards();

                }


            }
            else if (e.Direction == SwipeDirection.Down)
            {

                answer.IsVisible = true;

                BackgroundImageSource = ImageSource.FromResource("FlashCardsApp.CardBackgroundOpen.png");

            }


        }

       
    }
}