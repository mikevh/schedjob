using System.Data.Entity;

namespace MckScheduledTasks.Models
{
    public class TodosContext : DbContext
    {
        public TodosContext() : base("DefaultConnection"){
            
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Occurrence> Occurrences { get; set; }

    }
}