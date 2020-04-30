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
    public partial class SubjectPage : ContentPage
    {

        //pubViewModel and pubMainPageVM allow the use of pages created previously to be used in methods associated with buttons/events

        private SubjectPageViewModel viewModel;

        public SubjectPageViewModel pubViewModel;

        public static int pubSelectedSubject = 0;

        public MainPageViewModel pubMainPageVM;


        //Sets up the subject page
        //Checks if the page was created in edit mode
        //Binds this page to the viewmodel
        //Assigns images to all of the buttons and gives them a transparent background
        public SubjectPage(int selectedSubject, MainPageViewModel mainPageVM, bool editMode)
        {
            InitializeComponent();

            btnDelete.BackgroundColor = Color.FromHex("#fafafa");

            btnCreate.BackgroundColor = Color.FromHex("#fafafa");

            btnEditName.BackgroundColor = Color.FromHex("#fafafa");

            btnDelete.ImageSource = ImageSource.FromResource("FlashCardsApp.Delete.png");

            btnCreate.ImageSource = ImageSource.FromResource("FlashCardsApp.Add.png");

            btnEditName.ImageSource = ImageSource.FromResource("FlashCardsApp.Edit.png");

            subjectTitle.Text = ArrayControl.subjectArray[selectedSubject].getSubjectName(); ;


            if (editMode)
            {


                btnEditName.Text = "Save";
                btnEditName.BackgroundColor = Color.Green;

                subjectTitle.IsReadOnly = false;

            }


            viewModel = new SubjectPageViewModel(selectedSubject);

            BindingContext = viewModel;

            pubSelectedSubject = selectedSubject;

            pubMainPageVM = mainPageVM;

            CardsListView.ItemTapped += CardsListView_ItemTapped;

            pubViewModel = viewModel;

            

        }



        //Opens a card page, with information based on the card the user selected
        private async void CardsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int selectedRow = e.ItemIndex;

            await Navigation.PushAsync(new CardPage(pubSelectedSubject,selectedRow, this, false));
        }

       
        //Deletes the subject that the user is currently on the page for, then removes the page and updates the mainpage listview
        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            ArrayControl.DeleteSubject(pubSelectedSubject);

            this.Navigation.RemovePage(this);


            pubMainPageVM.pubMP.UpdateSubjects();

        }


        //Adds a new card to the card array, updates the list view, and takes the user to the card page with edit mode enabled
        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            ArrayControl.CreateCard(pubSelectedSubject);

            updateCards();

            await Navigation.PushAsync(new CardPage(pubSelectedSubject, ArrayControl.cardArray.Length - 1, this, true));
        }

        //Saves all of the arrays to a JSON file and refreshes the list view
        public void updateCards()
        {

            viewModel.updateListView(pubSelectedSubject);

            CardsListView.ItemsSource = null;
            CardsListView.ItemsSource = viewModel.cards;


            ArrayControl.JsonSave();

        }


        //If the page is in view mode, tapping the edit button will enable edit mode, allowing the user to change the name of the subject
        //Once in edit mode the button changes to a save button; when pressed the changed entry will be saved and the page will go back into view mode
        private void btnEditName_Clicked(object sender, EventArgs e)
        {

            if (btnEditName.Text == "Title")
            {

                btnEditName.BackgroundColor = Color.Green;
                btnEditName.Text = "Save";

                subjectTitle.IsReadOnly = false;


            }
            else
            {

                btnEditName.BackgroundColor = Color.FromHex("#fafafa");
                btnEditName.Text = "Title";

                subjectTitle.IsReadOnly = true;
                

                ArrayControl.EditSubject(pubSelectedSubject, subjectTitle.Text);

                pubMainPageVM.pubMP.UpdateSubjects();


                ArrayControl.JsonSave();

            }


        }
    }
}