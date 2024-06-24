
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Collections.Concurrent;
using TTechBasicInfo.Infrastructure.Data.Sql.Commands.Common;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace TTechBasicInfo.Endpoints.API.BackgroundTasks;

public class EventPublisher : BackgroundService
{
    private readonly IConnection connection;
    private readonly IModel model;
    private readonly string requestRouteKeyPattern = "TTechNewsExchange.BasicInfo.Event.{0}";

    private readonly string exchangeName = "TTechNewsExchange";
    private readonly TTechBasicInfoCommandDbContext context;

    public EventPublisher(IServiceProvider serviceProvider)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };

        connection = factory.CreateConnection();
        model = connection.CreateModel();
        model.ExchangeDeclare(exchangeName, ExchangeType.Topic, false, false, null);
        var scop = serviceProvider.CreateScope();
        context = scop.ServiceProvider.GetRequiredService<TTechBasicInfoCommandDbContext>();    
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested is not true)
        {
            var events = await context.OutBoxEventItems.Where(c => c.IsProcessed == false).Take(100).ToListAsync();

            if (events.Any())
            {
                foreach (var @event in events)
                {
                    var finalRouteKey = string.Format(requestRouteKeyPattern, @event.EventName);
                    var messageBody = Encoding.UTF8.GetBytes(@event.EventPayload);
                    model.BasicPublish(exchangeName, finalRouteKey, null, messageBody);
                    @event.IsProcessed = true;
                }
                await context.SaveChangesAsync();
            }

            await Task.Delay(2000, stoppingToken);

        }

    }
}
