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

        private async void SubjectListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int selectedRow = e.ItemIndex;
            

            //var nextPage = new SubjectPage();

            await Navigation.PushAsync(new SubjectPage(selectedRow, viewModel));
        }

        private void btnCreateSbj_Clicked(object sender, EventArgs e)
        {
            ArrayControl.CreateSubject("New Subject");


            UpdateSubjects();
        }

        public void UpdateSubjects()
        {

            ArrayControl.JsonSave();

            viewModel.updateListView();

            SubjectsListView.ItemsSource = null;
            SubjectsListView.ItemsSource = viewModel.subjects;

        }


    }
}
