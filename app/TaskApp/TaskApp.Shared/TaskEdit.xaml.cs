using TaskApp.Models;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using TaskApp.Extensions;

namespace TaskApp
{
    public sealed partial class TaskEdit : Page
    {
        ToDoTask task;
        ToDoTask taskEdited;

        public TaskEdit()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            task = e.Parameter as ToDoTask;
            DataContext = task;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Tag = taskEdited;
        }

        private async void OnEditTaskClick(object sender, RoutedEventArgs e)
        {
            task.CreatedAt = task.CreatedAt.Replace("/", "-");
            taskEdited = new ToDoTask(task.Id, task.OwnerId, Title.Text, Value.Text, task.CreatedAt);
            string postBody = JsonConvert.SerializeObject(taskEdited);
            int code = await RestApi.putTask(taskEdited.Id, postBody);
            if (code == 204) Notification.Show("Task has been edited");
            else Notification.Show("Something was wrong");
            Frame.GoBack();
        }
    }
}
