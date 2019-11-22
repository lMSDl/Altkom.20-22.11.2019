using Altkom._20_22._11.CSharp.Models;
using Altkom._20_22._11.CSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom._20_22._11.CSharp.AsyncDemo
{
    class Program
    {
        static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        static async Task MainAsync(string[] args)
        {
            var users = await new CustomHttpClient().Get<List<User>>("api/users");



            MakeBreakfast();

            while (true)
                Console.WriteLine(Console.ReadLine());
        }

        static async void MakeBreakfast()
        {
            List<Task> tasks = new List<Task>();
            var coffeeTask = PourCoffee();
            tasks.Add(coffeeTask);
            var eggsTask = BoilEggs();
            tasks.Add(eggsTask);
            var beconTask = FryBecon();
            tasks.Add(beconTask);
            var toastsTask = MakeToasts();
            tasks.Add(toastsTask);

            while (tasks.Any())
            {
                var task = await Task.WhenAny(tasks);
                if (task == coffeeTask)
                    Console.WriteLine("Coffee ready");
                else if (task == eggsTask)
                    Console.WriteLine("Eggs ready");
                else if (task == beconTask)
                    Console.WriteLine("Becon ready");
                else if (task == toastsTask)
                {
                    Console.WriteLine("Toasts ready");
                    await AddButterToToasts();
                    Console.WriteLine("Butter on toasts");
                }

                tasks.Remove(task);
            }

        }

        static Task AddButterToToasts()
        {
            return Task.Delay(1000);
        }

        static Task MakeToasts()
        {
            return Task.Delay(3000);
        }

        static Task FryBecon()
        {
            return Task.Delay(5000);
        }

        static Task BoilEggs()
        {
            return Task.Delay(10000);
        }

        static Task PourCoffee()
        {
            return Task.Delay(500);
        }
    }
}
