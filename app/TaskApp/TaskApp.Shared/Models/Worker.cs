using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.Networking.NetworkOperators;

namespace Lab4Workers.Models
{
    public class ToDoTask : INotifyPropertyChanged
    {
        //public string Name { get; set; }
        private string _ownerId;

        public string OwnerId
        {
            get { return _ownerId; }
            set
            {
                _ownerId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OwnerId"));
            }
        }

        public string Title { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
