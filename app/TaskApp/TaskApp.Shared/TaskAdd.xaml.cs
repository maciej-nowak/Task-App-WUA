using TaskApp.Models;
using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TaskApp.Extensions;

namespace TaskApp
{
    public sealed partial class TaskAdd : Page
    {
        private String ownerId;
        public TaskAdd()
        {
            this.InitializeComponent();
            ownerId = LoginData.ReadLogin();
            if (!ownerId.Equals(""))
            {
                OwnerLabel.Visibility = Visibility.Collapsed;
                OwnerId.Visibility = Visibility.Collapsed;
            }
        }

        private async void OnAddNewTaskClick(object sender, RoutedEventArgs e)
        {
            ToDoTask toDoTask;
            if (!ownerId.Equals("")) toDoTask = new ToDoTask(ownerId, Title.Text, Value.Text);
            else toDoTask = new ToDoTask(OwnerId.Text, Title.Text, Value.Text);
            string postBody = JsonConvert.SerializeObject(toDoTask);
            int code = await RestApi.postTask(postBody);
            if (code == 201) Notification.Show("Task has been added");
            else Notification.Show("Something was wrong");
            Frame.GoBack();
        }
    }
}
