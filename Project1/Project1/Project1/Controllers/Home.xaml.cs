using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Project1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

       
        async void Button_Clicked(object sender, EventArgs e)
            //Logout Button
        {
            //Navigates the user to the Login Page
            await Navigation.PushAsync(new Login());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        //Financial Management Button
        {
            //Navigates the user to the FinManagement Page
            await Navigation.PushAsync(new FinManagement());
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        //Account Services Button
        {
            //Navigates the user to the AccServices Page
            await Navigation.PushAsync(new AccServices());
        }

    

        
    }
}