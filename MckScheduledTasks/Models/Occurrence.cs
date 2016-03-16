using System;

namespace MckScheduledTasks.Models
{
    public class Occurrence
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}