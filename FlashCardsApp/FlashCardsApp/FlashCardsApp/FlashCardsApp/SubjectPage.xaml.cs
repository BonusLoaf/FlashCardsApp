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

            btnDelete.BackgroundColor = Color.FromHex("#fafafa");

            btnCreate.BackgroundColor = Color.FromHex("#fafafa");

            btnEditName.BackgroundColor = Color.FromHex("#fafafa");

            btnDelete.ImageSource = ImageSource.FromResource("FlashCardsApp.Delete.png");

            btnCreate.ImageSource = ImageSource.FromResource("FlashCardsApp.Add.png");

            btnEditName.ImageSource = ImageSource.FromResource("FlashCardsApp.Edit.png");

            subjectTitle.Text = ArrayControl.subjectArray[selectedSubject].getSubjectName(); ;


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

            updateCards();
        }


        public void updateCards()
        {

            viewModel.updateListView(pubSelectedSubject);

            CardsListView.ItemsSource = null;
            CardsListView.ItemsSource = viewModel.cards;


            ArrayControl.JsonSave();

        }

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