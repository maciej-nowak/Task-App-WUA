using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Lab4Workers.Models;
using Windows.Web.Http;
using Newtonsoft.Json.Linq;
using Windows.Web.Http.Headers;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Lab4Workers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkersList : Page
    {
        ObservableCollection<ToDoTask> workersCollection = new ObservableCollection<ToDoTask>();
        public WorkersList()
        {
            this.InitializeComponent();

            WorkersListBox.ItemsSource = workersCollection;
        }

        private async void OnAddNewWorkerClick(object sender, RoutedEventArgs e)
        {
            ToDoTask w = new ToDoTask
            {
                OwnerId = OwnerId.Text,
                Title = Title.Text,
                Id = workersCollection.Count + 1,
                Value = Value.Text
            };

            workersCollection.Add(w);
            await RestApi.getTasks();
            //String json = prepareJson();
            //RestApi.postWorker(json);
        }





        private string prepareJson()
        {
            ToDoTask toDoTask = new ToDoTask(OwnerId.Text, Title.Text, Value.Text);
            string postBody = JsonConvert.SerializeObject(toDoTask);
            return postBody;
        }
    }
}
