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

            
        }

        private async void CardsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int selectedRow = e.ItemIndex;

            await Navigation.PushAsync(new CardPage(pubSelectedSubject,selectedRow));
        }

       

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            ArrayControl.DeleteSubject(pubSelectedSubject);

            //new NavigationPage(new MainPage());


            this.Navigation.RemovePage(this);

            

            //var vUpdatedPage = new MainPage(); 
            
            //Navigation.InsertPageBefore(vUpdatedPage, this); Navigation.PopAsync();


            //this.Navigation.RemovePage(pubMainPageVM.pubMP);



        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            ArrayControl.CreateCard(pubSelectedSubject);
        }
    }
}