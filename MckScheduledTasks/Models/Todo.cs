using System;

namespace MckScheduledTasks.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime NextOccurrenct { get; set; }
    }
}