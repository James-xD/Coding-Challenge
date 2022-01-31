using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Project1.Models;

namespace Project1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinManagement : ContentPage
    {
        public FinManagement()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

           int ticketnum =  TicketGenerator.Ticket();

            //Sends an Email to the registered User with their ticket Number
            var message = new EmailMessage("Ticket Reservation", ticketnum.ToString(), EntryTicketMail.Text);
            await Xamarin.Essentials.Email.ComposeAsync(message);

            //Sends an SMS to the registered User with their ticket Number but checks if their is an sms application or if the number is malformed
            try
            {
                await Sms.ComposeAsync(new SmsMessage(ticketnum.ToString(), EntryTicketMail.Text));
            }
            catch (Exception)
            {
                
            }
            
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        //Back Button
        {
            await Navigation.PushAsync(new Home());
        }

     




    }

}
