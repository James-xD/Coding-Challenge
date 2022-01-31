using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }
       
        private void Button_Clicked(object sender, EventArgs e)
            //Register Button
        {
            Navigation.PushAsync(new Login());

           

            //Creates the database and connection string
           
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db");
                var db = new SQLiteConnection(dbpath);
                db.CreateTable<RegUser>();
            //stores the details into the database
                var item = new RegUser()
                {
                    UserName = EntryUserName.Text,
                    Password = EntryUserPassword.Text,
                    Email = EntryEmail.Text,
                    PhoneNumber = EntryPhoneNumber.Text
                };

                db.Insert(item);
                Device.BeginInvokeOnMainThread(async () => {
                    //sends a confirmation message stating that details have been stored in the db
                   var result = await this.DisplayAlert("Congradulations", "User Registration Successfull", "Yes", "Cancel");

                    if (result)
                        //then sends them back to login to login to their account
                        await Navigation.PushAsync(new Login());

                });
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Navigates user back to login 
            Navigation.PushAsync(new Login());
        }
    }
}