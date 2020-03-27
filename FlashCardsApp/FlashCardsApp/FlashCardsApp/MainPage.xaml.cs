using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlashCardsApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        private MainPageViewModel viewModel;


        public MainPage()
        {
            InitializeComponent();



            viewModel = new MainPageViewModel();

            BindingContext = viewModel;



            OtherList.ItemsSource = new string[]
            {

            };
        
          



        }


       

    }
}
