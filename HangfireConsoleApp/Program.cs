using System;
using Hangfire;

namespace HangfireConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseColouredConsoleLogProvider();
            GlobalConfiguration.Configuration.UseSqlServerStorage("Hangfire");

            using (var server = new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire server started...");

                BackgroundJob.Enqueue(() => Console.WriteLine("Hello world from hangfire."));
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
