using System;
using Hangfire;

namespace HangfireConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Member member = new Member() { Name = "Tomas", Number = 0 };
            GlobalConfiguration.Configuration.UseColouredConsoleLogProvider();
            GlobalConfiguration.Configuration.UseSqlServerStorage("Hangfire");
            
            using (var server = new BackgroundJobServer())
            {
                string value = "NA";
                Console.WriteLine("Hangfire server started...");

                BackgroundJob.Enqueue(() => Calculate(member, "test1"));
                Console.WriteLine($"member.Number: {member.Number}");

                BackgroundJob.Enqueue(() => Calculate(member, "test2"));
                Console.WriteLine($"member.Number: {member.Number}");

                BackgroundJob.Enqueue(() => Calculate(member, "test2"));
                Console.WriteLine($"member.Number: {member.Number}");
                //TODO: ako hangfire predava hodnotu???

            }            
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static void Calculate(Member member, string testName)
        {
            int result = 0;
            for (int i = 0; i <= 1000; i++)
            {
                result += i;
            }
            Console.WriteLine($"test: {testName} - result: {result}");
            member.Number = result;
        }
    }

    public class Member
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
