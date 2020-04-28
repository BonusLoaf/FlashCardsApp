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

            mp = this;

            viewModel = new MainPageViewModel(mp);

            BindingContext = viewModel;



            SubjectsListView.ItemTapped += SubjectListView_ItemTapped;


        }

        private async void SubjectListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int selectedRow = e.ItemIndex;
            lbl1.Text = selectedRow.ToString();

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


            viewModel.updateListView();

            SubjectsListView.ItemsSource = null;
            SubjectsListView.ItemsSource = viewModel.subjects;

        }


    }
}
