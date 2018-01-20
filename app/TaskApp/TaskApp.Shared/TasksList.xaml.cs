using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using TaskApp.Models;
using TaskApp.Extensions;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using TaskApp.ViewModels;

namespace TaskApp
{
    public sealed partial class TasksList : Page
    {
        public TasksList()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            attachAppBar();
            DataContext = App.ViewModelLocator.TaskViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            TasksListBox.SelectedIndex = -1;
            App.ViewModelLocator.TaskViewModel.updateTasks();
        }

        private async void OnAddNewTaskClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TaskAdd));
        }

        private void onItemClick(object sender, SelectionChangedEventArgs e)
        {
            ToDoTask task = TasksListBox.SelectedItem as ToDoTask;
            if(task != null) Frame.Navigate(typeof(TaskShow), task);
        }

        private void attachAppBar()
        {
#if WINDOWS_PHONE_APP
            CommandBar cbar = new CommandBar
            {
                ClosedDisplayMode = AppBarClosedDisplayMode.Minimal
            };
            AppBarButton appBarButton = new AppBarButton
            {
                Label = "ADD"
            };
            cbar.PrimaryCommands.Add(appBarButton);
            this.BottomAppBar = cbar;
            appBarButton.Click += OnAddNewTaskClick;
#else
            CommandBar appBar = this.BottomAppBar as CommandBar;
            if (appBar == null)
            {
                appBar = new CommandBar();
                this.BottomAppBar = appBar;
            }
            AppBarButton appBarButton = new AppBarButton { Icon = new SymbolIcon(Symbol.Add), Label = "ADD" };
            appBarButton.Click += OnAddNewTaskClick;        
            appBar.SecondaryCommands.Add(appBarButton);    
#endif
        }
    }
}
