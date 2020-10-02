using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orders.Domain;

namespace CSharp
{
	public class Program
	{
		public static OrderContext context = new OrderContext();
		public static void Main(string[] args)
		{
			context.Orders.AddRange(
			new Order {customer_id = 2, item = "soda popper", quantity = 1 },
			new Order {customer_id = 2, item = "iron gloves", quantity = 10 },
			new Order { customer_id = 3, item = "wrangler", quantity = 1 },
			new Order { customer_id = 3, item = "jag", quantity = 2 },
			new Order { customer_id = 3, item = "rescue ranger", quantity = 3 },
			new Order { customer_id = 4, item = "black box", quantity = 2 },
			new Order { customer_id = 5, item = "sticky jumper", quantity = 5 },
			new Order { customer_id = 1, item = "dead ringer", quantity = 1 },
			new Order { customer_id = 7, item = "ubersaw", quantity = 1 },
			new Order { customer_id = 7, item = "cozy camper", quantity = 4 }
			);
			context.SaveChanges();
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				}).ConfigureLogging((context, logger) =>
				{
					logger.ClearProviders();
					logger.AddConfiguration(context.Configuration.GetSection("Logging"));
					logger.AddDebug();
				});
	}
}
