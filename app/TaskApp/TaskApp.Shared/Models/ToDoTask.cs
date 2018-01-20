using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.Networking.NetworkOperators;

namespace TaskApp.Models
{
    public class ToDoTask
    {
        public string OwnerId { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }
        public string CreatedAt { get; set; }

        public ToDoTask()
        { }

        public ToDoTask(String ownerId, String title, String value)
        {
            this.OwnerId = ownerId;
            this.Title = title;
            this.Value = value;
        }

        public ToDoTask(int id, String ownerId, String title, String value, String createdAt)
        {
            this.Id = id;
            this.OwnerId = ownerId;
            this.Title = title;
            this.Value = value;
            this.CreatedAt = createdAt;
        }

    }
}
