using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace TodoJob
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main(string[] args)
        {
            var env_arg = Environment.GetEnvironmentVariable("WEBJOBS_COMMAND_ARGUMENTS");
            Console.WriteLine(env_arg);

            Console.WriteLine("argumnets: " + string.Join(", ", args));
            var cmd = !args.Any() ? "test" : args[0];
            Functions.ProcessQueueMessage(cmd, Console.Out);
        }
    }
}
