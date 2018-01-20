using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TaskApp.Models;
using TaskApp.Extensions;


namespace TaskApp
{
    public sealed partial class MainPage : Page
    {
        private ToDoTask worker;

        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            String login = LoginData.ReadLogin();
            UserName.Text = login;      
        }

        private void OnLogin(object sender, RoutedEventArgs e)
        {
            LoginData.SaveLogin(UserName.Text.ToString());
            Frame.Navigate(typeof(TasksList));
        }

        private void OnAbout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }
    }
}
