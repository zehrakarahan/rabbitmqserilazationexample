using Lib;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsumeMsg
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

            manager.Consume<string>("testtquest", x => 
            {
                var mesaj = x.ToString();
                Console.WriteLine($"recive : {x}");
            });          
        }
    }
}
