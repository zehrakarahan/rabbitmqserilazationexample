using Lib;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProductMsg
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();            
            services.AddRabbitMQ(x =>
            {
                x.HostName = "localhost";
                x.UserName = "guest";
                x.Password = "guest";
                x.ExchangeName = "TestExchange";
            });

            var serviceProvider = services.BuildServiceProvider();

            var manager = serviceProvider.GetService<IRabbitMQManager>();

            string input="deneme";
            //do
            //{
            //    input = Console.ReadLine();

               // manager.Publish<string>(input, "deneme yapiyorum");
            manager.Publish<string>("zehranasılsın","testtquest");
            //}
            //while (input.Trim().ToLower() != "q");

            Console.ReadLine();
        }        
    }
}
