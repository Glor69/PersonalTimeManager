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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace PersonalTimeManager.View
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage CurrentPage;
        //public const string CURRENTPAGE_NAME = "Main_";

        public MainPage()
        {
            this.InitializeComponent();

            CurrentPage = this;
            //TitleMenu.Text = CURRENTPAGE_NAME;
            
        }

        public List<MenuItem> MenuItems { get; } = new List<MenuItem>
        {
            new MenuItem() { Title = "Main", ClassType = typeof(GeneralPage) },
            new MenuItem() { Title = "Configuration", ClassType = typeof(ConfigurationsPage) },
            new MenuItem() { Title = "Settings", ClassType = typeof(SettingsPage) },
            new MenuItem() { Title = "Test view", ClassType = typeof(TestPage) }
        };

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MenuControl.ItemsSource = MenuItems;
            if (Window.Current.Bounds.Width < 640)
            {
                MenuControl.SelectedIndex = -1;
            }
            else
            {
                MenuControl.SelectedIndex = 0;
            }
        }

        private void MenuControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            MenuItem item = listBox.SelectedItem as MenuItem;
            if (item != null)
            {
                ContentFrame.Navigate(item.ClassType);
                if (Window.Current.Bounds.Width < 640)
                {
                    Splitter.IsPaneOpen = false;
                }
            }
        }
    }

    public class MenuItemBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            MenuItem item = value as MenuItem;
            return item.Title;//(MainPage.CurrentPage.MenuItems.IndexOf(item) + 1) + ") " + item.Title;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return true;
        }
    }
}
