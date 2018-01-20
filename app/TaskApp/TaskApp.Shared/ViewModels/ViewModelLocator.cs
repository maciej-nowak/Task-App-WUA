using System;
using System.Collections.Generic;
using System.Text;

namespace TaskApp.ViewModels
{
    public class ViewModelLocator
    {
        public TaskViewModel TaskViewModel { get; private set; }
        public ViewModelLocator()
        {
            TaskViewModel = new TaskViewModel();
        }
    }
}
