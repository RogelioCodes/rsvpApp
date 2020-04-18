using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeEventPage : ContentPage
    { // follows this tutorial https://www.youtube.com/watch?v=06ukwq8sxls
        public MakeEventPage()
        {
            InitializeComponent();

            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;
            int firstDayInCurrentMonth = 1;
            int lastDayInCurrentMonth = DateTime.DaysInMonth(currentYear, currentMonth);
            startDatePicker.MinimumDate = new DateTime(currentYear, currentMonth, firstDayInCurrentMonth);
            startDatePicker.MaximumDate = new DateTime(currentYear, currentMonth, lastDayInCurrentMonth);
            endDatePicker.MaximumDate = new DateTime(currentYear, currentMonth, lastDayInCurrentMonth);
            endDatePicker.MinimumDate = new DateTime(currentYear, currentMonth, firstDayInCurrentMonth);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //TimeSpan totaltime = endDatePicker.Date - startDatePicker.Date;
            //resultLabel.Text = totaltime.TotalDays.ToString();
            //this conditon is unecessary but might be handy when you have complex dates going on.
            if (startDatePicker.Date >= startDatePicker.MinimumDate && startDatePicker.Date <= endDatePicker.MaximumDate && endDatePicker.Date >= startDatePicker.MinimumDate && endDatePicker.Date <= endDatePicker.MaximumDate)
            {
                DateTime dateAndTime = DateTime.Now;

                // Inside this you can pass the respose from the server with in the current range of month
                resultLabel.Text = "The List of Available Seats " + dateAndTime.ToString("MM/dd/yyyy");

            }
            else
            {
                resultLabel.Text = "You have to select availabilty for this month & year only ";
            }

        }

    }
}
