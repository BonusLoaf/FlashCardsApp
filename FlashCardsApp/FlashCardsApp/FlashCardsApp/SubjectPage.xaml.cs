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

        private SubjectPageViewModel viewModel;

        public SubjectPageViewModel pubViewModel;

        public static int pubSelectedSubject = 0;

        public MainPageViewModel pubMainPageVM;

        public SubjectPage(int selectedSubject, MainPageViewModel mainPageVM)
        {
            InitializeComponent();

            indexLabel.Text = ArrayControl.subjectArray[selectedSubject].getSubjectName(); ;


            viewModel = new SubjectPageViewModel(selectedSubject);

            BindingContext = viewModel;

            pubSelectedSubject = selectedSubject;

            pubMainPageVM = mainPageVM;

            CardsListView.ItemTapped += CardsListView_ItemTapped;

            pubViewModel = viewModel;

            

        }

        private async void CardsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int selectedRow = e.ItemIndex;

            await Navigation.PushAsync(new CardPage(pubSelectedSubject,selectedRow, this));
        }

       

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            ArrayControl.DeleteSubject(pubSelectedSubject);

            


            this.Navigation.RemovePage(this);


            pubMainPageVM.pubMP.UpdateSubjects();

        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            ArrayControl.CreateCard(pubSelectedSubject);
        }


        public void updateCards()
        {

            viewModel.updateListView(pubSelectedSubject);

            CardsListView.ItemsSource = null;
            CardsListView.ItemsSource = viewModel.cards;

        }



      


    }
}