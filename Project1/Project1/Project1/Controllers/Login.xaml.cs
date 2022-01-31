using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project1.Helpers;

namespace Project1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            
        }

        async void Button_Clicked_1(object sender, EventArgs e)
            //Sign Up Button
        {
            //Navigates the user to the Register Page
            await Navigation.PushAsync(new Register());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        //Login Button
        {

            //Checks the database and the connection string and pulls values for validation
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUser>().Where(u => u.UserName.Equals(EntryUserName.Text) && u.Password.Equals(EntryUserPassword.Text)).FirstOrDefault();

            
            if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new Home());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //Checks if login details are correct else provides and error message
                    var result = await this.DisplayAlert("Error", "Incorrect User Name and Password", "Yes", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new Login());
                    else
                    {
                        await Navigation.PushAsync(new Login());
                    }

                });
            }
        }
    }
}