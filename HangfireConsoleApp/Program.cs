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
                string value = "NA";
                Console.WriteLine("Hangfire server started...");

                BackgroundJob.Enqueue(() => Calculate("test1"));
                Console.WriteLine("value: " + value);

                BackgroundJob.Enqueue(() => Calculate("test2"));
                Console.WriteLine("value: " + value);

                BackgroundJob.Enqueue(() => Calculate("test2"));
                Console.WriteLine("value: " + value);


            }            
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static void Calculate(string testName)
        {
            int result = 0;
            for (int i = 0; i <= 1000; i++)
            {
                result += i;
            }
            Console.WriteLine($"test: {testName} - result: {result}");
        }
    }
}
