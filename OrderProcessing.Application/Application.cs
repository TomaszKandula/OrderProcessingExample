
using OrderProcessing.Domain;
using OrderProcessing.Infrastructure.Services.Abstractions;

namespace OrderProcessing.Application;

public class Application(IOrderService orderService, ILoggerService loggerService)
{
    public void Run()
    {
        loggerService.LogInfo("Order Processing System started...");

        // This simulates Order Processing System
        var exampleOrder1 = new Order
        {
            Id = 1,
            Description = "Keyboard"
        };

        var exampleOrder2 = new Order
        {
            Id = 4,
            Description = "Display"
        };

        var tasks = new Task[6];
        tasks[0] = Task.Run(() => { orderService.ProcessOrder(1); });
        tasks[1] = Task.Run(() => { orderService.ProcessOrder(2); });
        tasks[2] = Task.Run(() => { orderService.CreateOrderEntry(exampleOrder1); }); // This will throw 'ArgumentException'
        tasks[3] = Task.Run(() => { orderService.CreateOrderEntry(exampleOrder2); });
        tasks[4] = Task.Run(() => { orderService.ProcessOrder(3); }); // This will throw 'KeyNotFoundException'
        tasks[5] = Task.Run(() => { orderService.ProcessOrder(-1); }); // This will throw 'ArgumentException'

        Task.WaitAll(tasks);
        loggerService.LogInfo("Job execution completed.");
    }
}