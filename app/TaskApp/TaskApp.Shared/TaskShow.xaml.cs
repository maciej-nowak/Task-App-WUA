using TaskApp.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using TaskApp.Extensions;

namespace TaskApp
{
    public sealed partial class TaskShow : Page
    {
        ToDoTask task;

        public TaskShow()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.Tag != null)
            {
                task = (ToDoTask) rootFrame.Tag;
                rootFrame.Tag = null;
            }
            else task = e.Parameter as ToDoTask;
            DataContext = task;
        }


        private async void OnDeleteTaskClick(object sender, RoutedEventArgs e)
        {
            int code = await RestApi.deleteTask(task.Id);
            if (code == 200) Notification.Show("Task has been deleted");
            else Notification.Show("Something was wrong");
            Frame.GoBack();
        }

        private async void OnEditTaskClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaskEdit), task);
        }
    }
}
