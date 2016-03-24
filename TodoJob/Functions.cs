using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MckScheduledTasks.Models;
using Microsoft.Azure.WebJobs;

namespace TodoJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage(
            //[QueueTrigger("queue")]
        string message, TextWriter log)
        {
            if (string.IsNullOrWhiteSpace(message)) {
                log.WriteLine("no message!");
                return;
            }

            log.WriteLine($"got message {message}");
            var db = new TodosContext();

            var todo = db.Todos.FirstOrDefault(x => x.Name == message);

            if (todo != null) {
                db.Occurrences.Add(new Occurrence {
                    TodoId = todo.Id,
                    CreatedOn = DateTime.Now
                });
                log.WriteLine("new occurrence created " + DateTime.Now.ToString("O"));
                db.SaveChanges();
            }
            else {
                log.WriteLine($"no todo found named {message}");
            }
        }
    }
}
