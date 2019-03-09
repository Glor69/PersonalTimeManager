using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PersonalTimeManager.Model;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace PersonalTimeManager.View
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class GeneralPage : Page
    {
        public GeneralPage()
        {
            this.InitializeComponent();
            Clock.Action(UpDateClokView);
            Clock.Start();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Clock.Stop();
        }

        private void UpDateClokView(object sender, object e)
        {
            Year.Text = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month.ToString();
            Month.Text = month.Length == 2 ? month : "0" + month;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                Week.Foreground = new SolidColorBrush(Windows.UI.Colors.Red); 
            Week.Text = DateTime.Now.DayOfWeek.ToString().Substring(0, 3).ToUpper();
            var day = DateTime.Now.Day.ToString();
            Day.Text = day.Length == 2 ? day : "0" + day;
            HoursAndMinutes.Text = DateTime.Now.ToString("hh:mm");
            Seconds.Text = DateTime.Now.ToString("ss");
        }
    }
}
