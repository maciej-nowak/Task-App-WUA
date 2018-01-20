using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Extensions;
using TaskApp.Models;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace TaskApp.ViewModels
{
    public class TaskViewModel : ViewModel
    {    
        private ObservableCollection<ToDoTask> tasksCollection;
        public ObservableCollection<ToDoTask> TasksCollection
        {
            get { return tasksCollection; }
            set
            {
                tasksCollection = value;
                NotifyPropertyChanged();
            }
        }

        public TaskViewModel()
        {
            TasksCollection = new ObservableCollection<ToDoTask>();
            updateTasks();
        }

        public void updateTasks()
        {
            Task.Factory.StartNew(
            () =>
            {
                downloadTasks();
            });
        }

        private async void downloadTasks()
        {
            List<ToDoTask> list = await RestApi.getTasks();
            if (list == null) list = new List<ToDoTask>();
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () =>
            {
                if (!LoginData.ReadLogin().Equals(""))
                {
                    list = list.FindAll(TaskByUser);
                }
                TasksCollection = list.ToObservableCollection();
            });
        }

        private static bool TaskByUser(ToDoTask task)
        {
            if (task.OwnerId == LoginData.ReadLogin()) return true;
            else return false;
        }
    }
}

