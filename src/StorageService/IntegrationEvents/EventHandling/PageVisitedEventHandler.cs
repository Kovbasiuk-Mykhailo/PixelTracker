using MassTransit;
using Messaging.Contract;
using StorageService.Models;
using StorageService.Services;

namespace StorageService.IntegrationEvents.EventHandling;

public class PageVisitedEventHandler(ILogService logService) : IConsumer<PageVisitedEvent>
{
    public async Task Consume(ConsumeContext<PageVisitedEvent> context)
    {
        var message = context.Message;
        var visit = new Visit(message.Referer, message.UserAgent, message.IpAddress, message.VisitedAt);
        
        await logService.Write(visit);
    }
}