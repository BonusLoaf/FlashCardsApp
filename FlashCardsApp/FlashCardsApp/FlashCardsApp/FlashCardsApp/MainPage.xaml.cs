using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace FlashCardsApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPageViewModel viewModel;

        public MainPage mp;



        //Sets up the main page and binds its viewmodel
        //Assigns an image to the 'create' button and gives its background transparency
        public MainPage()
        {

            InitializeComponent();

            btnCreateSbj.BackgroundColor = Color.FromHex("#fafafa");

            btnCreateSbj.ImageSource = ImageSource.FromResource("FlashCardsApp.Add.png");

            mp = this;

            viewModel = new MainPageViewModel(mp);

            BindingContext = viewModel;

            SubjectsListView.ItemTapped += SubjectListView_ItemTapped;
        }



        //Opens a subject page, with information based on the subject the user selected
        private async void SubjectListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            int selectedRow = e.ItemIndex;

            await Navigation.PushAsync(new SubjectPage(selectedRow, viewModel, false));

        }

        //Adds a new subject to the subject array, updates the list view, and takes the user to the subject page with edit mode enabled
        private async void btnCreateSbj_Clicked(object sender, EventArgs e)
        {
            ArrayControl.CreateSubject("New Subject");

            UpdateSubjects();

            await Navigation.PushAsync(new SubjectPage(ArrayControl.subjectArray.Length - 1, viewModel, true));

        }

        //Saves all of the arrays to a JSON file and refreshes the main page list view
        public void UpdateSubjects()
        {

            ArrayControl.JsonSave();

            viewModel.updateListView();

            SubjectsListView.ItemsSource = null;
            SubjectsListView.ItemsSource = viewModel.subjects;

        }


        //Detecs if the user swipes down, and saves the arrays to a JSON file then tells the user
        private async void SwipeContainer_Swipe(object sender, SwipedEventArgs e)
        {

            if (e.Direction == SwipeDirection.Down)
            {

                ArrayControl.JsonSave();

                await DisplayAlert("Alert", "Cards Saved Successfully!", "Ok");

            }
        }
    }
}
